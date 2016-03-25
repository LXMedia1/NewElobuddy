using EloBuddy.SDK.Events;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarryMe_Collection;
using EloBuddy;

namespace CarryMe_DrMundo
{
	class Program
	{
		static void Main(string[] args)
		{
			Loading.OnLoadingComplete += Loading_OnLoadingComplete;
		}
		private static void Loading_OnLoadingComplete(EventArgs args)
		{
			if (ObjectManager.Player.Hero == Champion.DrMundo)
				new Champions();
		}
	}
}
