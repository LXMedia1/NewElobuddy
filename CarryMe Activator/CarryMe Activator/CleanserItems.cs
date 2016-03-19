using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace CarryMe_Activator
{
	class CleanserItems
	{
		public static Menu Menu;
		internal static void Load()
		{
			Menu = MainMenu.AddMenu("CM Cleanser", "cm.cleanser", "CarryMe Cleanser by Lekks.");
			Menu.Add("cm.cleanser.deactivate", new CheckBox("Disable Cleanser Totally", false));
			Menu.AddLabel("Aktivate/Deactivate Cleanser for Units");
			foreach (var buddy in EntityManager.Heroes.Allies)
			{
				CreateCheckboxForHero(buddy);
			}

			new Items.Dervish_Blade();
			new Items.Mercurial_Scimitar();
			new Items.Mikaels_Crucible();
			new Items.Quicksilver_Sash();
		}

		private static void CreateCheckboxForHero(EloBuddy.AIHeroClient buddy)
		{
			try
			{
				Menu.Add("cm.cleanser.active.for." + buddy.ChampionName.ToLower(), new CheckBox("Use on " + buddy.ChampionName));
			}
			catch (Exception)
			{
				// Iggnored ( blame Elobuddy SDK for adding all champs double into Entitiemanager ... ) PM me if this is fixed 
			}
		}

		public static bool IsActiveForHero(EloBuddy.AIHeroClient buddy)
		{
			try
			{
				return Menu["cm.cleanser.active.for." + buddy.ChampionName.ToLower()].Cast<CheckBox>().CurrentValue;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
