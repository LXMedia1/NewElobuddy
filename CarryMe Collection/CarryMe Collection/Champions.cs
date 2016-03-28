using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CarryMe_Collection.Logic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using Champion = EloBuddy.Champion;

namespace CarryMe_Collection
{
	public  class Champions
	{
		public static AIHeroClient Me;
		public static Logic.Champion Logic;

		public Champions()
		{
			Me = ObjectManager.Player;

			Logic = GetChampionLogic(Me.Hero);
			if (Logic == null)
				return;
			Logic.WriteMenuStart();
			Logic.WriteMenuEnd();

			Game.OnUpdate += OnUpdate;
			Game.OnTick += OnTick;
			Drawing.OnDraw += OnDraw;
			Orbwalker.OnPostAttack += OnAfterAttack;
			Spellbook.OnCastSpell += OnCastSpell;
			Obj_AI_Base.OnBasicAttack += OnAutoAttack;
		}

		private static void OnAfterAttack(AttackableUnit target, EventArgs args)
		{
			Logic.OnAfterAttack(target, args);
		}

		private static Logic.Champion GetChampionLogic(Champion champion)
		{
			switch (champion)
			{
				case Champion.DrMundo:
					return new DrMundo();
				case Champion.Shen:
					return new Shen();
			}
			return null;
		}

		private static void OnTick(EventArgs args)
		{
			if (Basics.MenuBuilder.UseOnTick)
				OnTickUpdate();
		}

		private static void OnUpdate(EventArgs args)
		{
			if (!Basics.MenuBuilder.UseOnTick)
				OnTickUpdate();
		}

		private static void OnTickUpdate()
		{
			Logic.OnPassive();
			if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
				Logic.OnCombo();
			if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee))
				Logic.OnFlee();
			if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
				Logic.OnHarass();
			if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
				Logic.OnJungleClear();
			if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
				Logic.OnLaneClear();
			if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit))
				Logic.OnLastHit();
			if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.None))
				Logic.OnNone();
		}

		private void OnDraw(EventArgs args)
		{
			Logic.OnDraw();
		}
		private void OnCastSpell(Spellbook sender, SpellbookCastSpellEventArgs args)
		{
			
		}
		private void OnAutoAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
		{
			if (args.Target.Type == GameObjectType.AIHeroClient)
				Logic.OnAnyAutoAttackHero(sender, (AIHeroClient)args.Target);
			if (sender.Type == GameObjectType.AIHeroClient && args.Target.Type == GameObjectType.AIHeroClient)
				Logic.OnHeroAutoattackHero((AIHeroClient)sender, (AIHeroClient)args.Target);
			if (sender.Type == GameObjectType.obj_AI_Minion && args.Target.Type == GameObjectType.AIHeroClient)
				Logic.OnMinionAutoattackHero((Obj_AI_Minion)sender, (AIHeroClient)args.Target);
			if (sender.Type == GameObjectType.AIHeroClient && args.Target.Type == GameObjectType.obj_AI_Turret)
				Logic.OnHeroAutoattackTower((AIHeroClient)sender, (Obj_AI_Turret)args.Target);
		}
	}

}
