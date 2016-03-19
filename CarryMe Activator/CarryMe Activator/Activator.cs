using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarryMe_Activator.Classes;
using CarryMe_Activator.DB;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using Spell = CarryMe_Activator.DB.Spell;

namespace CarryMe_Activator
{
	class Activator
	{
		public static GameMapId CurrentMap;
		public static AIHeroClient Me;

		public static SpellSlot SmiteSlot;
		public static SpellSlot FlashSlot;

		public static List<Hero> VirtualHeroList = new List<Hero>();
		public static List<Spell> SpellsIngameList = new List<Spell>();
		public static List<Buff> BuffsIngameList = new List<Buff>();
		public static List<Troy> TroysIngameList = new List<Troy>();

		internal static void Load()
		{
			CurrentMap = Game.MapId;
			Me = ObjectManager.Player;

			SmiteSlot = Me.GetSpellSlotFromName("SummonerSmite");
			FlashSlot = Me.GetSpellSlotFromName("SummonerFlash");

			foreach (var hero in EntityManager.Heroes.AllHeroes)
			{
				VirtualHeroList.Add(new Hero(hero));
				if (!hero.IsEnemy)
					continue;
				var enemy = hero;
				foreach (
					var spell in
						Spell.SpellList.Where(
							s => String.Equals(s.ChampionName, enemy.ChampionName, StringComparison.CurrentCultureIgnoreCase)))
					Spell.ActiveSpellList.Add(spell);
				foreach (
					var buff in
						Buff.BuffList.Where(
							s => String.Equals(s.ChampionName, enemy.ChampionName, StringComparison.CurrentCultureIgnoreCase)))
					Buff.ActiveBuffList.Add(buff);
				foreach (
					var troy in
						Troy.TroyList.Where(
							s => String.Equals(s.ChampionName, enemy.ChampionName, StringComparison.CurrentCultureIgnoreCase)))
					Troy.ActiveTroyList.Add(troy);
			}
			CleanserItems.Load();
			OffensiveItems.Load();
			SituationalItems.Load();
			
		}
	}
}
