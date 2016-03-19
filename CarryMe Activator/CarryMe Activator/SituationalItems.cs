using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace CarryMe_Activator
{
	class SituationalItems
	{
		public static Menu Menu;
		internal static void Load()
		{
			Menu = MainMenu.AddMenu("CM SituationItems", "cm.situation", "CarryMe SituationItems by Lekks.");
			Menu.Add("cm.situation.deactivate", new CheckBox("Disable SituationItems Totally", false));

			new Items.Banner_of_Command();
			new Items.Zekes_Harbinger();

		}

	
	}
}
