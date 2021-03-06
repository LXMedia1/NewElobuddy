﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CarryMe_Blitzcrank.Basics;
using EloBuddy;
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
		
			menuBuilder.AddMenu(MenuBuilder.MenuNames.BlackList);
			menuBuilder.AddLabel(MenuBuilder.MenuNames.BlackList, "If a Champion is Checked he will not Grab them");
			foreach (var enemy in ObjectManager.Get<AIHeroClient>().Where(u => u.IsEnemy))
			{
				try
				{
					menuBuilder.AddCheckBox(MenuBuilder.MenuNames.BlackList, enemy.ChampionName, "blacklist." + enemy.ChampionName, false);
				}
				catch (Exception)
				{
					// iggnored some champ double in that list...
				}
			}

			menuBuilder.AddMenu(Orbwalker.ActiveModes.Combo);
			menuBuilder.AddLabel(Orbwalker.ActiveModes.Combo, "Basic Rules", true);
			menuBuilder.AddCheckBox(Orbwalker.ActiveModes.Combo, "Use Q", "use.Q", true);
			menuBuilder.AddCheckBox(Orbwalker.ActiveModes.Combo, "Use E if Q hit", "use.E", true);
			menuBuilder.AddLabel(Orbwalker.ActiveModes.Combo, "Info: You cant have both activated");
			menuBuilder.AddRadioBox(Orbwalker.ActiveModes.Combo, false,
				new MenuBuilder.RadioBox("Combo Use E after Autoattack", "use.E.afterAA", false),
				new MenuBuilder.RadioBox("Combo Use E if in Range", "use.E.inrage", true));
			menuBuilder.AddLabel(Orbwalker.ActiveModes.Combo, "Advanged Rules", true);
			menuBuilder.AddSlider(Orbwalker.ActiveModes.Combo, "Q Maximum Cast Range: {0}","modiefied.Q.range.max", 1000, 0, (int)Blitzcrank.Q.Range);
			menuBuilder.AddSlider(Orbwalker.ActiveModes.Combo, "Q Minimum Cast Range: {0}", "modiefied.Q.range.min", 100, 0, 500);
			
			menuBuilder.AddMenu(Orbwalker.ActiveModes.Harass);
			menuBuilder.AddLabel(Orbwalker.ActiveModes.Harass, "Basic Rules", true);
			menuBuilder.AddCheckBox(Orbwalker.ActiveModes.Harass, "Use Q", "use.Q", false);
			menuBuilder.AddCheckBox(Orbwalker.ActiveModes.Harass, "Use E if Q hit", "use.E", true);
			menuBuilder.AddLabel(Orbwalker.ActiveModes.Harass, "Info: You cant have both activated");
			menuBuilder.AddRadioBox(Orbwalker.ActiveModes.Harass, false,
				new MenuBuilder.RadioBox("Harras Use E after Autoattack", "use.E.afterAA", true),
				new MenuBuilder.RadioBox("Harras Use E if in Range", "use.E.inrage", false));
			menuBuilder.AddLabel(Orbwalker.ActiveModes.Harass, "Advanged Rules", true);
			menuBuilder.AddSlider(Orbwalker.ActiveModes.Harass, "Q Maximum Cast Range: {0}", "modiefied.Q.range.max", 1000, 0, (int)Blitzcrank.Q.Range);
			menuBuilder.AddSlider(Orbwalker.ActiveModes.Harass, "Q Minimum Cast Range: {0}", "modiefied.Q.range.min", 100, 0, 500);
			
			menuBuilder.AddMenu(MenuBuilder.MenuNames.Misc);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Misc, "Use E if Q hit", "use.E", true);
			menuBuilder.AddLabel(MenuBuilder.MenuNames.Misc, "AutoAssist R info: Your Buddy must be in Autoattackrange + AdditionalRange");
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Misc, "AutoAssist R useage", "use.R.autoAssist", true);
			menuBuilder.AddSlider(MenuBuilder.MenuNames.Misc, "AutoAssist R must hit Min {0} Enemys in Combo", "autoassist.HitCountInCombo", 2, 1, 5);
			menuBuilder.AddSlider(MenuBuilder.MenuNames.Misc, "AutoAssist R must hit Min {0} Enemys in Harras", "autoassist.HitCountInHarras", 1, 1, 5);
			menuBuilder.AddSlider(MenuBuilder.MenuNames.Misc, "Buddy AutoAttackrange + {0} = totalRange ", "additional.buddyrange", 200, 0, 300);
			menuBuilder.AddSlider(MenuBuilder.MenuNames.Misc, "Use R if your Buddy can kill within {0} autoattack hits", "use.R.onAAleft", 2, 1, 5);
			menuBuilder.AddSlider(MenuBuilder.MenuNames.Misc, "If R will Hit {0} Enemys always cast", "autoassist.alwaysUseRCount", 3, 1, 5);

			menuBuilder.AddMenu(MenuBuilder.MenuNames.Killsteal);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Killsteal, "Use Q", "use.Q", true);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Killsteal, "Use E", "use.E", true);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Killsteal, "Use R", "use.R", true);

			menuBuilder.AddMenu(MenuBuilder.MenuNames.Drawing);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Drawing, "Draw Q Range", "draw.Q.range", true);
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Drawing, "Draw Q Prediction", "draw.Q.prediction", true);

			menuBuilder.AddMenu(MenuBuilder.MenuNames.Anti_FPS_Drop);
			menuBuilder.AddLabel(MenuBuilder.MenuNames.Anti_FPS_Drop, "just use OnTickMode if you have FPS Problems ( it reduce the needed ressources but also the performance )");
			menuBuilder.AddCheckBox(MenuBuilder.MenuNames.Anti_FPS_Drop, "Use OnTickMode", "antiFPS.useOnTick", false);

			return menuBuilder;
		}
	}
}
