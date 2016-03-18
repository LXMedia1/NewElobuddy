using System.Collections.Generic;
using EloBuddy;

namespace CarryMe_Activator.DB
{
	internal class SmiteSpell
	{
		public float CastRange;
		public string Name;
		public SpellSlot Slot;

		public List<SmiteSpell> SpellList = new List<SmiteSpell>
		{
			new SmiteSpell
			{
				Name = "DrMundo",
				CastRange = 500f,
				Stage = 0,
				Type = SpellDataTargetType.Location,
				Slot = SpellSlot.Q
			},
			new SmiteSpell
			{
				Name = "Ekko",
				CastRange = 425f,
				Stage = 0,
				Type = SpellDataTargetType.SelfAndUnit,
				Slot = SpellSlot.E
			},
			new SmiteSpell
			{
				Name = "Rengar",
				CastRange = 150f,
				Stage = ObjectManager.Player.Mana > 4 ? 1 : 0,
				Type = SpellDataTargetType.SelfAndUnit,
				Slot = SpellSlot.Q
			},
			new SmiteSpell
			{
				Name = "Wukong",
				CastRange = 305f,
				Stage = 0,
				Type = SpellDataTargetType.SelfAndUnit,
				Slot = SpellSlot.Q
			},
			new SmiteSpell
			{
				Name = "Quinn",
				CastRange = 675f,
				Stage = 0,
				Type = SpellDataTargetType.Unit,
				Slot = SpellSlot.E
			},
			new SmiteSpell
			{
				Name = "Fiora",
				CastRange = 375f,
				Stage = 0,
				Type = SpellDataTargetType.Location,
				Slot = SpellSlot.Q
			},
			new SmiteSpell
			{
				Name = "Nidalee",
				CastRange = 375f,
				Stage = 1,
				Type = SpellDataTargetType.SelfAndUnit,
				Slot = SpellSlot.Q
			},
			new SmiteSpell
			{
				Name = "Alistar",
				CastRange = 350f,
				Stage = 0,
				Type = SpellDataTargetType.Self,
				Slot = SpellSlot.Q
			},
			new SmiteSpell
			{
				Name = "FiddleSticks",
				CastRange = 750f,
				Slot = SpellSlot.E,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "JarvanIV",
				CastRange = 770f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Location
			},
			new SmiteSpell
			{
				Name = "Twitch",
				CastRange = 950f,
				Slot = SpellSlot.E,
				Stage = 0,
				Type = SpellDataTargetType.Self
			},
			new SmiteSpell
			{
				Name = "Riven",
				CastRange = 150f,
				Slot = SpellSlot.W,
				Stage = 0,
				Type = SpellDataTargetType.Self
			},
			new SmiteSpell
			{
				Name = "Malphite",
				CastRange = 200f,
				Slot = SpellSlot.E,
				Stage = 0,
				Type = SpellDataTargetType.Self
			},
			new SmiteSpell
			{
				Name = "Nunu",
				CastRange = 200f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Olaf",
				CastRange = 325f,
				Slot = SpellSlot.E,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Elise",
				CastRange = 475f,
				Slot = SpellSlot.Q,
				Stage = 1,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Warwick",
				CastRange = 400f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Trundle",
				CastRange = 180f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.SelfAndUnit
			},
			new SmiteSpell
			{
				Name = "MasterYi",
				CastRange = 600f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Kayle",
				CastRange = 650f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Khazix",
				CastRange = 325f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "MonkeyKing",
				CastRange = 300f,
				Slot = SpellSlot.E,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Darius",
				CastRange = 425f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Self
			},
			new SmiteSpell
			{
				Name = "Diana",
				CastRange = 825f,
				Slot = SpellSlot.R,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Fizz",
				CastRange = 550f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Evelynn",
				CastRange = 225f,
				Slot = SpellSlot.E,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Maokai",
				CastRange = 600f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Location
			},
			new SmiteSpell
			{
				Name = "Nocturne",
				CastRange = 500f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Location
			},
			new SmiteSpell
			{
				Name = "Pantheon",
				CastRange = 600f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Volibear",
				CastRange = 400f,
				Slot = SpellSlot.W,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Vi",
				CastRange = 125f,
				Slot = SpellSlot.E,
				Stage = 0,
				Type = SpellDataTargetType.SelfAndUnit
			},
			new SmiteSpell
			{
				Name = "Tryndamere",
				CastRange = 400f,
				Slot = SpellSlot.E,
				Stage = 0,
				Type = SpellDataTargetType.Location
			},
			new SmiteSpell
			{
				Name = "Zac",
				CastRange = 550f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Location
			},
			new SmiteSpell
			{
				Name = "Shen",
				CastRange = 475f,
				Slot = SpellSlot.Q,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "XinZhao",
				CastRange = 600f,
				Slot = SpellSlot.E,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			},
			new SmiteSpell
			{
				Name = "Amumu",
				CastRange = 350f,
				Slot = SpellSlot.E,
				Stage = 0,
				Type = SpellDataTargetType.Self
			},
			new SmiteSpell
			{
				Name = "LeeSin",
				CastRange = 1300f,
				Slot = SpellSlot.Q,
				Stage = 1,
				Type = SpellDataTargetType.Self
			},
			new SmiteSpell
			{
				Name = "Chogath",
				CastRange = 175 + new[] {23f, 37f, 50f}[ObjectManager.Player.Level/6],
				Slot = SpellSlot.R,
				Stage = 0,
				Type = SpellDataTargetType.Unit
			}
		};

		public int Stage;
		public SpellDataTargetType Type;

		public bool IsSpellConditionReady(Obj_AI_Base unit)
		{
			if (unit == null)
				return false;

			switch (ObjectManager.Player.Hero)
			{
				case Champion.Diana:
					return unit.HasBuff("dianamoonlight");
				case Champion.Elise:
					return ObjectManager.Player.CharData.BaseSkinName == "elisespider";
				case Champion.LeeSin:
					return unit.HasBuff("blindmonkqonechaos");
				case Champion.Nidalee:
					return ObjectManager.Player.CharData.BaseSkinName != "Nidalee";
				case Champion.Twitch:
					return unit.HasBuff("twitchdeadlyvenom");
			}
			return true;
		}
	}
}