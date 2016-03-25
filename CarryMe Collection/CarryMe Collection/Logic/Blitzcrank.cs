using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarryMe_Collection.Basics;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using MenuBuilder = CarryMe_Collection.Basics.MenuBuilder;

namespace CarryMe_Collection.Logic
{
	internal class Blitzcrank : Champion
	{
		public Menu ComboMenu;

		public static Spell.Skillshot Q = new Spell.Skillshot(SpellSlot.Q, 950, SkillShotType.Linear, 250, 1750, 70);

		internal override void WriteMenuStart()
		{
			base.WriteMenuStart();

			ComboMenu = Config.AddSubMenu(MenuBuilder.MenuName.Combo);
			ComboMenu.AddCheckBox("use.Q", "Use Q");
		}

		internal override void OnCombo()
		{
			if (ComboMenu.IsChecked("use.Q"))
				Q.CastLogicLinearBasic(CastLogics.CollisionType.Basic, CastLogics.TargetType.Enemy, DamageType.Physical);
		}

	}
}
