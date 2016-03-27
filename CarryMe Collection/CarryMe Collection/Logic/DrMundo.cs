using System;
using System.Configuration;
using System.Linq;
using CarryMe_Collection.Basics;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;

namespace CarryMe_Collection.Logic
{
	class DrMundo : Champion
	{
		public Menu ComboMenu;
		public Menu HarrasMenu;
		public Menu LaneClearMenu;
		public Menu LasthitMenu;
		public Menu JungleClearMenu;
		public Menu FleeMenu;
		public Menu PassiveMenu;
		public Menu DrawMenu;

		public static Spell.Skillshot Q = new Spell.Skillshot(SpellSlot.Q, 1000, SkillShotType.Linear, 250, 1850, 60);
		public static Spell.Active W = new Spell.Active(SpellSlot.W, 325);
		public static Spell.Active E = new Spell.Active(SpellSlot.E,290);
		public static Spell.Active R = new Spell.Active(SpellSlot.R);
		internal override void WriteMenuStart()
		{
			base.WriteMenuStart();

			ComboMenu = Config.AddSubMenu(MenuBuilder.MenuName.Combo);
			ComboMenu.AddCheckBox("use.Q", "Use Q on Enemy");
			ComboMenu.AddCheckBox("use.W", "Use W if Enemy near");
			ComboMenu.AddCheckBox("use.E.forAAReset", "Use E For AA-Reset");

			HarrasMenu = Config.AddSubMenu(MenuBuilder.MenuName.Harras);
			HarrasMenu.AddCheckBox("use.Q", "Use Q on Enemy");
			HarrasMenu.AddCheckBox("use.Q.Lasthit", "Use Q for Lasthit Minion");
			HarrasMenu.AddCheckBox("use.W", "Use W if Enemy near");
			HarrasMenu.AddCheckBox("use.E.forAAReset", "Use E For AA-Reset On Enemy");
			HarrasMenu.AddCheckBox("use.E.Lasthit", "Use E to Safe Lasthit");

			LasthitMenu = Config.AddSubMenu(MenuBuilder.MenuName.LastHit);
			LasthitMenu.AddCheckBox("use.Q.Lasthit", "Use Q for Lasthit Minion");

			LaneClearMenu = Config.AddSubMenu(MenuBuilder.MenuName.LaneClear);
			LaneClearMenu.AddCheckBox("use.Q.Lasthit", "Use Q for Lasthit Minion");
			LaneClearMenu.AddCheckBox("use.Q.strongest", "Use Q on Strongest Minion");
			LaneClearMenu.AddCheckBox("use.W", "Use W if Minion near");
			LaneClearMenu.AddCheckBox("use.E.Lasthit", "Use E on Minion Lasthit");
			LaneClearMenu.AddCheckBox("use.E.Any", "Use E on Any Minion");

			JungleClearMenu = Config.AddSubMenu(MenuBuilder.MenuName.JungleClear);
			JungleClearMenu.AddCheckBox("use.Q.Lasthit", "Use Q for Lasthit Monster");
			JungleClearMenu.AddCheckBox("use.Q.strongest", "Use Q on Strongest Monster");
			JungleClearMenu.AddCheckBox("use.W", "Use W if Monster near");
			JungleClearMenu.AddCheckBox("use.E.Lasthit", "Use E on Minion Lasthit");
			JungleClearMenu.AddCheckBox("use.E.Any", "Use E on Any Minion");

			FleeMenu = Config.AddSubMenu(MenuBuilder.MenuName.Flee);
			FleeMenu.AddCheckBox("use.Q.nearst", "Use Q On Nearst Enemy");

			PassiveMenu = Config.AddSubMenu(MenuBuilder.MenuName.Passive);
			PassiveMenu.AddLabel("Additional W Settings ( dont touch if you have no Idea what you are doing )");
			PassiveMenu.AddSlider("W.disableRangeEnemy", "Disable W if no Enemy within Distance: {0} ", 600, 325, 900);
			PassiveMenu.AddSlider("W.disableRangeMinion", "Disable W if no Minion within Distance: {0} ", 500, 325, 900);
			PassiveMenu.AddSlider("W.disableRangeMonster", "Disable W if no Monster within Distance: {0} ", 500, 325, 900);
			PassiveMenu.AddLabel("Additional E Settings ( dont touch if you have no Idea what you are doing )");
			PassiveMenu.AddCheckBox("use.E.Wards", "Use E to Remove Wards");
			PassiveMenu.AddCheckBox("use.E.Objects", "Use E on (Tower,Inhib,Base)");
			PassiveMenu.AddLabel("Additional R Settings ( dont touch if you have no Idea what you are doing )");
			PassiveMenu.AddSlider("use.R.minHealth", "Use R On {0} % Health",25);
			DrawMenu = Config.AddSubMenu(MenuBuilder.MenuName.Drawing);
			var checkbox = DrawMenu.AddCheckBox("draw.Q.range", "Draw Q Range");
			new Drawer.DrawRange(Q ,checkbox);
			checkbox = DrawMenu.AddCheckBox("draw.W.range", "Draw W Range");
			new Drawer.DrawRange(W, checkbox);
			checkbox = DrawMenu.AddCheckBox("draw.E.range", "Draw E Range");
			new Drawer.DrawRange(E, checkbox);
		}

	

		internal override void OnCombo()
		{
			if (ComboMenu.IsChecked("use.Q"))
				Q.CastLogicLinearBasic(CastLogics.CollisionType.Basic,CastLogics.TargetType.Enemy,DamageType.Magical);
			if (ComboMenu.IsChecked("use.W"))
				W.ActivateAuraLogic(CastLogics.TargetType.AnyEnemy);
		}

		internal override void OnHarass()
		{
			if (HarrasMenu.IsChecked("use.Q"))
				Q.CastLogicLinearBasic(CastLogics.CollisionType.Basic, CastLogics.TargetType.Enemy, DamageType.Magical);
			if (HarrasMenu.IsChecked("use.Q.Lasthit"))
				Q.CastLogicLinearBasic(CastLogics.CollisionType.Basic, CastLogics.TargetType.MinionLasthit, DamageType.Magical);
			if (HarrasMenu.IsChecked("use.W"))
				W.ActivateAuraLogic(CastLogics.TargetType.AnyEnemy);
		}

		internal override void OnLastHit()
		{
			if (LasthitMenu.IsChecked("use.Q.Lasthit"))
				Q.CastLogicLinearBasic(CastLogics.CollisionType.Basic, CastLogics.TargetType.MinionLasthit, DamageType.Magical);
		}

		internal override void OnLaneClear()
		{
			if (LaneClearMenu.IsChecked("use.Q.Lasthit"))
				Q.CastLogicLinearBasic(CastLogics.CollisionType.Basic, CastLogics.TargetType.MinionLasthit, DamageType.Magical);
			if (LaneClearMenu.IsChecked("use.Q.strongest"))
				Q.CastLogicLinearBasic(CastLogics.CollisionType.Basic, CastLogics.TargetType.MinionStrongest, DamageType.Magical);
			if (LaneClearMenu.IsChecked("use.W"))
				W.ActivateAuraLogic(CastLogics.TargetType.AnyEnemyMinions);
		}

		internal override void OnJungleClear()
		{
			if (JungleClearMenu.IsChecked("use.Q.Lasthit"))
				Q.CastLogicLinearBasic(CastLogics.CollisionType.Basic, CastLogics.TargetType.MonsterLastHit, DamageType.Magical);
			if (JungleClearMenu.IsChecked("use.Q.strongest"))
				Q.CastLogicLinearBasic(CastLogics.CollisionType.Basic, CastLogics.TargetType.MonsterStrongest, DamageType.Magical);
			if (JungleClearMenu.IsChecked("use.W"))
				W.ActivateAuraLogic(CastLogics.TargetType.AnyMonster);
		}

		internal override void OnFlee()
		{
			if (FleeMenu.IsChecked("use.Q.nearst"))
				Q.CastLogicLinearBasic(CastLogics.CollisionType.Basic, CastLogics.TargetType.NearstEnemy, DamageType.Magical);
		}

		internal override void OnPassive()
		{
			W.DisableAuraLogic(PassiveMenu.GetValue("W.disableRangeEnemy"),
				PassiveMenu.GetValue("W.disableRangeMinion"),
				PassiveMenu.GetValue("W.disableRangeMonster"));
			R.CastOnMinHealth(PassiveMenu.GetValue("use.R.minHealth"));
		}

		internal override void OnAfterAttack(AttackableUnit target, EventArgs args)
		{
			if (ComboMenu.IsChecked("use.E.forAAReset") && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
				E.AfterAttackLogic(target, CastLogics.TargetType.AnyEnemy);
			if (HarrasMenu.IsChecked("use.E.forAAReset") && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
				E.AfterAttackLogic(target, CastLogics.TargetType.AnyEnemy);
			if (LaneClearMenu.IsChecked("use.E.Lasthit") && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
				E.AfterAttackLogic(target, CastLogics.TargetType.MinionLasthit);
			if (LaneClearMenu.IsChecked("use.E.Any") && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
				E.AfterAttackLogic(target, CastLogics.TargetType.AnyEnemyMinions);
			if (JungleClearMenu.IsChecked("use.E.Lasthit") && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
				E.AfterAttackLogic(target, CastLogics.TargetType.MonsterLastHit);
			if (JungleClearMenu.IsChecked("use.E.Any") && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
				E.AfterAttackLogic(target, CastLogics.TargetType.AnyMonster);
			if (PassiveMenu.IsChecked("use.E.Wards"))
				E.AfterAttackLogic(target, CastLogics.TargetType.Wards);
			if (PassiveMenu.IsChecked("use.E.Objects"))
				E.AfterAttackLogic(target, CastLogics.TargetType.Objects);
		}
	}
}
