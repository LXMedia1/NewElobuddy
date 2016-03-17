using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace CarryMe_Blitzcrank.Basics
{
	public static class Prodiction
	{
		internal static ProdictResult GetProdiction(this Spell.Skillshot spell,Obj_AI_Base unit, Obj_AI_Base fromUnit = null)
		{
			var HitChance = EloBuddy.SDK.Enumerations.HitChance.High;
			if (fromUnit == null)
			{
				fromUnit = ObjectManager.Player;
			}

			var UnitPosition =PositionAfterTime(unit,1, unit.MoveSpeed -135);
			var PredictedPosition = UnitPosition.To2D() + spell.Speed
							* (unit.Direction.To2D().Perpendicular().Normalized() / 2f * (spell.CastDelay / 1000))
							* spell.Width / fromUnit.Distance(unit);
			var FixedPredictedPosition = fromUnit.ServerPosition.Extend(PredictedPosition.To3D(), fromUnit.Distance(unit));
			if (unit.HasBuffOfType(BuffType.Stun) || unit.HasBuffOfType(BuffType.Snare))
				HitChance = HitChance.Immobile;
			var SpellTravelTime = fromUnit.Distance(FixedPredictedPosition) / spell.Speed * 1000 + spell.CastDelay / 1000;

			var PositionOnTravelEnd = PositionAfterTime(unit, SpellTravelTime, unit.MoveSpeed);
			if (fromUnit.Distance(PositionOnTravelEnd) >= spell.Range -unit.BoundingRadius|| fromUnit.Distance(FixedPredictedPosition) >= spell.Range - unit.BoundingRadius)
				HitChance = HitChance.Impossible;
			if (spell.AllowedCollisionCount < 0)
				return new ProdictResult()
				{
					UnitPosition = UnitPosition,
					CastPosition = FixedPredictedPosition.To3D(),
					Hitchance = HitChance,
					CollisionObjects = null
				};
			
			var ColObjects = CollisionObjects(fromUnit.Position, FixedPredictedPosition.To3D(), spell.Width);
			if (spell.AllowedCollisionCount == 0)
				ColObjects = Filter(ColObjects, CollisionMode.BasicCollision, unit);
			HitChance = ColObjects.Any() ? HitChance.Collision : HitChance;

			return new ProdictResult()
			{
				UnitPosition = UnitPosition,
				CastPosition = FixedPredictedPosition.To3D(),
				Hitchance = HitChance,
				CollisionObjects = ColObjects
			};

		}
		private static IEnumerable<Obj_AI_Base> Filter(IEnumerable<Obj_AI_Base> ColObjects, CollisionMode collisionMode, Obj_AI_Base unit)
		{
			switch (collisionMode)
			{
				case CollisionMode.BasicCollision:
					return ColObjects.Where(u => !u.IsDead && !u.IsAlly && !u.IsStructure() && (u.IsMinion || u.IsMonster) && unit.NetworkId != u.NetworkId);
			}
			return ColObjects;
		}
		private static IEnumerable<Obj_AI_Base> Filter(IEnumerable<Obj_AI_Base> ColObjects, CollisionMode collisionMode)
		{
			switch (collisionMode)
			{
					case CollisionMode.BasicCollision:
					return ColObjects.Where(u => !u.IsDead && !u.IsAlly && !u.IsStructure() && (u.IsMinion || u.IsMonster));
			} 
			return ColObjects;
		}

		public enum CollisionMode
		{
			BasicCollision
		}
		public static IEnumerable<Obj_AI_Base> CollisionObjects(Vector3 fromPos, Vector3 to, int width)
		{
			return (from obj in ObjectManager.Get<Obj_AI_Base>()
					let rec = new Geometry.Polygon.Rectangle(fromPos.To2D(), to.To2D(), width + obj.BoundingRadius * 2)
					where rec.IsInside(obj) && obj != ObjectManager.Player
					select obj).ToList();
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
				{
					traveldistance -= distance;
				}
				else
				{
					return (from + traveldistance * (to - from).Normalized());
				}
			}

			return path[path.Count() - 1];
		}

		internal class ProdictResult
		{

			public Vector3 UnitPosition { get; set; }

			public Vector3 CastPosition { get; set; }

			public HitChance Hitchance { get; set; }

			public IEnumerable<Obj_AI_Base> CollisionObjects { get; set; }
		}
	}
}
