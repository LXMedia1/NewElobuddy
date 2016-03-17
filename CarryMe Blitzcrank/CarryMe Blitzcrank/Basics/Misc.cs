using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;

namespace CarryMe_Blitzcrank.Basics
{
	static class Misc
	{
		public static string ToWord( int number)
		{
			if (number == 0)
				return "zero";

			if (number < 0)
				return "minus " + ToWord(Math.Abs(number));

			string words = "";

			if ((number / 1000000) > 0)
			{
				words += ToWord(number / 1000000) + " million ";
				number %= 1000000;
			}

			if ((number / 1000) > 0)
			{
				words += ToWord(number / 1000) + " thousand ";
				number %= 1000;
			}

			if ((number / 100) > 0)
			{
				words += ToWord(number / 100) + " hundred ";
				number %= 100;
			}

			if (number > 0)
			{
				if (words != "")
					words += "and ";

				var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
				var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

				if (number < 20)
					words += unitsMap[number];
				else
				{
					words += tensMap[number / 10];
					if ((number % 10) > 0)
						words += "-" + unitsMap[number % 10];
				}
			}

			return words;
		}

		public static bool IsWithinDistance(this Obj_AI_Base unit,float min, float max)
		{
			var distance = ObjectManager.Player.Distance(unit);
			return min <= distance && distance <= max;
		}
		public static List<string> GetAllPossibleCombos<T>(IEnumerable<T> elements)
		{
			var list = Combinations(elements, 3);
			var retlist = new List<string>();
			foreach (
				var spellstring in
					list.Select(combo => combo.Aggregate("", (current, spell) => current + spell))
						.Where(spellstring => !retlist.Contains(spellstring)))
				retlist.Add(spellstring);
			return retlist;
		}
		public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
		{
			return k == 0 ? new[] { new T[0] } :
			  elements.SelectMany((e, i) =>
				elements.Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
		}
	}
}
