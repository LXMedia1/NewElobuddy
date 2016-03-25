using System;
using System.Collections.Generic;
using System.Linq;
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
		}


		public static void CastLogicLinearBasic(this Spell.Skillshot spell, CollisionType collision, TargetType TargetType, DamageType damagetype)
		{
			if (!spell.IsReady())
				return;
			switch (TargetType)
			{
				case TargetType.Enemy:
					var target = TargetSelector.GetTarget(spell.Range, damagetype);
					if (target == null)
						return;
					var pred = spell.GetProdiction(target, null, collision);
					if (pred.Hitchance >= HitChance.High && pred.isValid)
						spell.Cast(pred.CastPosition);
					break;
				case TargetType.MinionLasthit:
					var PossibleTargets = EntityManager.MinionsAndMonsters.EnemyMinions.Where(
							u => u.IsValidTarget(spell.Range) && u.Health <= Champions.Me.GetDamageSpell(u, spell.Slot) && !Champions.Me.IsInAutoAttackRange(u));
					foreach (var eventualtarget in from eventualtarget in PossibleTargets let minioncoll = GetBasicCollisionObjects(Champions.Me.Position, eventualtarget.Position, spell.Width, eventualtarget) where !minioncoll.Any() select eventualtarget)
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
						var minioncoll = GetBasicCollisionObjects(Champions.Me.Position, strongestMinion.Position, spell.Width, strongestMinion);
						if (!minioncoll.Any())
							spell.Cast(strongestMinion.Position);
					}
					break;
				case TargetType.MonsterLastHit:
					var PossibleMonsterTargets = EntityManager.MinionsAndMonsters.Monsters.Where(
							u => u.IsValidTarget(spell.Range) && u.Health <= Champions.Me.GetDamageSpell(u, spell.Slot));
					foreach (var eventualtarget in from eventualtarget in PossibleMonsterTargets let minioncoll = GetBasicCollisionObjects(Champions.Me.Position, eventualtarget.Position, spell.Width, eventualtarget) where !minioncoll.Any() select eventualtarget)
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
						var minioncoll = GetBasicCollisionObjects(Champions.Me.Position, strongestMonster.Position, spell.Width, strongestMonster);
						if (!minioncoll.Any())
							spell.Cast(strongestMonster.Position);
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
		public static void AfterAttackLogic(this Spell.Active spell,AttackableUnit target, TargetType TargetType)
		{
			if (!spell.IsReady())
				return;
			switch (TargetType)
			{
				case TargetType.AnyEnemy:
					if (target.Type == GameObjectType.AIHeroClient)
					{
						var enemytarget = (AIHeroClient) target;
						if (enemytarget.Health - Champions.Me.GetAutoAttackDamage(enemytarget) > 0) 
						{
							Orbwalker.ForcedTarget = enemytarget;
							spell.Cast();
							Core.DelayAction(() => Orbwalker.ForcedTarget = null,250);
						}
						else
						{
							var switchtarget =EntityManager.Heroes.Enemies.FirstOrDefault(u => !u.IsDead && u.NetworkId != enemytarget.NetworkId && u.IsValidTarget(spell.Range));
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
						if (enemytarget.Health - Champions.Me.GetAutoAttackDamage(enemytarget) > 0 && enemytarget.Health < Champions.Me.GetAutoAttackDamage(enemytarget) + Champions.Me.GetDamageSpell(enemytarget,spell.Slot))
						{
							Orbwalker.ForcedTarget = enemytarget;
							spell.Cast();
							Core.DelayAction(() => Orbwalker.ForcedTarget = null, 250);
						}
						else
						{
							var switchtarget = EntityManager.Heroes.Enemies.FirstOrDefault(u => !u.IsDead && u.NetworkId != enemytarget.NetworkId && u.IsValidTarget(spell.Range) && enemytarget.Health < Champions.Me.GetDamageSpell(enemytarget,spell.Slot));
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
						if (enemytarget.Health - Champions.Me.GetAutoAttackDamage(enemytarget) > 0 )
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
			if (spell.AllowedCollisionCount < 0)
				return new ProdictResult()
				{
					isValid = unit.Distance(FixedPredictedPosition.To3D()) <= 500,
					UnitPosition = UnitPosition,
					CastPosition = FixedPredictedPosition.To3D(),
					Hitchance = HitChance,
					CollisionObjects = null
				};
			if (colltype == CollisionType.Basic)
			{
				ColObjects = GetBasicCollisionObjects(fromUnit.Position, FixedPredictedPosition.To3D(), spell.Width, unit);
				HitChance = ColObjects.Any() ? HitChance.Collision : HitChance;
			}
			return new ProdictResult()
			{
				isValid = unit.Distance(FixedPredictedPosition.To3D()) <= 500,
				UnitPosition = UnitPosition,
				CastPosition = FixedPredictedPosition.To3D(),
				Hitchance = HitChance,
				CollisionObjects = ColObjects
			};
		}
		public static IEnumerable<Obj_AI_Base> GetBasicCollisionObjects(Vector3 fromPos, Vector3 to, int width, Obj_AI_Base unit)
		{
			var Objectlist = ObjectManager.Get<Obj_AI_Base>().Where(u => !u.IsAlly && !u.IsDead && u.IsValidTarget(fromPos.Distance(to) + 10) && (u.IsMinion || u.IsMonster || u.Type == GameObjectType.AIHeroClient) && unit.NetworkId != u.NetworkId);
			return (from obj in Objectlist let rec = new Geometry.Polygon.Rectangle(fromPos.To2D(), to.To2D(), width + obj.BoundingRadius * 2) where rec.IsInside(obj) && obj != ObjectManager.Player select obj).ToList();
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
					return (from + traveldistance*(to - from).Normalized());
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
