using System.Collections.Generic;
using System.Xml;
using CarryMe_Blitzcrank.Basics;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Notifications;

namespace CarryMe_Blitzcrank
{
	class Blitzcrank_Menu
	{
		internal static MenuBuilder Load()
		{
			var menuBuilder = new MenuBuilder();
			menuBuilder.AddMenu();

			menuBuilder.AddMenu(Orbwalker.ActiveModes.Combo);
			menuBuilder.AddLabel(Orbwalker.ActiveModes.Combo, "Basic Rules", true);
			menuBuilder.AddCheckBox(Orbwalker.ActiveModes.Combo, "Use Q", "use.Q", true);
			menuBuilder.AddCheckBox(Orbwalker.ActiveModes.Combo, "Use E if Q hit", "use.E", true);
			menuBuilder.AddLabel(Orbwalker.ActiveModes.Combo, "Info: You cant have both activated");
			menuBuilder.AddRadioBox(Orbwalker.ActiveModes.Combo, false,
				new MenuBuilder.RadioBox("Use E after Autoattack", "use.E.afterAA", true),
				new MenuBuilder.RadioBox("Use E if in Range", "use.E.inrage", false));
			menuBuilder.AddLabel(Orbwalker.ActiveModes.Combo, "Advanged Rules", true);
			menuBuilder.AddSlider(Orbwalker.ActiveModes.Combo, "Q Maximum Cast Range: {0}","modiefied.Q.range.max", 1000, 0, (int)Blitzcrank.Q.Range);
			menuBuilder.AddSlider(Orbwalker.ActiveModes.Combo, "Q Minimum Cast Range: {0}", "modiefied.Q.range.min", 100, 0, 500);
			
			menuBuilder.AddMenu(Orbwalker.ActiveModes.Harass);
			menuBuilder.AddLabel(Orbwalker.ActiveModes.Harass, "Basic Rules", true);
			menuBuilder.AddCheckBox(Orbwalker.ActiveModes.Harass, "Use Q", "use.Q", false);
			menuBuilder.AddCheckBox(Orbwalker.ActiveModes.Harass, "Use E if Q hit", "use.E", true);
			menuBuilder.AddLabel(Orbwalker.ActiveModes.Harass, "Advanged Rules", true);
			menuBuilder.AddSlider(Orbwalker.ActiveModes.Harass, "Q Maximum Cast Range: {0}", "modiefied.Q.range.max", 1000, 0, (int)Blitzcrank.Q.Range);
			menuBuilder.AddSlider(Orbwalker.ActiveModes.Harass, "Q Minimum Cast Range: {0}", "modiefied.Q.range.min", 100, 0, 500);
			
			menuBuilder.AddMenu(MenuBuilder.MenuNames.Misc);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Misc, "Use E if Q hit", "use.E", true);
			menuBuilder.AddLabel(MenuBuilder.MenuNames.Misc, "AutoAssist R info: Your Buddy must be in Autoattackrange + AdditionalRange");
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Misc, "AutoAssist R useage", "use.R.autoAssist", true);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Misc, "deaktivate in Combo", "use.R.notInCombo", true);
			menuBuilder.AddSlider(MenuBuilder.MenuNames.Misc, "Buddy AutoAttackrange + {0} = totalRange ", "additional.buddyrange", 200, 0, 300);
			menuBuilder.AddSlider(MenuBuilder.MenuNames.Misc, "Use R if your Buddy can kill within {0} autoattack hits", "use.R.onAAleft", 2, 1, 5);

			menuBuilder.AddMenu(MenuBuilder.MenuNames.Killsteal);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Killsteal, "Use Q", "use.Q", true);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Killsteal, "Use E", "use.E", true);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Killsteal, "Use R", "use.R", true);

			menuBuilder.AddMenu(MenuBuilder.MenuNames.Drawing);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Drawing, "Draw Q Range", "draw.Q.range", true);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Drawing, "Draw Q Prediction", "draw.Q.prediction", true);

			return menuBuilder;
		}
	}
}
