using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Lexxers_Private_Orbwalker.Orbwalker
{
	static class Logic
	{
		public static AIHeroClient Me;

		public static int LastAutoAttackTick;
		public static int LastMovementTick;
		public static Vector3 LastMovementPos;
		public static GameObject LastAutoAttackTarget;

		public static Vector3 Override_MoveToPosition = Vector3.Zero;

		private static int _moveDelay;
		private static int _attackDelay;
		private static int _RandomDelay = 300;
		private static int _RandomDelayTick;
		private static bool _MissleStarted;

		internal static void Load()
		{
			Me = ObjectManager.Player;

			EloBuddy.SDK.Orbwalker.DisableAttacking = true;
			EloBuddy.SDK.Orbwalker.DisableMovement = true;

			Game.OnUpdate += OnFireLogic;
			Player.OnIssueOrder += OnIssueOrder;
			Obj_AI_Base.OnBasicAttack += OnAutoAttack;
		}

		private static void OnFireLogic(EventArgs args)
		{
			SetRandumValues();

			var mode = GetCurrentMode();

			if (Me.IsDead && !Me.IsZombie)
				return;
			Attack(mode);
			Move(mode);
		}

		private static void Attack(EloBuddy.SDK.Orbwalker.ActiveModes mode)
		{
			if (mode == EloBuddy.SDK.Orbwalker.ActiveModes.None)
				return;
			if (LastAutoAttackTick + GetRandomAttackDelay > Core.GameTickCount)
				return;
			if ((Me.Hero == Champion.Graves && Core.GameTickCount + Game.Ping / 2 + 25 >= LastAutoAttackTick + (1.0740296828d * 1000 * Me.AttackDelay - 716.2381256175d) && Player.HasBuff("GravesBasicAttackAmmo1")) ||
				(Me.Hero == Champion.Jhin && !Me.HasBuff("JhinPassiveReload")) ||
				Core.GameTickCount + Game.Ping / 2 + 25 >= LastAutoAttackTick + Me.AttackDelay * 1000)
			{
				var target = GetTarget(mode);
				if (target != null)
					Player.IssueOrder(GameObjectOrder.AttackUnit, target);

			}		
		}

		private static void Move(EloBuddy.SDK.Orbwalker.ActiveModes mode)
		{
			if (mode == EloBuddy.SDK.Orbwalker.ActiveModes.None)
				return;
			var extraWindUp = 0;
			// todo SpecialBuffs.
			if (Me.Hero == Champion.Kalista ||   // no cancleChampion
				Core.GameTickCount + Game.Ping / 2 >= LastAutoAttackTick + Me.AttackCastDelay * 1000 + WindUp + extraWindUp) // windup after AttackFinished
			{
				if (LastMovementTick + GetRandomMoveDelay > Core.GameTickCount)
					return;
				var goalPosition = (Override_MoveToPosition == Vector3.Zero && Game.CursorPos.IsValid())
					? Game.CursorPos
					: Override_MoveToPosition;
				if (goalPosition == Vector3.Zero)
					return;
				if (LastMovementPos.Distance(goalPosition) < 10)
					return;
				Player.IssueOrder(GameObjectOrder.MoveTo, goalPosition);
			}
		}

		private static AttackableUnit GetTarget(EloBuddy.SDK.Orbwalker.ActiveModes mode)
		{
			// Always Attack 1 shot Killable Enemy if in Range
			var bestTarget = GetKillableAutoAttackTarget();
			if (bestTarget != null)
				return bestTarget;

			// Attack Enemy if not Farm Prioritie
			if (mode == EloBuddy.SDK.Orbwalker.ActiveModes.Harass && !FarmPrioritie)
			{
				bestTarget = TargetSelector.GetTarget(GetPossibleTargets(), Me.GetAutoAttackDamageType());
				if (bestTarget != null)
					return bestTarget;
			}

			// lasthit Minion basic
			if (mode == EloBuddy.SDK.Orbwalker.ActiveModes.Harass || 
				mode == EloBuddy.SDK.Orbwalker.ActiveModes.LaneClear ||
			    mode == EloBuddy.SDK.Orbwalker.ActiveModes.LastHit)
			{
				var Minions = EntityManager.MinionsAndMonsters.Minions
					.Where(m => m.isValidAATarget())
					.OrderBy(m => m.CharData.BaseSkinName.Contains("Siege"))
					.ThenBy(m => m.CharData.BaseSkinName.Contains("Super"))
					.ThenBy(m => m.Health)
					.ThenByDescending(m => m.MaxHealth);
				foreach (var Minion in Minions)
				{
					var healthPred = Prediction.Health.GetPrediction(Minion, MissileHitTime(Minion));
					if (healthPred <= Me.GetAutoAttackDamageOverride(Minion, true))
					{
						return Minion;
					}
				}
			}
			return null;
		}

		private static AttackableUnit GetKillableAutoAttackTarget()
		{
			return GetPossibleTargets().FirstOrDefault(u=> u.Health <= Me.GetAutoAttackDamageOverride(u,true));
		}

		private static IEnumerable<AIHeroClient> GetPossibleTargets()
		{
			return ObjectManager.Get<AIHeroClient>().Where(u => u.isValidAATarget());
		}

		private static bool isValidAATarget(this Obj_AI_Base unit)
		{
			if (unit.IsDead || unit.IsAlly)
				return false;
			if (unit.HasBuff("JudicatorIntervention") && unit.GetBuff("JudicatorIntervention").EndTime < Game.Time + MissileHitTime(unit)) // Kayle R Buff
				return false;
			if (unit.HasBuff("Chronoshift") && unit.GetBuff("Chronoshift").EndTime < Game.Time + MissileHitTime(unit)) // Zilean R Buff
				return false;
			if (unit.HasBuff("FioraW") && unit.GetBuff("FioraW").EndTime < Game.Time + MissileHitTime(unit)) // Fiora W AttackReflect
				return false;
			if (Me.HasBuffOfType(BuffType.Blind) && Me.Hero == Champion.Caitlyn && !Me.HasBuff("caitlynheadshot")) // not shot while blind and Headshot is ready
				return false;
			if (unit.Name == "WardCorpse" || unit.CharData.BaseSkinName == "jarvanivstandard")
				return false;
			var attackrange = Me.AttackRange + Me.BoundingRadius + unit.BoundingRadius;
			if (Me.Hero == Champion.Caitlyn && unit.HasBuff("caitlynyordletrapinternal"))
				attackrange += 650;
			if (!unit.IsValidTarget(attackrange, true))
				return false;
			return true;
		}

		private static int MissileHitTime(this Obj_AI_Base unit)
		{
			var attackspeed = Me.BasicAttack.MissileSpeed;
			if (Me.IsMelee ||
				Me.Hero == Champion.Azir ||
				Me.Hero == Champion.Velkoz ||
				(Me.Hero == Champion.Viktor && Player.HasBuff("ViktorPowerTransferReturn")))
				attackspeed = float.MaxValue;
			return (int)(Me.AttackCastDelay * 1000) - 100 + Game.Ping / 2 +
				   1000 * (int)Math.Max(0, Me.Distance(unit) - unit.BoundingRadius) / (int)attackspeed;
		}

		private static void OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
		{
			if (sender.IsMe && args.Order == GameObjectOrder.MoveTo)
			{
				LastMovementTick = Core.GameTickCount + Game.Ping;
				LastMovementPos = args.TargetPosition;
			}
			if (sender.IsMe && args.Order == GameObjectOrder.AttackUnit)
			{
				LastAutoAttackTick = Core.GameTickCount + Game.Ping;
				LastAutoAttackTarget = args.Target;
			}
		}

		private static void OnAutoAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
		{
			if (sender.IsMe)
			{
				// todo attackresetCheck
			}
		}

		private static void SetRandumValues()
		{
			if (_RandomDelayTick + _RandomDelay < Core.GameTickCount)
			{
				_RandomDelayTick = Core.GameTickCount;
				_moveDelay = new Random().Next(80, 130);
				_attackDelay = new Random().Next(80, 130);
			}
		}

		private static EloBuddy.SDK.Orbwalker.ActiveModes GetCurrentMode()
		{
			if (EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.Combo))
				return EloBuddy.SDK.Orbwalker.ActiveModes.Combo;
			if (EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.Harass))
				return EloBuddy.SDK.Orbwalker.ActiveModes.Harass;
			if (EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.JungleClear))
				return EloBuddy.SDK.Orbwalker.ActiveModes.JungleClear;
			if (EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.LaneClear))
				return EloBuddy.SDK.Orbwalker.ActiveModes.LaneClear;
			if (EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.LastHit))
				return EloBuddy.SDK.Orbwalker.ActiveModes.LastHit;
			return EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.Flee) ? EloBuddy.SDK.Orbwalker.ActiveModes.Flee : EloBuddy.SDK.Orbwalker.ActiveModes.None;
		}

		public static bool FarmPrioritie
		{
			get { return Menu.Config_Behavier["priorityFarm"].Cast<CheckBox>().CurrentValue; }
		}

		public static float WindUp
		{
			get { return Menu.Config_Extra["windup"].Cast<Slider>().CurrentValue; }
		}

		public static int GetRandomMoveDelay
		{
			get { return _moveDelay; }
		}
		public static int GetRandomAttackDelay
		{
			get { return _attackDelay; }
		}
	}
}
