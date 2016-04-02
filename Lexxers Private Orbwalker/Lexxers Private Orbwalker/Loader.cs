using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexxers_Private_Orbwalker
{
	class Loader
	{
		internal static void Initiate()
		{
			Orbwalker.Menu.Load();

			Orbwalker.Logic.Load();
		}
	}
}
