using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;

namespace CarryMe_Collection
{
	public static class DamageLibary
	{
		public enum Stage
		{
			Total
		}
		public static float GetDamageSpell(this AIHeroClient hero, Obj_AI_Base target,SpellSlot slot,Stage stage = Stage.Total)
		{
			var SpellLevel = hero.Spellbook.GetSpell(slot).Level - 1;
			if (SpellLevel < 0)
				return 0;

			switch (hero.Hero)
			{
				#region Amumu
				case Champion.Amumu:
					switch (slot)
					{
						case SpellSlot.Q:
							{
								int[] mindmg = { 80, 130, 180, 230, 280 };
								var flatdmg = mindmg[SpellLevel] + hero.TotalMagicalDamage * 0.70f;
								return hero.CalculateDamageOnUnit(target, DamageType.Magical, flatdmg);
							}
					}
					break;
				#endregion
				#region DrMundo
				case Champion.DrMundo:
					switch (slot)
					{
						case SpellSlot.Q:
							{
								int[] mindmg = { 80, 130, 180, 230, 280 };
								int[] maxdmgAgainstMonster = { 300, 400, 500, 600, 700 };
								float[] percentdmg = { 15, 17.5f, 20, 22.5f, 25 };
								var flatdmg = Math.Max(target.Health * (percentdmg[SpellLevel] / 100), mindmg[SpellLevel]);
								if (target.Type != GameObjectType.AIHeroClient)
									flatdmg = Math.Min(flatdmg, maxdmgAgainstMonster[SpellLevel]);
								return hero.CalculateDamageOnUnit(target, DamageType.Magical, flatdmg);
							}
						case SpellSlot.W:
							{
								float[] dmg = { 17.5f, 25, 32.5f, 40, 47.5f };
								var flatdmg = dmg[SpellLevel] + hero.TotalMagicalDamage * 0.10f;
								return hero.CalculateDamageOnUnit(target, DamageType.Magical, flatdmg);
							}
						case SpellSlot.E:
							{
								float[] dmg = { 3, 3.5f, 4, 4.5f, 5 };
								int[] additionalADdmg = {20, 40, 60, 80, 100};
								float[] additionalADdmg2 = {0.2f, 0.4f, 0.6f, 0.8f, 1};
								var flatdmg = additionalADdmg[SpellLevel] + (additionalADdmg2[SpellLevel] * (100 - hero.HealthPercent)) + (hero.MaxHealth * (dmg[SpellLevel] / 100));
								return hero.CalculateDamageOnUnit(target, DamageType.Physical, flatdmg);
							}
					}
					break;
				#endregion
			}
			return 0;
		}
	}
}
