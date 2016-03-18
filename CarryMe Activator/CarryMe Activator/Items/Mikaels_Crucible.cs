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
	internal class Mikaels_Crucible
	{
		public static ItemId Id = ItemId.Mikaels_Crucible;
		public static string Name = Id.ToString().Replace("_", " ");
		public static string IdentBase = "cm.cleanser." + Name.ToLower().Replace(" ", ".");

		public static Menu Menu;
		public bool ActivatedMessage;
		public int DelayTick;

		public Mikaels_Crucible()
		{
			Menu = CleanserItems.Menu.AddSubMenu(Name, IdentBase);
			Menu.Add(IdentBase + ".disable", new CheckBox("Disable " + Name + " totally",false));
			Menu.AddLabel("if Active in Combo is unchecked its Always Active");
			Menu.Add(IdentBase + ".justActiveInCombo", new CheckBox("Just Active in Combo", false));

			Menu.AddLabel("Against Bufftypes");
			Menu.Add(IdentBase + ".useForBufftype", new CheckBox("Use on Bufftype"));
			Menu.AddSeparator();
			Menu.Add(IdentBase + ".onType.Supression", new CheckBox("Supression"));
			Menu.Add(IdentBase + ".onType.Stun", new CheckBox("Stun"));
			Menu.Add(IdentBase + ".onType.Charm", new CheckBox("Charm"));
			Menu.Add(IdentBase + ".onType.Taunt", new CheckBox("Taunt"));
			Menu.Add(IdentBase + ".onType.Flee", new CheckBox("Flee"));
			Menu.Add(IdentBase + ".onType.Fear", new CheckBox("Fear"));
			Menu.Add(IdentBase + ".onType.Snare", new CheckBox("Snare"));
			Menu.Add(IdentBase + ".onType.Polymorph", new CheckBox("Polymorph", false));
			Menu.Add(IdentBase + ".onType.Slow", new CheckBox("Slow", false));
			Menu.Add(IdentBase + ".onType.Silence", new CheckBox("Silence", false));
			Menu.Add(IdentBase + ".onType.Blind", new CheckBox("Blind", false));
			Menu.Add(IdentBase + ".onType.Poison", new CheckBox("Poison", false));
			Menu.AddLabel("Use Against Evil Buffs");
			Menu.Add(IdentBase + ".useonEvilBuff", new CheckBox("Use on Evil Buff"));
			Menu.AddSeparator();
			foreach (
				var buff in
					Buff.BuffList.Where(b => (b.DoT || b.Cleanse) && b.MenuName != null).OrderBy(b => !b.DoT).ThenBy(b => b.MenuName))
			{
				try
				{
					if (buff.ChampionName != null)
						if (!(EntityManager.Heroes.Enemies.Any(u => String.Equals(buff.ChampionName, u.ChampionName, StringComparison.CurrentCultureIgnoreCase))))
							continue;
					Menu.Add(IdentBase + ".uniqueBuff." + buff.MenuName,
						new CheckBox("[" + ((buff.DoT) ? "Dot" : "Danger") + "] -> " + buff.MenuName, buff.DoT));
				}
				catch (Exception)
				{
					//Iggnored ( 2 guys have same summonerspell )
				}
			}
			Menu.AddLabel("Additional Setting");
			Menu.Add(IdentBase + ".minBuffsforUse", new Slider("Use if equals or more then {0} Buffs", 1, 1, 5));
			Menu.Add(IdentBase + ".useAgainstDotsifHP", new Slider("Use against Dots just if Health < {0}%", 30));
			Menu.Add(IdentBase + ".CheckDelay", new Slider("Humanizer Reaction (will react max. {0} ms later)", 0, 0, 500));
			Menu.Add(IdentBase + ".Duration", new Slider("Just Cast if Duration > {0} ms", 300, 0, 1000));
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
				if (Menu[IdentBase + ".justActiveInCombo"].Cast<CheckBox>().CurrentValue &&
				   !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
					return;
				if (!Item.CanUseItem(Id))
					return;
				if (DelayTick + Menu[IdentBase + ".CheckDelay"].Cast<Slider>().CurrentValue >= Core.GameTickCount) return;
				DelayTick = Core.GameTickCount;
				foreach (var buddy in from buddy in EntityManager.Heroes.Allies.Where(CleanserItems.IsActiveForHero) let buffs = GetBuffs(buddy) let longestBufftime = buffs.Select(buff => buff.EndTime - buff.StartTime).Concat(new[] { 0f }).Max() where longestBufftime*1000 >= Menu[IdentBase + ".Duration"].Cast<Slider>().CurrentValue && buffs.Count() >= Menu[IdentBase + ".minBuffsforUse"].Cast<Slider>().CurrentValue where !buddy.IsMe && buddy.Distance(ObjectManager.Player) <= 750 select buddy)
				{
					Item.UseItem(Id, buddy);
					return;
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

		private List<BuffInstance> GetBuffs(AIHeroClient hero)
		{
			var ret = new List<BuffInstance>();
			if (hero.HasBuffOfType(BuffType.Knockup) || hero.HasBuffOfType(BuffType.Knockback))
				return ret;
			if (Menu[IdentBase + ".useForBufftype"].Cast<CheckBox>().CurrentValue)
			{
				if (Menu[IdentBase + ".onType.Supression"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Suppression));
				if (Menu[IdentBase + ".onType.Stun"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Stun));
				if (Menu[IdentBase + ".onType.Charm"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Charm));
				if (Menu[IdentBase + ".onType.Taunt"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Taunt));
				if (Menu[IdentBase + ".onType.Flee"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Flee));
				if (Menu[IdentBase + ".onType.Fear"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Fear));
				if (Menu[IdentBase + ".onType.Snare"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Snare));
				if (Menu[IdentBase + ".onType.Polymorph"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Polymorph));
				if (Menu[IdentBase + ".onType.Slow"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Slow));
				if (Menu[IdentBase + ".onType.Silence"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Silence));
				if (Menu[IdentBase + ".onType.Blind"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Blind));
				if (Menu[IdentBase + ".onType.Poison"].Cast<CheckBox>().CurrentValue)
					ret.AddRange(hero.Buffs.Where(u => u.Type == BuffType.Poison));
			}
			if (!Menu[IdentBase + ".useonEvilBuff"].Cast<CheckBox>().CurrentValue) return ret;
			foreach (var buff in hero.Buffs)
			{
				try
				{
					var existingbuff = buff;
					var buffname = Buff.BuffList.Where(b => b.Name == existingbuff.Name);
					if (Menu[IdentBase + ".uniqueBuff." + buffname].Cast<CheckBox>().CurrentValue && hero.HasBuff(buff.Name) &&
					    !ret.Contains(buff))
						ret.Add(buff);
				}
				catch (Exception)
				{
					//Iggnored (not in list, allready added and so on 
				}
			}
			return ret;
		}
	}
}