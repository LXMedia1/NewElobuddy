using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
		private static int _farmDelay;
		private const int _RandomDelay = 300;
		private static int _RandomDelayTick;

		public static List<Axe> AxeList = new List<Axe>(); 
		internal static void Load()
		{
			Me = ObjectManager.Player;

			EloBuddy.SDK.Orbwalker.DisableAttacking = true;
			EloBuddy.SDK.Orbwalker.DisableMovement = true;

			Game.OnUpdate += OnFireLogic;
			Player.OnIssueOrder += OnIssueOrder;
			Obj_AI_Base.OnSpellCast += OnSpellCast;
			GameObject.OnCreate += OnCreateObject;
			GameObject.OnDelete += OnDeleteObject;

		}
		private static void OnCreateObject(GameObject sender, EventArgs args)
		{
			if (!sender.Name.Contains("Q_reticle_self"))
				return;
			AxeList.Add(new Axe(sender));
		}

		private static void OnDeleteObject(GameObject sender, EventArgs args)
		{
			if (!sender.Name.Contains("Q_reticle_self"))
				return;
			foreach (var axe in AxeList.Where(axe => axe.NetworkId == sender.NetworkId))
			{
				AxeList.Remove(axe);
				return;
			}
		}
		private static void OnSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
		{
			if (sender.IsMe)
			{
				if (args.IsAutoAttackReset())
					Core.DelayAction(() => LastAutoAttackTick = 0, 50);
			}
		}

		private static void OnFireLogic(EventArgs args)
		{
			SetRandumValues();

			if (Me.IsDead && !Me.IsZombie)
				return;
			Attack();
			Move();
		}

		private static void Attack()
		{
			if (!HaveAnyModeActive())
				return;
			if (LastAutoAttackTick + GetRandomAttackDelay > Core.GameTickCount)
				return;
			if ((Me.Hero == Champion.Graves && Core.GameTickCount + Game.Ping / 2 + 25 >= LastAutoAttackTick + (1.0740296828d * 1000 * Me.AttackDelay - 716.2381256175d) && Player.HasBuff("GravesBasicAttackAmmo1")) ||
				(Me.Hero == Champion.Jhin && !Me.HasBuff("JhinPassiveReload")) ||
				Core.GameTickCount + Game.Ping / 2 + 25 >= LastAutoAttackTick + Me.AttackDelay * 1000)
			{
				ComboModeAttack();
				LastHitModeAttack();
				HarrasModeAttack();
				LaneClearModeAttack();
				JungleClearModeAttack();
				FleeModeAttack();
			}		
		}

		private static void Move()
		{
			if (!HaveAnyModeActive())
				return;
			var extraWindUp = 0;
			if (Me.Hero == Champion.Rengar && (Player.HasBuff("rengarqbase") || Player.HasBuff("rengarqemp")))
				extraWindUp = (int)(65 * Math.PI);
			if (Me.Hero == Champion.Kalista ||   // no cancleChampion
				Core.GameTickCount + Game.Ping / 2 >= LastAutoAttackTick + Me.AttackCastDelay * 1000 + WindUp + extraWindUp) // windup after AttackFinished
			{
				bool AutoSetPosition = false;
				if (LastMovementTick + GetRandomMoveDelay > Core.GameTickCount)
					return;
				
				if (Me.IsMelee && InteractRange > 0 && (MeleePrediction1 || MeleePrediction2) &&
				    EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.Combo))
				{
					if (MeleePrediction1)
					{
						var target = GetEnemyTarget(true);
						if (target != null && target.Distance(Game.CursorPos) <= InteractRange && target.Type == GameObjectType.AIHeroClient)
						{
							var xtarget = (AIHeroClient)target;
							Override_MoveToPosition = xtarget.GetMovementPrediction();
							AutoSetPosition = true;
						}
					}
					else if (MeleePrediction2)
					{
						var target = GetEnemyTarget(true);
						if (target != null && target.Distance(Game.CursorPos) <= InteractRange && target.Type == GameObjectType.AIHeroClient)
						{
							var xtarget = (AIHeroClient)target;
							Override_MoveToPosition = xtarget.Position.V3E(Game.CursorPos, Me.AttackRange);
							AutoSetPosition = true;
						}
					}
				}

				if (Me.Hero == Champion.Draven && CatchAxes)
				{
					var Xover = false;
					Axe[] axe = { null };
					foreach (var obj in AxeList.Where(obj => axe[0] == null || obj.CreationTime < axe[0].CreationTime))
						axe[0] = obj;
					if (axe[0] != null && axe[0].Position.Distance(Game.CursorPos) < InteractRange)
					{
						var distanceNorm = Vector2.Distance(axe[0].Position.To2D(), Me.ServerPosition.To2D()) - Me.BoundingRadius;
						var distanceBuffed = Me.GetPath(axe[0].Position).ToList().Select(point => point.To2D()).ToList().PathLength();
						var canCatchAxeNorm = distanceNorm / Me.MoveSpeed + Game.Time < axe[0].EndTime;
						var canCatchAxeBuffed = distanceBuffed / (Me.MoveSpeed + (5 * Champions.GetSpell_Draven_W().Level + 35) * 0.01 * Me.MoveSpeed + Game.Time) < axe[0].EndTime;

						if (!CatchAxesW)
							if (!canCatchAxeNorm)
							{
								AxeList.Remove(axe[0]);
								Xover = true;
							}
						if (!Xover)
						{
							if ( canCatchAxeBuffed && !canCatchAxeNorm && Champions.GetSpell_Draven_W().IsReady() &&
							     !axe[0].Catching())
								Champions.GetSpell_Draven_W().Cast();

							Override_MoveToPosition = axe[0].Position.V3E(Game.CursorPos, 49 + Me.BoundingRadius);
							AutoSetPosition = true;
						}
					}
				}

				var goalPosition = (Override_MoveToPosition == Vector3.Zero && Game.CursorPos.IsValid())
					? Game.CursorPos
					: Override_MoveToPosition;

				if (goalPosition == Vector3.Zero)
					return;

				if (goalPosition.Distance(Me) <= HoldArea && Override_MoveToPosition == Vector3.Zero && AutoSetPosition)
					return;
				if (LastMovementPos.Distance(goalPosition) < 10 && AutoSetPosition)
					return;
				Player.IssueOrder(GameObjectOrder.MoveTo, goalPosition);
				Override_MoveToPosition = Vector3.Zero;
			}
		}
		private static void ComboModeAttack()
		{
			if (!EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.Combo))
				return;
			var target = GetKillableAutoAttackTarget();

			if (target == null)
				target = GetEnemyTarget();

			if (target == null)
				target = GetNearEnemyNexus();

			if (target == null)
				target = GetNearEnemyInhibitor();

			if (target == null)
				target = GetNearEnemyTower();

			target.ExecuteAttack();	
		}
		private static void LastHitModeAttack()
		{
			if (!EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.LastHit))
				return;
			var bestTarget = GetKillableAutoAttackTarget() ?? GetLasthitMinion();
			bestTarget.ExecuteAttack();
		}
		
		private static void HarrasModeAttack()
		{
			if (!EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.Harass))
				return;

			var target = GetKillableAutoAttackTarget();

			if (FarmPrioritie)
			{
				if (target == null)
					target = GetLasthitMinion();
				if (target == null)
					target = GetLasthitMonster();
			}

			if (target == null )
				target = GetNearEnemyNexus();

			if (target == null )
				target = GetNearEnemyInhibitor();

			if (target == null && (!WaitForMinion() || !FarmPrioritie))
				target = GetNearEnemyTower();

			if (target == null && (!WaitForMinion() || !FarmPrioritie))
				target = GetEnemyTarget();

			if (target == null && (!WaitForMinion() || !FarmPrioritie))
				target = GetLasthitMinion();

			if (target == null && (!WaitForMinion() || !FarmPrioritie))
				target = GetLasthitMonster();

			if (target == null && (!WaitForMinion() || !FarmPrioritie))
				target = GetNearEnemyObjects();

			if (target == null && (!WaitForMinion() || !FarmPrioritie))
				target = GetNearEnemyWard();

			target.ExecuteAttack();	
				
		}
		
		private static void LaneClearModeAttack()
		{
			if (!EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.LaneClear))
				return;

			var target = GetKillableAutoAttackTarget();

			if (target == null)
				target = GetLasthitMinion();

			if (target == null)
				target = GetNearEnemyNexus();

			if (target == null)
				target = GetNearEnemyInhibitor();

			if (target == null)
				target = GetNearEnemyTower();

			if (target == null)
				target = GetNearEnemyObjects();

			if (target == null)
				target = GetNearEnemyWard();

			if (target == null&& !WaitForMinion())
				target = GetEnemyTarget();

			if (target == null && !WaitForMinion())
				target = GetLaneClearMinion();

			target.ExecuteAttack();	
		}
		
		private static void JungleClearModeAttack()
		{
			if (!EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.JungleClear))
				return;

			var target = GetKillableAutoAttackTarget();

			if (target == null)
				target = GetLasthitMonster();

			if (target == null)
				target = GetNearEnemyNexus();

			if (target == null)
				target = GetNearEnemyInhibitor();

			if (target == null)
				target = GetNearEnemyTower();

			if (target == null)
				target = GetNearEnemyObjects();

			if (target == null)
				target = GetNearEnemyWard();

			if (target == null)
				target = GetJungleClearMonster();

			target.ExecuteAttack();
		}
		
		private static void FleeModeAttack()
		{
			if (!EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.Flee))
				return;
			var bestTarget = GetKillableAutoAttackTarget();
			bestTarget.ExecuteAttack();
		}

		public static float PathLength(this List<Vector2> path)
		{
			var distance = 0f;
			for (var i = 0; i < path.Count - 1; i++)
			{
				distance += path[i].Distance(path[i + 1]);
			}
			return distance;
		}

		private static AttackableUnit GetNearEnemyInhibitor()
		{
			return ObjectManager.Get<Obj_BarracksDampener>().FirstOrDefault(w => w.isValidAATarget());
		}

		private static AttackableUnit GetNearEnemyNexus()
		{
			return ObjectManager.Get<Obj_HQ>().FirstOrDefault(w => w.isValidAATarget());
		}

		private static AttackableUnit GetNearEnemyWard()
		{
			if (!RemoveWards)
				return null;
			return ObjectManager.Get<Obj_AI_Base>().FirstOrDefault(w => w.isValidAATarget() &&
				(w.Name == "VisionWard" ||
				w.Name == "SightWard"));
		}

		private static AttackableUnit GetNearEnemyObjects()
		{
			if (!RemoveObjects)
				return null;
			return ObjectManager.Get<Obj_AI_Base>().FirstOrDefault(o => o.isValidAATarget() &&
				(o.BaseSkinName == "HeimerTblue" ||
				o.BaseSkinName == "HeimerTYellow" ||
				o.Name == "Tibbers" ||
				o.BaseSkinName == "VoidGate" ||
				o.BaseSkinName == "VoidSpawn" ||
				o.Name == "Barrel" ||
				o.BaseSkinName == "ShacoBox" ));
		}

		private static AttackableUnit GetNearEnemyTower()
		{
			var Tower = ObjectManager.Get<Obj_AI_Turret>()
						.Where(t => t.isValidAATarget())
						.OrderBy(t=> t.Distance(Me))
						.FirstOrDefault();
			return Tower;
		}

		private static AttackableUnit GetEnemyTarget(bool meleePred = false)
		{
			// todo need a much better focus...
				return TargetSelector.GetTarget(GetPossibleTargets(meleePred), Me.GetAutoAttackDamageType());
		}

		private static AttackableUnit GetLasthitMinion()
		{
			var Minions = EntityManager.MinionsAndMonsters.Minions
						.Where(m => m.isValidAATarget())
						.OrderBy(m => m.CharData.BaseSkinName.Contains("Siege"))
						.ThenBy(m => m.CharData.BaseSkinName.Contains("Super"))
						.ThenBy(m => m.Health)
						.ThenByDescending(m => m.MaxHealth);
			return (from Minion in Minions let healthPred = Prediction.Health.GetPrediction(Minion, MissileHitTime(Minion)) where healthPred <= Me.GetAutoAttackDamageOverride(Minion, true) select Minion).FirstOrDefault();
		}
		
		private static AttackableUnit GetLasthitMonster()
		{
			var Minions = EntityManager.MinionsAndMonsters.Monsters
						.Where(m => m.isValidAATarget())
						.OrderBy(m => m.CharData.BaseSkinName.Contains("Siege"))
						.ThenBy(m => m.CharData.BaseSkinName.Contains("Super"))
						.ThenBy(m => m.Health)
						.ThenByDescending(m => m.MaxHealth);
			return (from Minion in Minions let healthPred = Prediction.Health.GetPrediction(Minion, MissileHitTime(Minion)) where healthPred <= Me.GetAutoAttackDamageOverride(Minion, true) select Minion).FirstOrDefault();
		}

		private static AttackableUnit GetLaneClearMinion()
		{
			var Minions = EntityManager.MinionsAndMonsters.Minions
						.Where(m => m.isValidAATarget())
						.OrderBy(m => m.CharData.BaseSkinName.Contains("Siege"))
						.ThenBy(m => m.CharData.BaseSkinName.Contains("Super"))
						.ThenBy(m => m.Health)
						.ThenByDescending(m => m.MaxHealth);
			return (from Minion in Minions let healthPred = Prediction.Health.GetPrediction(Minion, (int)(Me.AttackDelay * 2 + MissileHitTime(Minion) * 2)) where (healthPred >= Me.GetAutoAttackDamageOverride(Minion, false) * 1) select Minion).FirstOrDefault();
		}

		private static AttackableUnit GetJungleClearMonster()
		{
			if (PriorityJungleBig)
				return EntityManager.MinionsAndMonsters.Monsters
							.Where(m => m.isValidAATarget())
							.OrderByDescending(m => m.MaxHealth)
							.FirstOrDefault();
			return EntityManager.MinionsAndMonsters.Monsters
						.Where(m => m.isValidAATarget())
						.OrderBy(m => m.CharData.BaseSkinName.Contains("Siege"))
						.ThenBy(m => m.CharData.BaseSkinName.Contains("Super"))
						.ThenByDescending(m => m.Health)
						.ThenByDescending(m => m.MaxHealth)
						.FirstOrDefault();
		}
		private static void ExecuteAttack(this AttackableUnit target)
		{
			if (target != null && Me.CanAttack)
				Player.IssueOrder(GameObjectOrder.AttackUnit, target);
		}		

		private static bool WaitForMinion()
		{
			if (GetLasthitMinion() != null)
				return false;
			return EntityManager.MinionsAndMonsters.Minions.Any(m => m.isValidAATarget() &&
																	 Prediction.Health.GetPrediction(m,
																		 (int)(Me.AttackDelay * 1000 * 2)) <=
																	 Me.GetAutoAttackDamageOverride(m, true));
		}

		private static AttackableUnit GetKillableAutoAttackTarget()
		{
			return GetPossibleTargets().FirstOrDefault(u=> u.Health <= Me.GetAutoAttackDamageOverride(u,true));
		}

		private static IEnumerable<AIHeroClient> GetPossibleTargets(bool meleepred = false)
		{
			return ObjectManager.Get<AIHeroClient>().Where(u => u.isValidAATarget(meleepred));
		}
		private static bool isValidAATarget(this Obj_HQ nexus)
		{
			if (nexus.IsDead || nexus.IsAlly)
				return false;
			var attackrange = Me.AttackRange + Me.BoundingRadius + nexus.BoundingRadius;
			if (!nexus.IsValidTarget(attackrange, true))
				return false;
			return true;
		}
		private static bool isValidAATarget(this Obj_BarracksDampener inhib)
		{
			if (inhib.IsDead || inhib.IsAlly)
				return false;
			var attackrange = Me.AttackRange + Me.BoundingRadius + inhib.BoundingRadius;
			if (!inhib.IsValidTarget(attackrange,true))
				return false;
			return true;
		}
		private static bool isValidAATarget(this Obj_AI_Base unit,bool meleepred = false)
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
			if (meleepred)
			{
				if (!(unit.IsValidTarget(99999, true) && Game.CursorPos.Distance(unit) <= InteractRange))
					return false;
			}
			else
			{
				var attackrange = Me.AttackRange + Me.BoundingRadius + unit.BoundingRadius;
				if (Me.Hero == Champion.Caitlyn && unit.HasBuff("caitlynyordletrapinternal"))
					attackrange += 650;
				if (!unit.IsValidTarget(attackrange, true))
					return false;
			}
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
			return (int)(Me.AttackCastDelay * 1000)  + Game.Ping / 2 +
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



		private static void SetRandumValues()
		{
			if (_RandomDelayTick + _RandomDelay < Core.GameTickCount)
			{
				_RandomDelayTick = Core.GameTickCount;
				var rnd = new Random();
				_moveDelay = rnd.Next(80, 130);
				_attackDelay = rnd.Next(80, 130);
				_farmDelay = rnd.Next(0, 50);
			}
		}

		public static bool CatchAxesW
		{
			get { return Menu.Config_Behavier["CatchAxesW"].Cast<CheckBox>().CurrentValue; }
		}
		public static bool CatchAxes
		{
			get { return Menu.Config_Behavier["CatchAxes"].Cast<CheckBox>().CurrentValue; }
		}
		public static bool PriorityJungleBig
		{
			get { return Menu.Config_Behavier["priorityJungleBig"].Cast<CheckBox>().CurrentValue; }
		}
		public static bool MeleePrediction1
		{
			get { return Menu.Config_Behavier["meleePrediction1"].Cast<CheckBox>().CurrentValue; }
		}
		public static bool MeleePrediction2
		{
			get { return Menu.Config_Behavier["meleePrediction2"].Cast<CheckBox>().CurrentValue; }
		}
		public static int InteractRange
		{
			get { return Menu.Config_Behavier["interactRange"].Cast<Slider>().CurrentValue; }
		}
		public static int HoldArea
		{
			get { return Menu.Config_Extra["holdArea"].Cast<Slider>().CurrentValue; }
		}
		public static bool RemoveObjects
		{
			get { return Menu.Config_Behavier["removeObjects"].Cast<CheckBox>().CurrentValue; }
		}

		public static bool RemoveWards
		{
			get { return Menu.Config_Behavier["removeWards"].Cast<CheckBox>().CurrentValue; }
		}

		public static bool FarmPrioritie
		{
			get { return Menu.Config_Behavier["priorityFarm"].Cast<CheckBox>().CurrentValue; }
		}
		
		public static float WindUp
		{
			get { return Menu.Config_Extra["windup"].Cast<Slider>().CurrentValue; }
		}

		public static int GetRandomFarmDelay
		{
			get { return _farmDelay; }
		}

		public static int GetRandomMoveDelay
		{
			get { return _moveDelay; }
		}
		public static int GetRandomAttackDelay
		{
			get { return _attackDelay; }
		}

		public static bool HaveAnyModeActive()
		{
			return EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.Combo) ||
			       EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.Harass) ||
			       EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.LaneClear) ||
			       EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.JungleClear) ||
			       EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.LastHit) ||
			       EloBuddy.SDK.Orbwalker.ActiveModesFlags.HasFlag(EloBuddy.SDK.Orbwalker.ActiveModes.Flee);
		}

		public class Axe
		{
			public GameObject AxeObject;
			public double CreationTime;
			public double EndTime;
			public int NetworkId;
			public Vector3 Position;

			public Axe(GameObject axeObject)
			{
				AxeObject = axeObject;
				NetworkId = axeObject.NetworkId;
				Position = axeObject.Position;
				CreationTime = Game.Time;
				EndTime = CreationTime + 1.2;
			}

			public float DistanceToPlayer()
			{
				return Me.Distance(Position);
			}

			public bool Catching()
			{
				return Me.Position.Distance(Position) <= 49 + Me.BoundingRadius / 2 + 50;
			}
		}
	}
}
