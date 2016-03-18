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
	internal class Guardians_Horn
	{
		public static ItemId Id = ItemId.Dervish_Blade;
		public static string Name = Id.ToString().Replace("_", " ");
		public static string IdentBase = "cm.offitems." + Name.ToLower().Replace(" ", ".");
		public static Menu Menu;
		public bool ActivatedMessage;
		public int DelayTick;

		public Guardians_Horn()
		{
			Menu = OffensiveItems.Menu.AddSubMenu(Name, IdentBase);
			Menu.Add(IdentBase + ".disable", new CheckBox("Disable " + Name + " totally"));
			Menu.AddSeparator();
			Menu.Add(IdentBase + ".ActiveInCombo", new CheckBox("Active in Combo"));
			Menu.Add(IdentBase + ".Combo.UseIfEnemyHPbelow", new Slider("Use if Enemy HP < {0}%", 90));
			Menu.Add(IdentBase + ".Combo.UseIfHeroHPbelow", new Slider("Use if Hero HP < {0}%", 50));
			Menu.AddSeparator();
			Menu.Add(IdentBase + ".ActiveInHarras", new CheckBox("Active in Harras", false));
			Menu.Add(IdentBase + ".Harras.UseIfEnemyHPbelow", new Slider("Use if Enemy HP < {0}%", 70));
			Menu.Add(IdentBase + ".Harras.UseIfHeroHPbelow", new Slider("Use if Hero HP < {0}%", 30));
			Menu.AddSeparator();
			Menu.AddLabel("Additional Setting");
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
					var target = TargetSelector.GetTarget(650,DamageType.Physical);
					if (Menu[IdentBase + ".ActiveInCombo"].Cast<CheckBox>().CurrentValue &&
						Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
					{
						if (target != null)
						{
							if (Menu[IdentBase + ".Combo.UseIfEnemyHPbelow"].Cast<Slider>().CurrentValue >= target.HealthPercent ||
								Menu[IdentBase + ".Combo.UseIfHeroHPbelow"].Cast<Slider>().CurrentValue >= target.HealthPercent)
							{
								Item.UseItem(Id);
							}
						}
					}
					if (Menu[IdentBase + ".ActiveInHarras"].Cast<CheckBox>().CurrentValue &&
						Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
					{
						if (target != null)
						{
							if (Menu[IdentBase + ".Harras.UseIfEnemyHPbelow"].Cast<Slider>().CurrentValue >= target.HealthPercent ||
								Menu[IdentBase + ".Harras.UseIfHeroHPbelow"].Cast<Slider>().CurrentValue >= target.HealthPercent)
							{
								Item.UseItem(Id);
							}
						}
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