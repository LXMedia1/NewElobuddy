using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using SharpDX;

namespace CarryMe_Collection.Basics
{
	static class CastLogics
	{
		public enum CollisionType
		{
			Basic,
			None,
			EnemyHeros,
		}
		public enum TargetType
		{
			Enemy,
			MinionLasthit,
			MinionStrongest,
			AnyEnemy,
			AnyEnemyMinions,
			AnyMonster,
			MonsterLastHit,
			MonsterStrongest,
			Wards,
			Objects,
			NearstEnemy,
			Me,
			Buddy,
			Always,
			EnemynotNearTower,
		}


		public static void CastLogicLinearBasic(this Spell.Skillshot spell, CollisionType collision, TargetType targetType, DamageType damagetype)
		{
			if (!spell.IsReady())
				return;
			switch (targetType)
			{
				case TargetType.Enemy:
					var target = TargetSelector.GetTarget(spell.Range, damagetype);
					if (target == null)
						return;
					var pred = spell.GetProdiction(target, null, collision);
					if (pred.Hitchance >= HitChance.High && pred.isValid)
						spell.Cast(pred.CastPosition);
					break;
				case TargetType.NearstEnemy:
					var NearTarget = EntityManager.Heroes.Enemies.Where(u => !u.IsDead && u.IsValidTarget(spell.Range)).OrderBy(u => u.Distance(Champions.Me)).FirstOrDefault();
					if (NearTarget == null)
						return;
					var NearTargetpred = spell.GetProdiction(NearTarget, null, collision);
					if (NearTargetpred.Hitchance >= HitChance.High && NearTargetpred.isValid)
						spell.Cast(NearTargetpred.CastPosition);
					break;
				case TargetType.MinionLasthit:
					var PossibleTargets = EntityManager.MinionsAndMonsters.EnemyMinions.Where(
							u => u.IsValidTarget(spell.Range) && u.Health <= Champions.Me.GetDamageSpell(u, spell.Slot) && !Champions.Me.IsInAutoAttackRange(u));
					foreach (var eventualtarget in from eventualtarget in PossibleTargets let minioncoll = GetCollision(Champions.Me.Position, eventualtarget.Position, spell.Width, eventualtarget, collision) where !minioncoll.Any() select eventualtarget)
					{
						spell.Cast(eventualtarget.Position);
						break;
					}
					break;
				case TargetType.MinionStrongest:
					var strongestMinion = EntityManager.MinionsAndMonsters.EnemyMinions.Where(
							u => u.IsValidTarget(spell.Range) && Prediction.Health.GetPrediction(u, 250) > 100 + Champions.Me.GetDamageSpell(u, spell.Slot)).OrderBy(u => u.Health).Reverse().FirstOrDefault();
					if (strongestMinion != null)
					{
						var minioncoll = GetCollision(Champions.Me.Position, strongestMinion.Position, spell.Width, strongestMinion, collision);
						if (!minioncoll.Any())
							spell.Cast(strongestMinion.Position);
					}
					break;
				case TargetType.MonsterLastHit:
					var PossibleMonsterTargets = EntityManager.MinionsAndMonsters.Monsters.Where(
							u => u.IsValidTarget(spell.Range) && u.Health <= Champions.Me.GetDamageSpell(u, spell.Slot));
					foreach (var eventualtarget in from eventualtarget in PossibleMonsterTargets let minioncoll = GetCollision(Champions.Me.Position, eventualtarget.Position, spell.Width, eventualtarget, collision) where !minioncoll.Any() select eventualtarget)
					{
						spell.Cast(eventualtarget.Position);
						break;
					}
					break;
				case TargetType.MonsterStrongest:
					var strongestMonster = EntityManager.MinionsAndMonsters.Monsters.Where(
							u => u.IsValidTarget(spell.Range)).OrderBy(u => u.Health).Reverse().FirstOrDefault();
					if (strongestMonster != null)
					{
						var minioncoll = GetCollision(Champions.Me.Position, strongestMonster.Position, spell.Width, strongestMonster, collision);
						if (!minioncoll.Any())
							spell.Cast(strongestMonster.Position);
					}
					break;
			}
		}
		public static void CastLogicLinearExtendedRange(this Spell.Skillshot spell, CollisionType collision, TargetType targetType, DamageType damagetype, float ExtendRange)
		{
			if (!spell.IsReady())
				return;
			switch (targetType)
			{
				case TargetType.Enemy:
					var target = TargetSelector.GetTarget(spell.Range, damagetype);
					if (target == null)
						return;
					var pred = spell.GetProdiction(target, null, collision);
					if (pred.Hitchance >= HitChance.High && pred.isValid)
					{
						var ModifiedPosition = Champions.Me.Position.V3E(pred.CastPosition, ExtendRange + Champions.Me.Position.Distance(pred.CastPosition));
						spell.Cast(ModifiedPosition);
					}
					break;
				case TargetType.EnemynotNearTower:
					var target2 = TargetSelector.GetTarget(spell.Range, damagetype);
					if (target2 == null)
						return;
					var pred2 = spell.GetProdiction(target2, null, collision);
					if (pred2.Hitchance >= HitChance.High && pred2.isValid)
					{
						var ModifiedPosition = Champions.Me.Position.V3E(pred2.CastPosition, ExtendRange + Champions.Me.Position.Distance(pred2.CastPosition));
						if (!(ObjectManager.Get<Obj_AI_Turret>().Any(t => ModifiedPosition.Distance(t) <= 1000 && t.IsEnemy) && ModifiedPosition.IsUnderTurret()))
							spell.Cast(ModifiedPosition);
					}
					break;
				case TargetType.NearstEnemy:
					var NearTarget = EntityManager.Heroes.Enemies.Where(u => !u.IsDead && u.IsValidTarget(spell.Range)).OrderBy(u => u.Distance(Champions.Me)).FirstOrDefault();
					if (NearTarget == null)
						return;
					var NearTargetpred = spell.GetProdiction(NearTarget, null, collision);
					if (NearTargetpred.Hitchance >= HitChance.High && NearTargetpred.isValid)
					{
						var ModifiedPosition = Champions.Me.Position.V3E(NearTargetpred.CastPosition, ExtendRange + Champions.Me.Position.Distance(NearTargetpred.CastPosition));
						spell.Cast(ModifiedPosition);
					}
					break;
				case TargetType.MinionLasthit:
					var PossibleTargets = EntityManager.MinionsAndMonsters.EnemyMinions.Where(
							u => u.IsValidTarget(spell.Range) && u.Health <= Champions.Me.GetDamageSpell(u, spell.Slot) && !Champions.Me.IsInAutoAttackRange(u));
					foreach (var eventualtarget in from eventualtarget in PossibleTargets let minioncoll = GetCollision(Champions.Me.Position, eventualtarget.Position, spell.Width, eventualtarget, collision) where !minioncoll.Any() select eventualtarget)
					{
						var ModifiedPosition = Champions.Me.Position.V3E(eventualtarget.Position, ExtendRange + Champions.Me.Position.Distance(eventualtarget.Position));
						spell.Cast(ModifiedPosition);
						break;
					}
					break;
				case TargetType.MinionStrongest:
					var strongestMinion = EntityManager.MinionsAndMonsters.EnemyMinions.Where(
							u => u.IsValidTarget(spell.Range) && Prediction.Health.GetPrediction(u, 250) > 100 + Champions.Me.GetDamageSpell(u, spell.Slot)).OrderBy(u => u.Health).Reverse().FirstOrDefault();
					if (strongestMinion != null)
					{
						var minioncoll = GetCollision(Champions.Me.Position, strongestMinion.Position, spell.Width, strongestMinion, collision);
						if (!minioncoll.Any())
						{
							var ModifiedPosition = Champions.Me.Position.V3E(strongestMinion.Position, ExtendRange + Champions.Me.Position.Distance(strongestMinion.Position));
							spell.Cast(ModifiedPosition);
						}
					}
					break;
				case TargetType.MonsterLastHit:
					var PossibleMonsterTargets = EntityManager.MinionsAndMonsters.Monsters.Where(
							u => u.IsValidTarget(spell.Range) && u.Health <= Champions.Me.GetDamageSpell(u, spell.Slot));
					foreach (var eventualtarget in from eventualtarget in PossibleMonsterTargets let minioncoll = GetCollision(Champions.Me.Position, eventualtarget.Position, spell.Width, eventualtarget, collision) where !minioncoll.Any() select eventualtarget)
					{
						var ModifiedPosition = Champions.Me.Position.V3E(eventualtarget.Position, ExtendRange + Champions.Me.Position.Distance(eventualtarget.Position));
						spell.Cast(ModifiedPosition);
						break;
					}
					break;
				case TargetType.MonsterStrongest:
					var strongestMonster = EntityManager.MinionsAndMonsters.Monsters.Where(
							u => u.IsValidTarget(spell.Range)).OrderBy(u => u.Health).Reverse().FirstOrDefault();
					if (strongestMonster != null)
					{
						var minioncoll = GetCollision(Champions.Me.Position, strongestMonster.Position, spell.Width, strongestMonster, collision);
						if (!minioncoll.Any())
						{
							var ModifiedPosition = Champions.Me.Position.V3E(strongestMonster.Position, ExtendRange + Champions.Me.Position.Distance(strongestMonster.Position));
							spell.Cast(ModifiedPosition);
						}
					}
					break;
			}
		}
		public static void ActivateAuraLogic(this Spell.Active spell, TargetType targetType)
		{
			if (!spell.IsReady() || Champions.Me.Spellbook.GetSpell(spell.Slot).ToggleState == 2)
				return;
			switch (targetType)
			{
				case TargetType.AnyEnemy:
					var Enemys = EntityManager.Heroes.Enemies.Where(u => !u.IsDead && u.IsValidTarget(spell.Range));
					if (Enemys.Any())
						spell.Cast();
					break;
				case TargetType.AnyEnemyMinions:
					var Minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(u => !u.IsDead && u.IsValidTarget(spell.Range));
					if (Minions.Any())
						spell.Cast();
					break;
				case TargetType.AnyMonster:
					var Monsters = EntityManager.MinionsAndMonsters.Monsters.Where(u => !u.IsDead && u.IsValidTarget(spell.Range));
					if (Monsters.Any())
						spell.Cast();
					break;
			}
		}
		public static void DisableAuraLogic(this Spell.Active spell, float EnemyRange, float MinionRange, float MonsterRange)
		{
			if (!spell.IsReady() || Champions.Me.Spellbook.GetSpell(spell.Slot).ToggleState != 2)
				return;
			var Enemys = EntityManager.Heroes.Enemies.Where(u => !u.IsDead && u.IsValidTarget(EnemyRange));
			var Minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(u => !u.IsDead && u.IsValidTarget(MinionRange));
			var Monsters = EntityManager.MinionsAndMonsters.Monsters.Where(u => !u.IsDead && u.IsValidTarget(MonsterRange));
			if (!(Enemys.Any() || Minions.Any() || Monsters.Any()))
				spell.Cast();
		}
		public static void AfterAttackLogic(this Spell.Active spell, AttackableUnit target, TargetType targetType)
		{
			if (!spell.IsReady())
				return;
			switch (targetType)
			{
				case TargetType.AnyEnemy:
					if (target.Type == GameObjectType.AIHeroClient)
					{
						var enemytarget = (AIHeroClient)target;
						if (enemytarget.Health - Champions.Me.GetAutoAttackDamage(enemytarget) > 0)
						{
							Orbwalker.ForcedTarget = enemytarget;
							spell.Cast();
							Core.DelayAction(() => Orbwalker.ForcedTarget = null, 250);
						}
						else
						{
							var switchtarget = EntityManager.Heroes.Enemies.FirstOrDefault(u => !u.IsDead && u.NetworkId != enemytarget.NetworkId && u.IsValidTarget(spell.Range));
							if (switchtarget != null)
							{
								Orbwalker.ForcedTarget = switchtarget;
								spell.Cast();
								Core.DelayAction(() => Orbwalker.ForcedTarget = null, 250);
							}
						}
					}
					break;
				case TargetType.MinionLasthit:
				case TargetType.MonsterLastHit:
					if (target.Type == GameObjectType.obj_AI_Minion)
					{
						var enemytarget = (Obj_AI_Minion)target;
						if (enemytarget.Health - Champions.Me.GetAutoAttackDamage(enemytarget) > 0 && enemytarget.Health < Champions.Me.GetAutoAttackDamage(enemytarget) + Champions.Me.GetDamageSpell(enemytarget, spell.Slot))
						{
							Orbwalker.ForcedTarget = enemytarget;
							spell.Cast();
							Core.DelayAction(() => Orbwalker.ForcedTarget = null, 250);
						}
						else
						{
							var switchtarget = EntityManager.Heroes.Enemies.FirstOrDefault(u => !u.IsDead && u.NetworkId != enemytarget.NetworkId && u.IsValidTarget(spell.Range) && enemytarget.Health < Champions.Me.GetDamageSpell(enemytarget, spell.Slot));
							if (switchtarget != null)
							{
								Orbwalker.ForcedTarget = switchtarget;
								spell.Cast();
								Core.DelayAction(() => Orbwalker.ForcedTarget = null, 250);
							}
						}
					}
					break;
				case TargetType.AnyEnemyMinions:
				case TargetType.AnyMonster:
					if (target.Type == GameObjectType.obj_AI_Minion)
					{
						var enemytarget = (Obj_AI_Minion)target;
						if (enemytarget.Health - Champions.Me.GetAutoAttackDamage(enemytarget) > 0)
						{
							Orbwalker.ForcedTarget = enemytarget;
							spell.Cast();
							Core.DelayAction(() => Orbwalker.ForcedTarget = null, 250);
						}
					}
					break;
				case TargetType.Wards:
					if (target.Type == GameObjectType.obj_Ward)
					{
						var ward = (Obj_Ward)target;
						if (ward.Health > 1)
						{
							Orbwalker.ForcedTarget = ward;
							spell.Cast();
							Core.DelayAction(() => Orbwalker.ForcedTarget = null, 250);
						}
					}
					break;
				case TargetType.Objects:
					if (target.Type == GameObjectType.obj_Turret || target.Type == GameObjectType.obj_AI_Turret || target.Type == GameObjectType.obj_BarracksDampener || target.Type == GameObjectType.obj_HQ)
					{
						Orbwalker.ForcedTarget = target;
						spell.Cast();
						Core.DelayAction(() => Orbwalker.ForcedTarget = null, 250);
					}
					break;
			}
		}
		public static void CastifBetween(this Spell.Active spell, TargetType targetType, Vector3 from, Vector3 to, float width)
		{
			if (!spell.IsReady() || from.IsZero || to.IsZero)
				return;
			switch (targetType)
			{
				case TargetType.AnyEnemy:
					var Collobjs = GetCollision(from, to, width, null, CollisionType.EnemyHeros);
					if (Collobjs.Any())
						spell.Cast();
					break;
			}
		}
		public static void CastIfInRange(this Spell.Active spell, TargetType targetType, float range, Vector3 fromPos)
		{
			if (!spell.IsReady() || fromPos == Vector3.Zero)
				return;
			switch (targetType)
			{
				case TargetType.AnyEnemy:
					if (EntityManager.Heroes.Enemies.Any(u => !u.IsDead && u.Distance(fromPos) <= range))
						spell.Cast();
					break;
				case TargetType.Me:
					if (fromPos.Distance(Champions.Me.Position) <= range)
						spell.Cast();
					break;
				case TargetType.Buddy:
					if (EntityManager.Heroes.Allies.Any(u => !u.IsDead && u.Distance(fromPos) <= range))
						spell.Cast();
					break;
				case TargetType.AnyEnemyMinions:
					if (EntityManager.MinionsAndMonsters.Minions.Any(u => !u.IsDead && u.IsEnemy && u.Distance(fromPos) <= range))
						spell.Cast();
					break;
				case TargetType.AnyMonster:
					if (EntityManager.MinionsAndMonsters.Monsters.Any(u => !u.IsDead && u.Distance(fromPos) <= range))
						spell.Cast();
					break;
			}

		}
		public static void ResetAttackForLasthit(this Spell.Active spell)
		{
			var target =
				EntityManager.MinionsAndMonsters.Minions.FirstOrDefault(
					u => Prediction.Health.GetPrediction(u, spell.CastDelay) <= 10 && !Orbwalker.CanAutoAttack);
			if (target == null) return;
			Orbwalker.ForcedTarget = target;
			spell.Cast();
			Core.DelayAction(() => Orbwalker.ForcedTarget = null, 250);
		}

		public static void CastOnMinHealth(this Spell.Active spell, int minHealthPercent)
		{
			if (!spell.IsReady())
				return;
			if (Champions.Me.HealthPercent <= minHealthPercent)
				spell.Cast();
		}

		internal static ProdictResult GetProdiction(this Spell.Skillshot spell, Obj_AI_Base unit, Obj_AI_Base fromUnit, CollisionType colltype)
		{
			IEnumerable<Obj_AI_Base> ColObjects = null;
			var HitChance = EloBuddy.SDK.Enumerations.HitChance.High;
			if (fromUnit == null)
				fromUnit = ObjectManager.Player;
			var UnitPosition = PositionAfterTime(unit, 1, unit.MoveSpeed - 135);
			var PredictedPosition = UnitPosition.To2D() + spell.Speed
							* (unit.Direction.To2D().Perpendicular().Normalized() / 2f * (spell.CastDelay / 1000))
							* spell.Width / fromUnit.Distance(unit);
			var FixedPredictedPosition = fromUnit.ServerPosition.Extend(PredictedPosition.To3D(), fromUnit.Distance(unit));
			if (unit.HasBuffOfType(BuffType.Stun) || unit.HasBuffOfType(BuffType.Snare))
				HitChance = HitChance.Immobile;
			var SpellTravelTime = fromUnit.Distance(FixedPredictedPosition) / spell.Speed * 1000 + spell.CastDelay / 1000;
			var PositionOnTravelEnd = PositionAfterTime(unit, SpellTravelTime, unit.MoveSpeed);
			if (fromUnit.Distance(PositionOnTravelEnd) >= spell.Range - unit.BoundingRadius || fromUnit.Distance(FixedPredictedPosition) >= spell.Range - unit.BoundingRadius)
				HitChance = HitChance.Impossible;

			ColObjects = GetCollision(fromUnit.Position, FixedPredictedPosition.To3D(), spell.Width, unit, colltype);
			HitChance = ColObjects.Any() ? HitChance.Collision : HitChance;

			return new ProdictResult()
			{
				isValid = unit.Distance(FixedPredictedPosition.To3D()) <= 500,
				UnitPosition = UnitPosition,
				CastPosition = FixedPredictedPosition.To3D(),
				Hitchance = HitChance,
				CollisionObjects = ColObjects
			};
		}

		public static IEnumerable<Obj_AI_Base> GetCollision(Vector3 from, Vector3 to, float width, Obj_AI_Base unit, CollisionType coltype)
		{
			switch (coltype)
			{
				case CollisionType.None:
					return ObjectManager.Get<Obj_AI_Base>().Where(u => false).ToList();
				case CollisionType.Basic:
					return ObjectManager.Get<Obj_AI_Base>().Where(u => !u.IsDead && !u.IsAlly && !u.IsMe && 
																	   u.IsValidTarget(from.Distance(to) + 10) &&
																	   (u.IsMinion || u.IsMonster ||
																		u.Type == GameObjectType.AIHeroClient) &&
																		((unit == null) || u.NetworkId != unit.NetworkId) &&
																	   (width + u.BoundingRadius - u.Position.To2D().Distance(from.To2D(), to.To2D(), false, false) > 0)).OrderBy(u => u.Distance(Champions.Me));
				case CollisionType.EnemyHeros:
					return EntityManager.Heroes.Enemies.Where(u => !u.IsDead && !u.IsAlly && !u.IsMe &&
																	   u.IsValidTarget(from.Distance(to) + 10) &&
																	   u.Type == GameObjectType.AIHeroClient &&
																	   ((unit == null) || u.NetworkId != unit.NetworkId) &&
																	   (width + u.BoundingRadius - u.Position.To2D().Distance(from.To2D(), to.To2D(), false, false) > 0)).OrderBy(u => u.Distance(Champions.Me));
			}
			return ObjectManager.Get<Obj_AI_Base>().Where(u => false).ToList();
		}

		internal static Vector3 PositionAfterTime(Obj_AI_Base unit, float time, float speed = float.MaxValue)
		{
			var traveldistance = time * speed;
			var path = unit.Path;
			for (var i = 0; i < path.Count() - 1; i++)
			{
				var from = path[i];
				var to = path[i + 1];
				var distance = from.Distance(to);

				if (distance < traveldistance)
					traveldistance -= distance;
				else
					return (from + traveldistance * (to - from).Normalized());
			}

			return path[path.Count() - 1];
		}
		internal class ProdictResult
		{
			public bool isValid { get; set; }
			public Vector3 UnitPosition { get; set; }
			public Vector3 CastPosition { get; set; }
			public HitChance Hitchance { get; set; }
			public IEnumerable<Obj_AI_Base> CollisionObjects { get; set; }
		}
	}
}
