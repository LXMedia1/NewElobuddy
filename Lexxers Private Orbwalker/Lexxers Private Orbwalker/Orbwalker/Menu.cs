using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Lexxers_Private_Orbwalker.Orbwalker
{
	class Menu
	{
		public static EloBuddy.SDK.Menu.Menu Config;
		public static EloBuddy.SDK.Menu.Menu Config_Extra;
		internal static void Load()
		{
			Config = MainMenu.AddMenu("LX-Orbwalker", "orbwalker", "Lexxers Orbwalker");
			Config.AddLabel("It uses the Elobuddy Orbwalker Keys but nothing else from it.");
			Config.AddLabel("LX Orbwalker will disable Orbwalker as far he can but you still should disable Drawing.");

			Config_Extra = Config.AddSubMenu("Extra", "orbwalker.extra", "Extra Settings");
			Config_Extra.Add("windup", new Slider("Additional Windup {0} ms", 200, 0, 500));
		}
	}
}
