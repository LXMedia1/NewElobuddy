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

			return Attacker.GetAutoAttackDamage(Target, IncludePassive);
		}

		public static float GetSpellDamageOverride(this AIHeroClient Attacker, Obj_AI_Base Target,SpellSlot slot,DamageLibrary.SpellStages stage = DamageLibrary.SpellStages.Default)
		{
			// in case of Bugs or not updated stuff inside the SDK

			return Attacker.GetSpellDamage(Target, slot, stage);
		}
	}
}
