using System;
using System.Collections.Generic;
using System.Linq;
using CarryMe_Activator.DB;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Notifications;

namespace CarryMe_Activator.Items
{
	internal class aa_OffensiveItem
	{
		public static ItemId Id = ItemId.Guardians_Horn;
		public static string Name = Id.ToString().Replace("_", " ");
		public static string IdentBase = "cm.offitems." + Name.ToLower().Replace(" ", ".");
		public static Menu Menu;
		public bool ActivatedMessage;
		public int DelayTick;

		public aa_OffensiveItem()
		{
			Menu = CleanserItems.Menu.AddSubMenu(Name, IdentBase);
			Menu.Add(IdentBase + ".disable", new CheckBox("Disable " + Name + " totally"));
			Menu.AddSeparator();
			Menu.Add(IdentBase + ".ActiveInCombo", new CheckBox("Active in Combo"));
			Menu.Add(IdentBase + ".Combo.UseIfEnemyHPbelow", new Slider("Use if Enemy HP < {0}%", 90));
			Menu.AddSeparator();
			Menu.Add(IdentBase + ".ActiveInHarras", new CheckBox("Active in Harras", false));
			Menu.Add(IdentBase + ".Harras.UseIfEnemyHPbelow", new Slider("Use if Enemy HP < {0}%", 70));
			Menu.AddLabel("Additional Setting");
			Menu.Add(IdentBase + ".useForKS", new CheckBox("Use For KS"));
			Menu.Add(IdentBase + ".CheckDelay", new Slider("Humanizer Reaction (will react max. {0} ms later)", 0, 0, 500));
			Game.OnUpdate += GameOnUpdate;
		}

		private void GameOnUpdate(EventArgs args)
		{
			if (ObjectManager.Player.HasItem(Id))
			{
				if (!ActivatedMessage)
				{
					ActivatedMessage = true;
					var notifie = new SimpleNotification("CarryMe Activator", "Item+ : " + Name + " activated!");
					Notifications.Show(notifie);
				}
				if (!Item.CanUseItem(Id))
					return;
				if (DelayTick + Menu[IdentBase + ".CheckDelay"].Cast<Slider>().CurrentValue < Core.GameTickCount)
				{
					DelayTick = Core.GameTickCount;
					if (Menu[IdentBase + ".useForKS"].Cast<CheckBox>().CurrentValue)
					{
						
					}
					if (Menu[IdentBase + ".ActiveInCombo"].Cast<CheckBox>().CurrentValue &&
					    Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
					{
						
					}
					if (Menu[IdentBase + ".ActiveInHarras"].Cast<CheckBox>().CurrentValue &&
						Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
					{

					}
				}
			}
			else
			{
				if (!ActivatedMessage) return;
				ActivatedMessage = false;
				var notifie = new SimpleNotification("CarryMe Activator", "Item- : " + Name + " disabled!");
				Notifications.Show(notifie);
			}
		}
	}
}