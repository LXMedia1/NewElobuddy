using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace CarryMe_Collection.Basics
{
	internal static class MenuBuilder
	{
		public static Dictionary<MenuName,Menu> MenuDictionary = new Dictionary<MenuName, Menu>();
		public enum MenuName
		{
			Combo,
			Anti_FPS,
			Harras,
			LaneClear,
			Passive,
			JungleClear,
			Drawing,
			LastHit,
			Flee,
		}

		public static bool IsChecked(this Menu menu, string Identifier)
		{
			try
			{
				return menu[Identifier].Cast<CheckBox>().CurrentValue;
			}
			catch (Exception)
			{
				Console.WriteLine("CM-Error: Checkbox with Identifier: " + Identifier + " not exist.");
				return false;
			}
		}
		public static CheckBox AddCheckBox(this Menu Menu, string Identifier, string DisplayName,bool DefaultValue = true)
		{
			try
			{
				return Menu.Add(Identifier, new CheckBox(DisplayName, DefaultValue));
			}
			catch (Exception)
			{
				Console.WriteLine("CM-Error: AddCheckbox with Identifier: " + Identifier + " allready exist.");
				return new CheckBox("dummy");
			}
		}
		public static int GetValue(this Menu menu, string Identifier)
		{
			try
			{
				return menu[Identifier].Cast<Slider>().CurrentValue;
			}
			catch (Exception)
			{
				Console.WriteLine("CM-Error: Slider with Identifier: " + Identifier + " not exist.");
				return 0;
			}
		}
		public static Slider AddSlider(this Menu Menu, string Identifier, string DisplayName, int DefaultValue, int MinValue = 0,	int MaxValue = 100)
		{
			try
			{
				return Menu.Add(Identifier, new Slider(DisplayName,DefaultValue,MinValue,MaxValue));
			}
			catch (Exception)
			{
				Console.WriteLine("CM-Error: AddSlider with Identifier: " + Identifier + " allready exist.");
				return new Slider("dummy");
			}
		}

		public static Menu AddSubMenu(this Menu Menu, MenuName name)
		{
			try
			{
				var menu = Menu.AddSubMenu(name.ToString());
				MenuDictionary.Add(name, menu);
				return menu;
			}
			catch (Exception)
			{
				Console.WriteLine("CM-Error: Submenu with name: " + name + " allready exist.");
				return Menu;
			}
		}

		public static Dictionary<string, List<string>> SpoilerDictionary = new Dictionary<string, List<string>>();

		public static void AddSpoiler(this Menu Menu,string Identifier, string DisplayName, List<string> StringList,bool shouldread = false)
		{
			Menu.Add(Identifier, new CheckBox(DisplayName, false)).OnValueChange += SpoilerValueChanged;

			var visible = Menu[Identifier].Cast<CheckBox>().CurrentValue;
			var count = 0;
			SpoilerDictionary.Add(Identifier, StringList);
			foreach (var str in StringList)
			{
				Menu.Add(Identifier + "." + count,
					new Label(str.Replace("[0]", "► ").Replace("[1]", "    ► ").Replace("[2]", "        ► "))).IsVisible = visible;
				++count;
			}
			if (shouldread)
				Menu.Add(Identifier+ ".new", new CheckBox(DisplayName, false)).IsVisible = false;
		}
		private static void SpoilerValueChanged(ValueBase<bool> sender, ValueBase<bool>.ValueChangeArgs args)
		{
			var StringList = SpoilerDictionary[sender.SerializationId];
			var count = 0;
			foreach (var str in StringList)
			{
				Logic.Champion.Config[sender.SerializationId + "." + count].Cast<Label>().IsVisible = args.NewValue;
				++count;
			}
			try
			{
				if (args.NewValue)
					Logic.Champion.Config[sender.SerializationId + ".new"].Cast<CheckBox>().CurrentValue = true;
			}
			catch (Exception)
			{

			}
		}

		public static bool ShouldReadChangeLog(this Menu Menu,string Identifier)
		{
			try
			{
				return !Menu[Identifier + ".new"].Cast<CheckBox>().CurrentValue;
			}
			catch (Exception)
			{
				Console.WriteLine("CM-Error: Blame Lexxes he messed up the Changelog :P");
				return false;
			}
		}

		public static bool UseOnTick
		{
			get
			{
				try
				{
					return MenuDictionary[MenuName.Anti_FPS]["use.OnTick"].Cast<CheckBox>().CurrentValue;
				}
				catch (Exception)
				{
					Console.WriteLine("CM-Error: Seems AntiFPS menu UseonTick Checkbox not existing o.O");
					return false;
				}
			}
		}
	}
}
