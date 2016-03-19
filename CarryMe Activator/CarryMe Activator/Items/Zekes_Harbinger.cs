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
	internal class Zekes_Harbinger
	{
		public static ItemId Id = ItemId.Zekes_Harbinger;
		public static string Name = Id.ToString().Replace("_", " ");
		public static string IdentBase = "cm.situation." + Name.ToLower().Replace(" ", ".");
		public static Menu Menu;
		public bool ActivatedMessage;
		public int DelayTick;

		public Zekes_Harbinger()
		{
			Menu = SituationalItems.Menu.AddSubMenu(Name, IdentBase);
			Menu.Add(IdentBase + ".disable", new CheckBox("Disable " + Name + " totally", false));
			Menu.AddSeparator();
			Menu.Add(IdentBase + ".autoBind", new CheckBox("AutoBind to Strongest Buddy"));
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
					if (Menu[IdentBase + ".autoBind"].Cast<CheckBox>().CurrentValue)
					{
						var strongestBuddy =
							EntityManager.Heroes.Allies.OrderByDescending(u => u.FlatPhysicalDamageMod + u.BaseAttackDamage)
								.FirstOrDefault(u => !u.IsMe && !u.IsDead && !u.IsMelee);
						if (strongestBuddy != null)
						{
							if (!strongestBuddy.HasBuff("rallyingbanneraurafriend") && strongestBuddy.Distance(ObjectManager.Player) <= 1000)
							{
								Item.UseItem(Id, strongestBuddy);
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