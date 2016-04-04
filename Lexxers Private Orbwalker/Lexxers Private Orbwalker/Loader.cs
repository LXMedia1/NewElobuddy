using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lexxers_Private_Orbwalker
{
	class Loader
	{
		internal static void Initiate()
		{
			Orbwalker.Menu.Load();
			Orbwalker.Drawing.Load();
			Orbwalker.Logic.Load();
		}
	}
}
