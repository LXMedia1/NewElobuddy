using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarryMe_Collection.Basics;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using SharpDX;
using SharpDX.XInput;
using MenuBuilder = CarryMe_Collection.Basics.MenuBuilder;

namespace CarryMe_Collection.Logic
{
	internal class Shen : Champion
	{
		public Menu ComboMenu;
		public Menu HarrasMenu;
		public Menu LaneClearMenu;
		public Menu JungleClearMenu;
		public Menu PassiveMenu;
		public Menu DrawMenu;

		public Spell.Active Q = new Spell.Active(SpellSlot.Q, 200);
		public Spell.Active W = new Spell.Active(SpellSlot.W, 400);
		public Spell.Skillshot E = new Spell.Skillshot(SpellSlot.E, 600, SkillShotType.Linear, 0, 1600, 50);
		public Spell.Targeted R = new Spell.Targeted(SpellSlot.R,10000000);

		internal override void WriteMenuStart()
		{
			base.WriteMenuStart();

			ComboMenu = Config.AddSubMenu(MenuBuilder.MenuName.Combo);
			ComboMenu.AddCheckBox("use.Q.ifCollidewithEnemy", "Use Q if hit Enemy");
			ComboMenu.AddCheckBox("use.Q.range", "Use Q to get higher Range",false);
			ComboMenu.AddCheckBox("use.E", "Use E on Enemy Predicted Position");

			HarrasMenu = Config.AddSubMenu(MenuBuilder.MenuName.Harras);
			HarrasMenu.AddCheckBox("use.Q.ifCollidewithEnemy", "Use Q if hit Enemy");
			HarrasMenu.AddCheckBox("use.Q.range", "Use Q to get higher Range");
			HarrasMenu.AddCheckBox("use.E", "Use E on Enemy Predicted Position");

			LaneClearMenu = Config.AddSubMenu(MenuBuilder.MenuName.LaneClear);
			LaneClearMenu.AddCheckBox("use.Q", "Use Q");

			JungleClearMenu = Config.AddSubMenu(MenuBuilder.MenuName.JungleClear);
			JungleClearMenu.AddCheckBox("use.Q", "Use Q");
			JungleClearMenu.AddCheckBox("use.E", "Use E");

			PassiveMenu = Config.AddSubMenu(MenuBuilder.MenuName.Passive);
			PassiveMenu.AddLabel("Additional W Settings ( dont touch if you have no Idea what you are doing )");
			PassiveMenu.AddCheckBox("use.W.ego", "Use W to Block AA on You");
			PassiveMenu.AddCheckBox("use.W.buddy", "Use W to Block AA on Buddy");
			PassiveMenu.AddCheckBox("use.W.monster", "Use W to Block AA from Monsters");
			PassiveMenu.AddCheckBox("use.W.minion", "Use W to Block AA from Minions");
			PassiveMenu.AddLabel("Additional E Settings ( dont touch if you have no Idea what you are doing )");
			PassiveMenu.AddCheckBox("use.E.intower.combo", "Combo: Not in Towerrange",false);
			PassiveMenu.AddCheckBox("use.E.intower.harass", "Harras: Not in Towerrange");
			PassiveMenu.AddLabel("Additional R Settings ( dont touch if you have no Idea what you are doing )");
			PassiveMenu.AddSlider("use.R.belowHealth", "Use R on Buddys Below {0}% Health", 20);
			PassiveMenu.AddSlider("use.R.myHealth", "Use R if MyHealth > incomeEnemys * {0}% ", 10,0,20);
			PassiveMenu.AddSlider("use.R.distance", "1) Use R no Enemys in {0} Distance", 800, 0, 1500);
			PassiveMenu.AddSlider("use.R.distance2", "2) Use R if im near Buddy", 800, 0, 1500);
			PassiveMenu.AddHeroList("use.R.on", "Use On", MenuBuilder.Champlist.BuddyWithoutMe);

			DrawMenu = Config.AddSubMenu(MenuBuilder.MenuName.Drawing);
			var checkbox = DrawMenu.AddCheckBox("draw.E.range", "Draw E Range");
			new Drawer.DrawRange(E, checkbox);
		}

		internal override void OnCombo()
		{
			if (ComboMenu.IsChecked("use.Q.ifCollidewithEnemy"))
				Q.CastifBetween(CastLogics.TargetType.AnyEnemy,GetSwordPos(), Champions.Me.Position, 50);
			if (ComboMenu.IsChecked("use.Q.range"))
				Q.CastIfInRange(CastLogics.TargetType.AnyEnemy, Q.Range, Champions.Me.Position);
			if (ComboMenu.IsChecked("use.E"))
				E.CastLogicLinearExtendedRange(CastLogics.CollisionType.None, PassiveMenu.IsChecked("use.E.intower.combo") ? CastLogics.TargetType.EnemynotNearTower : CastLogics.TargetType.Enemy, DamageType.Physical, Champions.Me.GetAutoAttackRange());
		}

		internal override void OnHarass()
		{
			if (HarrasMenu.IsChecked("use.Q.ifCollidewithEnemy"))
				Q.CastifBetween(CastLogics.TargetType.AnyEnemy, GetSwordPos(), Champions.Me.Position, 50);
			if (HarrasMenu.IsChecked("use.Q.range"))
				Q.CastIfInRange(CastLogics.TargetType.AnyEnemy, Q.Range, Champions.Me.Position);
			if (HarrasMenu.IsChecked("use.E"))
				E.CastLogicLinearExtendedRange(CastLogics.CollisionType.None, PassiveMenu.IsChecked("use.E.intower.harass") ? CastLogics.TargetType.EnemynotNearTower : CastLogics.TargetType.Enemy, DamageType.Physical, Champions.Me.GetAutoAttackRange());
		}

		internal override void OnLaneClear()
		{
			if (LaneClearMenu.IsChecked("use.Q"))
				Q.CastIfInRange(CastLogics.TargetType.AnyEnemyMinions, Q.Range, Champions.Me.Position);
		}

		internal override void OnJungleClear()
		{
			if (JungleClearMenu.IsChecked("use.Q"))
				Q.CastIfInRange(CastLogics.TargetType.AnyMonster, Q.Range, Champions.Me.Position);
			if (JungleClearMenu.IsChecked("use.E"))
				E.CastLogicLinearExtendedRange(CastLogics.CollisionType.None, CastLogics.TargetType.MonsterStrongest, DamageType.Physical, 50);
		}

		internal override void OnHeroAutoattackHero(AIHeroClient sender, AIHeroClient target)
		{
			if (PassiveMenu.IsChecked("use.W.ego") && sender.IsEnemy && target.IsMe)
				W.CastIfInRange(CastLogics.TargetType.Me, W.Range, GetSwordPos());
			if (PassiveMenu.IsChecked("use.W.buddy") && sender.IsEnemy && target.IsAlly)
				W.CastIfInRange(CastLogics.TargetType.Buddy, W.Range, GetSwordPos());
		}

		internal override void OnMinionAutoattackHero(Obj_AI_Base sender, AIHeroClient target)
		{
			if (PassiveMenu.IsChecked("use.W.monster") && sender.IsEnemy && target.IsMe && EntityManager.MinionsAndMonsters.Monsters.Any(u => u.NetworkId == sender.NetworkId))
				W.CastIfInRange(CastLogics.TargetType.Me, W.Range, GetSwordPos());
			if (PassiveMenu.IsChecked("use.W.minion") && sender.IsEnemy && target.IsMe && EntityManager.MinionsAndMonsters.Minions.Any(u => u.NetworkId == sender.NetworkId))
				W.CastIfInRange(CastLogics.TargetType.Me, W.Range, GetSwordPos());
		}

		internal override void OnPassive()
		{
			if (!R.IsReady())
				return;
			var buddyInDanger = EntityManager.Heroes.Allies.Where(u => !u.IsDead && !u.IsMe &&
					(PassiveMenu.GetValue("use.R.myHealth") * u.CountEnemiesInRange(900) <= Champions.Me.HealthPercent || (E.IsReady() && u.IsValidTarget(PassiveMenu.GetValue("use.R.distance2")))) &&
					(u.CountEnemiesInRange(900) >= 1) &&
					(Champions.Me.CountEnemiesInRange(PassiveMenu.GetValue("use.R.distance")) == 0 || u.IsValidTarget(PassiveMenu.GetValue("use.R.distance2"))) &&
					(u.HealthPercent <= PassiveMenu.GetValue("use.R.belowHealth") || (Prediction.Health.GetPrediction(u, 500) / u.MaxHealth * 100) <= PassiveMenu.GetValue("use.R.belowHealth"))
					&& PassiveMenu.IsActiveOnHeroList("use.R.on", u)).OrderBy(u => u.Health).FirstOrDefault();
			if (buddyInDanger != null)
				R.Cast(buddyInDanger);
		}

		public Vector3 GetSwordPos()
		{
			var obj = ObjectManager.Get<Obj_AI_Base>()
					.FirstOrDefault(
						o => o.Name == "ShenSpiritUnit" && o.Team == Champions.Me.Team && o.Health >= 1);
			return obj != null ? obj.Position : Vector3.Zero;
		}
	}
}
