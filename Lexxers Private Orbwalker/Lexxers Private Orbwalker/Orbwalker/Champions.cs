using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;

namespace Lexxers_Private_Orbwalker.Orbwalker
{
	static class Champions
	{
		public static Spell.Active GetSpell_Draven_W()
		{
			return new Spell.Active(SpellSlot.W);
		}

		public static bool IsAutoAttackReset(this GameObjectProcessSpellCastEventArgs args)
		{
			return AutoAttackResetSpellNames.Contains(args.SData.Name);
		}

		public static DamageType GetAutoAttackDamageType(this AIHeroClient unit)
		{
			switch (unit.Hero)
			{
				case Champion.TwistedFate:
					if (unit.HasBuff("BlueCardPreAttack") || unit.HasBuff("GoldCardPreAttack") || unit.HasBuff("RedCardPreAttack"))
						return DamageType.Magical;
					break;
				case Champion.Viktor:
					if (unit.HasBuff("ViktorPowerTransfer"))
						return DamageType.Magical;
					break;
				case Champion.Corki:
					return DamageType.Mixed;
			}
			return DamageType.Physical;
		}

		public static float GetAutoAttackDamageOverride(this Obj_AI_Base Attacker, Obj_AI_Base Target, bool IncludePassive)
		{
			// in case of Bugs or not updated stuff inside the SDK
			if (Attacker != null && Target != null && Attacker.Type == GameObjectType.AIHeroClient)
			{
				var attacker = (AIHeroClient) Attacker;
				switch (attacker.Hero)
				{
					case Champion.MissFortune:
						switch (Target.Type)
						{
							case GameObjectType.AIHeroClient:
								return Attacker.GetAutoAttackDamage(Target, IncludePassive) +
									   Attacker.CalculateDamageOnUnit(Target, DamageType.Physical,
										   Attacker.BaseAttackDamage * (0.5f + (0.5f / 17 * (attacker.Level - 1) * 0.95f)));
							case GameObjectType.obj_AI_Minion:
							case GameObjectType.obj_AI_Turret:
								return Attacker.GetAutoAttackDamage(Target, IncludePassive) +
									   Attacker.CalculateDamageOnUnit(Target, DamageType.Physical,
										   Attacker.BaseAttackDamage * (0.25f + (0.25f / 17 * (attacker.Level - 1) * 0.95f)));
						}
						break;
					case Champion.Thresh:
						if (Attacker.Spellbook.GetSpell(SpellSlot.E).Level >= 1)
						{
							float passivePercent = 0;
							if (Attacker.HasBuff("Threshqpassive1") && Attacker.HasBuff("Threshqpassive2") &&
							    Attacker.HasBuff("Threshqpassive3") && Attacker.HasBuff("Threshqpassive4"))
							{
								if (Attacker.HasBuff("Threshqpassive4"))
									passivePercent = 1;
								else
								{
									var timegone = Game.Time - Attacker.GetBuff("Threshqpassive").StartTime;
									passivePercent = 10/timegone;
								}
								if (passivePercent >= 1)
									passivePercent = 1;

							}
							var souls = Attacker.HasBuff("threshpassivesoulsgain") ? Attacker.GetBuff("threshpassivesoulsgain").Count : 0;
							float[] passive = { 0.8f, 1.1f, 1.4f, 1.7f, 2.0f };
							return Attacker.CalculateDamageOnUnit(Target, DamageType.Physical, Attacker.BaseAttackDamage) +
							       Attacker.CalculateDamageOnUnit(Target, DamageType.Magical,
									   (passivePercent * passive[Attacker.Spellbook.GetSpell(SpellSlot.E).Level]) * attacker.BaseAttackDamage + souls);
						}
						break;

				}
			}
			return Attacker.GetAutoAttackDamage(Target, IncludePassive);
		}

		public static float GetSpellDamageOverride(this AIHeroClient Attacker, Obj_AI_Base Target,SpellSlot slot,DamageLibrary.SpellStages stage = DamageLibrary.SpellStages.Default)
		{
			// in case of Bugs or not updated stuff inside the SDK

			return Attacker.GetSpellDamage(Target, slot, stage);
		}
		private static readonly string[] AutoAttackResetSpellNames =
        {
            "dariusnoxiantacticsonh", "fioraflurry", "garenq",
            "gravesmove", "hecarimrapidslash", "jaxempowertwo", "jaycehypercharge", "leonashieldofdaybreak", "luciane",
            "monkeykingdoubleattack", "mordekaisermaceofspades", "nasusq", "nautiluspiercinggaze", "netherblade",
            "gangplankqwrapper", "poppypassiveattack", "powerfist", "renektonpreexecute", "rengarq",
            "shyvanadoubleattack", "sivirw", "takedown", "talonnoxiandiplomacy", "trundletrollsmash", "vaynetumble",
            "vie", "volibearq", "xenzhaocombotarget", "yorickspectral", "reksaiq", "itemtitanichydracleave", "masochism",
            "illaoiw", "elisespiderw", "fiorae", "meditate", "sejuaninorthernwinds"      
        };
	}
}
