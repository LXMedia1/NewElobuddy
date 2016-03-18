using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy.SDK.Events;

namespace CarryMe_Activator
{
	class Program
	{
		static void Main(string[] args)
		{
			Loading.OnLoadingComplete += OnLoadingComplete;
		}

		private static void OnLoadingComplete(EventArgs args)
		{
			Activator.Load();
		}
	}
}
