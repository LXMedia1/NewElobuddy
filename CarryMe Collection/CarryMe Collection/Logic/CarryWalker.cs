using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarryMe_Collection.Basics;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using MenuBuilder = CarryMe_Collection.Basics.MenuBuilder;

namespace CarryMe_Collection.Logic
{
	internal class CarryWalker : Champion
	{

		internal override void WriteMenuStart()
		{
			base.WriteMenuOrbwalkerStart();
		}

		internal override void OnCombo()
		{
			
		}

	}
}
