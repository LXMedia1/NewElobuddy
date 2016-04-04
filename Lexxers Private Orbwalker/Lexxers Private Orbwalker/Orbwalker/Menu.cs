using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Lexxers_Private_Orbwalker.Orbwalker
{
	class Menu
	{
		public static EloBuddy.SDK.Menu.Menu Config;
		public static EloBuddy.SDK.Menu.Menu Config_Behavier;
		public static EloBuddy.SDK.Menu.Menu Config_Extra;
		public static EloBuddy.SDK.Menu.Menu Config_Drawing;
		internal static void Load()
		{
			Config = MainMenu.AddMenu("LX-Orbwalker", "orbwalker", "Lexxers Orbwalker");
			Config.AddLabel("It uses the Elobuddy Orbwalker Keys but nothing else from it.");
			Config.AddLabel("LX Orbwalker will disable Orbwalker as far he can but you still should disable Drawing.");


			Config_Behavier = Config.AddSubMenu("Behavier", "orbwalker.behavier", "Behavier´s");		
	
			Config_Behavier.AddGroupLabel("Priorities:");
			Config_Behavier.AddLabel("Prioritie Farm </> EnemyHit ( for Harras )");
			Config_Behavier.Add("priorityFarm", new CheckBox("Farm", true));
			Config_Behavier.AddLabel("Prioritie Big </> Small ( for JungleClear )");
			Config_Behavier.Add("priorityJungleBig", new CheckBox("Pref Big Monster", true));

			Config_Behavier.AddGroupLabel("Custom Behavier:");
			Config_Behavier.AddLabel("Attack Objects/Wards");
			Config_Behavier.Add("removeObjects", new CheckBox("Objects", true));
			Config_Behavier.Add("removeWards", new CheckBox("Wards", true));

			Config_Behavier.AddGroupLabel("Special Behaviers:");
			Config_Behavier.AddLabel("POI Means for Melee the Target/ or some Objects (like Catching Axes from Draven)");
			Config_Behavier.AddLabel("Interact Range: if will Change the MovementCommands if POI is inside this Range (from Curser)");
			Config_Behavier.Add("interactRange", new Slider("Interact Range {0}", 350,0,800));

			Config_Behavier.AddLabel("Movement Prediction: If Aktive will Semiautomatic your Movement on Melees (for Combo)");
			Config_Behavier.Add("meleePrediction1", new CheckBox("Melee Movement Prediction VollAuto", false));
			Config_Behavier.Add("meleePrediction2", new CheckBox("Melee Movement Prediction SemiAuto", false));

			Config_Drawing = Config.AddSubMenu("Drawings", "orbwalker.drawings", "Drawing Settings");
			Config_Drawing.AddLabel("Basic Drawing Rules For Your Hero");
			Config_Drawing.Add("drawMyAARange", new CheckBox("Draw AA Range"));
			Config_Drawing.Add("drawMyHoldArea",new CheckBox("Draw Hold Area"));

			Config_Drawing.AddLabel("Basic Drawing Rules For Enemys");
			Config_Drawing.Add("drawEnemyAARange", new CheckBox("Draw AA Range"));
			Config_Drawing.Add("drawEnemyBoundingRadius", new CheckBox("Draw BoundingRadius"));

			Config_Drawing.AddLabel("Interact Range");
			Config_Drawing.Add("drawInteractCircle", new CheckBox("Draw Interact Circle"));

			Config_Extra = Config.AddSubMenu("Extra", "orbwalker.extra", "Extra Settings");
			Config_Extra.AddLabel("Windup: Its the Time After a Attack before he can Move again.");
			Config_Extra.AddLabel("If you have Increased AA Cancle set this Higher");
			Config_Extra.Add("windup", new Slider("Additional Windup time: {0} ms", 120, 0, 500));

			Config_Extra.AddLabel("HoldArea: Its a Range Around your Hero.");
			Config_Extra.AddLabel("If your Mouse is inside this Area he wont move to your Cursor ( 0 to Disable)");
			Config_Extra.Add("holdArea", new Slider("HoldArea distance: {0}", 100, 0, 500));

		}
	}
}
