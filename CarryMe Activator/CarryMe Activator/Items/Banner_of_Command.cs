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
	internal class Banner_of_Command
	{
		public static ItemId Id = ItemId.Banner_of_Command;
		public static string Name = Id.ToString().Replace("_", " ");
		public static string IdentBase = "cm.situation." + Name.ToLower().Replace(" ", ".");
		public static Menu Menu;
		public bool ActivatedMessage;
		public int DelayTick;

		public Banner_of_Command()
		{
			Menu = SituationalItems.Menu.AddSubMenu(Name, IdentBase);
			Menu.Add(IdentBase + ".disable", new CheckBox("Disable " + Name + " totally",false));
			Menu.AddSeparator();
			Menu.Add(IdentBase + ".ActiveInCombo", new CheckBox("Active in Combo"));
			Menu.Add(IdentBase + ".ActiveInHarras", new CheckBox("Active in Harras"));
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
						var SiegeMinion = ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(u => !u.IsDead && u.IsValidTarget(1100) && u.BaseSkinName.Contains("MinionSiege") && u.Team == ObjectManager.Player.Team);
						if (SiegeMinion != null)
							Item.UseItem(Id, SiegeMinion);
					}
					if (Menu[IdentBase + ".ActiveInHarras"].Cast<CheckBox>().CurrentValue &&
						Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
					{
						var SiegeMinion = ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(u => !u.IsDead && u.IsValidTarget(1100) && u.BaseSkinName.Contains("MinionSiege") && u.Team == ObjectManager.Player.Team);
						if (SiegeMinion != null)
							Item.UseItem(Id, SiegeMinion);
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