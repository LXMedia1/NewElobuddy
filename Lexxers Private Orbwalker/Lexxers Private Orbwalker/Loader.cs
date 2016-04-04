using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

			var Fullpath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			var LibaryFolder = Path.GetFullPath(Path.Combine(Fullpath, @"..\")) + "Libraries";
			var Addons = Directory.EnumerateFiles(LibaryFolder,
										"*", SearchOption.AllDirectories)
			   .Where(s => s.EndsWith(".dll") && s.Contains("LX-Addon."))
			   .ToList();
			if (Addons.Any())
			foreach (var Addon in Addons)
			{
				Console.WriteLine("Load Addon : " + Addon);
			}

		}
	}
}
