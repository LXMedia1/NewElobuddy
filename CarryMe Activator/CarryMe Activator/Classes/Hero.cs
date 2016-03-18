using System.Collections.Generic;
using EloBuddy;
using Enum = CarryMe_Activator.Enums;

namespace CarryMe_Activator.Classes
{
	public class Hero
	{
		public Obj_AI_Base Attacker;
		public List<Enum.HitType> HitTypes = new List<Enum.HitType>();
		public AIHeroClient Player;

		public Hero(AIHeroClient player)
		{
			Player = player;
		}
	}
}