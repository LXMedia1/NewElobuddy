using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace Lexxers_Private_Orbwalker
{
	public static class  Prodiction
	{
		public enum CollisionType
		{
			Basic,
			None,
			EnemyHeros,
		}

		public static Vector3 GetMovementPrediction(this Obj_AI_Base unit)
		{
			var UnitPosition = PositionAfterTime(unit, 1, unit.MoveSpeed - 135);
			var PredictedPosition = UnitPosition.To2D() + ObjectManager.Player.MoveSpeed
							* (unit.Direction.To2D().Perpendicular().Normalized() / 2 * .1f)
							* 100 / ObjectManager.Player.Distance(unit);
			return unit.Position.V3E(PredictedPosition.To3D(), ObjectManager.Player.AttackRange);
		}

		public static ProdictResult GetProdiction(this Spell.Skillshot spell, Obj_AI_Base unit, Obj_AI_Base fromUnit, CollisionType colltype)
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
																	   (width + u.BoundingRadius - u.Position.To2D().Distance(from.To2D(), to.To2D(), false, false) > 0)).OrderBy(u => u.Distance(ObjectManager.Player));
				case CollisionType.EnemyHeros:
					return EntityManager.Heroes.Enemies.Where(u => !u.IsDead && !u.IsAlly && !u.IsMe &&
																	   u.IsValidTarget(from.Distance(to) + 10) &&
																	   u.Type == GameObjectType.AIHeroClient &&
																	   ((unit == null) || u.NetworkId != unit.NetworkId) &&
																	   (width + u.BoundingRadius - u.Position.To2D().Distance(from.To2D(), to.To2D(), false, false) > 0)).OrderBy(u => u.Distance(ObjectManager.Player));
			}
			return ObjectManager.Get<Obj_AI_Base>().Where(u => false).ToList();
		}
		public static Vector3 PositionAfterTime(Obj_AI_Base unit, float time, float speed = float.MaxValue)
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
		public static bool IsWithinDistance(this Obj_AI_Base unit, float min, float max)
		{
			var distance = ObjectManager.Player.Distance(unit);
			return min <= distance && distance <= max;
		}
		public static Vector2 V2E(this Vector3 from, Vector3 direction, float distance)
		{
			return from.To2D() + distance * Vector3.Normalize(direction - from).To2D();
		}
		public static Vector3 V3E(this Vector3 from, Vector3 direction, float distance)
		{
			return from + distance * Vector3.Normalize(direction - from);
		}
		public class ProdictResult
		{
			public bool isValid { get; set; }
			public Vector3 UnitPosition { get; set; }
			public Vector3 CastPosition { get; set; }
			public EloBuddy.SDK.Enumerations.HitChance Hitchance { get; set; }
			public IEnumerable<Obj_AI_Base> CollisionObjects { get; set; }
		}
	}
}
