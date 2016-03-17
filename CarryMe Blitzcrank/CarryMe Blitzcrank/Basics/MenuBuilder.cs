using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace CarryMe_Blitzcrank.Basics
{
	class MenuBuilder
	{
		internal enum MenuNames
		{
			Drawing,
			Misc,
			Killsteal,
		}

		internal Dictionary<string,Menu> MenuDictionary = new Dictionary<string, Menu>();
		internal Dictionary<string,CheckBox> RandioboxDictionary = new Dictionary<string, CheckBox>();
		internal int RadioBoxTick;
		internal int SeperatorCount;
		
		internal void AddMenu()
		{
			MainMenu.AddMenu("CM " + ObjectManager.Player.ChampionName,
							"cm_" + ObjectManager.Player.ChampionName.ToLower(),
							"CarryMe " + ObjectManager.Player.ChampionName + " by Lekks.");
		}

		internal void AddMenu(MenuNames menuname)
		{
			var menu = MainMenu.GetMenu("cm_" + ObjectManager.Player.ChampionName.ToLower());
			var newmenu = menu.AddSubMenu("Mode " + menuname, "cm_" + menuname.ToString().ToLower(), "CarryMe " + ObjectManager.Player.ChampionName + " - " + menuname);
			MenuDictionary.Add(menuname.ToString(), newmenu);
		}

		internal void AddMenu(Orbwalker.ActiveModes mode)
		{
			var menu = MainMenu.GetMenu("cm_" + ObjectManager.Player.ChampionName.ToLower());
			var newmenu= menu.AddSubMenu("Mode " + mode, "cm_" + mode.ToString().ToLower(), "CarryMe " + ObjectManager.Player.ChampionName + " - " + mode);
			MenuDictionary.Add(mode.ToString(),newmenu);
		}

		internal void AddCheckBox(MenuNames menuname, string displayName, string identifier, bool defaultValue)
		{
			MenuDictionary[menuname.ToString()].Add(identifier, new CheckBox(displayName, defaultValue));
		}

		internal void AddCheckBox(Orbwalker.ActiveModes mode, string displayName, string identifier, bool defaultValue)
		{
			MenuDictionary[mode.ToString()].Add(identifier, new CheckBox(displayName, defaultValue));
		}

		internal void AddSlider(MenuNames menuname, string displayName, string identifier, int defaultValue, int min, int max)
		{
			MenuDictionary[menuname.ToString()].Add(identifier, new Slider(displayName, defaultValue, min, max));
		}

		internal void AddSlider(Orbwalker.ActiveModes mode, string displayName, string identifier, int defaultValue, int min, int max)
		{
			MenuDictionary[mode.ToString()].Add(identifier, new Slider(displayName, defaultValue,min,max));
		}


		internal void AddLabel(Orbwalker.ActiveModes mode, string label, bool header = false)
		{
			MenuDictionary[mode.ToString()].Add("sep_" + SeperatorCount, new Separator(header ? 15 : 10));
			++SeperatorCount;
			if (header)
				MenuDictionary[mode.ToString()].AddGroupLabel(label);
			else
				MenuDictionary[mode.ToString()].AddLabel(label);
			MenuDictionary[mode.ToString()].Add("sep_" + SeperatorCount, new Separator(header ? 10 : 5));
			++SeperatorCount;
		}


		internal void AddLabel(MenuNames menuname, string label, bool header = false)
		{
			MenuDictionary[menuname.ToString()].Add("sep_" + SeperatorCount, new Separator(header ? 10 : 5));
			++SeperatorCount;
			if (header)
				MenuDictionary[menuname.ToString()].AddGroupLabel(label);
			else
				MenuDictionary[menuname.ToString()].AddLabel(label);
			MenuDictionary[menuname.ToString()].Add("sep_" + SeperatorCount, new Separator(header ? 10 : 5));
			++SeperatorCount;
		}

		internal void AddRadioBox(Orbwalker.ActiveModes mode,bool oneMustStayAktive, RadioBox Box1, RadioBox Box2)
		{
			var checkbox1 = MenuDictionary[mode.ToString()].Add(Box1.Identifier, new CheckBox(Box1.Name, Box1.DefaultValue));
			var checkbox2 = MenuDictionary[mode.ToString()].Add(Box2.Identifier, new CheckBox(Box2.Name, Box2.DefaultValue));
			RandioboxDictionary.Add(Box1.Name, checkbox2);
			RandioboxDictionary.Add(Box2.Name, checkbox1);

			if (oneMustStayAktive)
			{
				checkbox1.OnValueChange += CheckBoxChanged_OneStayActive;
				checkbox2.OnValueChange += CheckBoxChanged_OneStayActive;
			}
			else
			{
				checkbox1.OnValueChange += CheckBoxChanged_JustDisable;
				checkbox2.OnValueChange += CheckBoxChanged_JustDisable;
			}
		}
		internal void AddRadioBox(MenuNames menuname, bool oneMustStayAktive, RadioBox Box1, RadioBox Box2)
		{
			var checkbox1 = MenuDictionary[menuname.ToString()].Add(Box1.Identifier, new CheckBox(Box1.Name, Box1.DefaultValue));
			var checkbox2 = MenuDictionary[menuname.ToString()].Add(Box2.Identifier, new CheckBox(Box2.Name, Box2.DefaultValue));
			RandioboxDictionary.Add(Box1.Name, checkbox2);
			RandioboxDictionary.Add(Box2.Name, checkbox1);

			if (oneMustStayAktive)
			{
				checkbox1.OnValueChange += CheckBoxChanged_OneStayActive;
				checkbox2.OnValueChange += CheckBoxChanged_OneStayActive;
			}
			else
			{
				checkbox1.OnValueChange += CheckBoxChanged_JustDisable;
				checkbox2.OnValueChange += CheckBoxChanged_JustDisable;
			}
		}
		private void CheckBoxChanged_JustDisable(ValueBase<bool> sender, ValueBase<bool>.ValueChangeArgs args)
		{
			if (RadioBoxTick + 10 > Core.GameTickCount || !args.NewValue)
				return;
			RadioBoxTick = Core.GameTickCount;
			RandioboxDictionary[sender.DisplayName].Cast<CheckBox>().CurrentValue = !args.NewValue;
		}

		private void CheckBoxChanged_OneStayActive(ValueBase<bool> sender, ValueBase<bool>.ValueChangeArgs args)
		{
			Console.WriteLine(sender.DisplayName);
			if (RadioBoxTick + 10 > Core.GameTickCount)
				return;
			RadioBoxTick = Core.GameTickCount;
			RandioboxDictionary[sender.DisplayName].Cast<CheckBox>().CurrentValue = !args.NewValue;
		}

		internal bool IsChecked(MenuNames menuname, string identifier)
		{
			return MenuDictionary[menuname.ToString()][identifier].Cast<CheckBox>().CurrentValue;
		}

		internal bool IsChecked(Orbwalker.ActiveModes mode, string identifier)
		{
			return Orbwalker.ActiveModesFlags.HasFlag(mode) &&
				   MenuDictionary[mode.ToString()][identifier].Cast<CheckBox>().CurrentValue;
		}

		internal int GetValue(MenuNames menuname, string identifier)
		{
			return MenuDictionary[menuname.ToString()][identifier].Cast<Slider>().CurrentValue;
		}

		internal int GetValue(Orbwalker.ActiveModes mode, string identifier)
		{
			return MenuDictionary[mode.ToString()][identifier].Cast<Slider>().CurrentValue;
		}
		public class RadioBox
		{
			public string Identifier;
			public string Name;
			public bool DefaultValue;

			public RadioBox(string name, string identifier, bool defaultvalue)
			{
				Identifier = identifier;
				Name = name;
				DefaultValue = defaultvalue;
			}
		}
	}
}
