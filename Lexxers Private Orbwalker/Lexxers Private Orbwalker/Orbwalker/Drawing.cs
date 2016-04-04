using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using Color = System.Drawing.Color;

namespace Lexxers_Private_Orbwalker.Orbwalker
{
	class Drawing
	{
		public static AIHeroClient Me;
		internal static void Load()
		{
			Me = ObjectManager.Player;

			EloBuddy.Drawing.OnDraw += OnDraw;
		}

		private static void OnDraw(EventArgs args)
		{
			if (DrawMyHoldArea && HoldArea > 0)
				EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.DarkGray, HoldArea, 2, Me);
			if (DrawMyAARange)
				EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.White, Me.AttackRange + Me.BoundingRadius, 2, Me);
			if (DrawMyAARange)
				EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.White, Me.AttackRange + Me.BoundingRadius, 2, Me);
			if (DrawEnemyBoundingRadius)
				foreach (var enemy in EntityManager.Heroes.Enemies.Where(u => !u.IsDead &&  u.IsValidTarget()))
				{
					EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.DarkOrange, enemy.BoundingRadius, 2, enemy);
				}
			if (DrawEnemyAARange)
				foreach (var enemy in EntityManager.Heroes.Enemies.Where(u => !u.IsDead  && u.IsValidTarget()))
				{
					EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.Black, enemy.AttackRange + enemy.BoundingRadius + Me.BoundingRadius, 2, enemy);
				}
		}


		public static bool DrawEnemyBoundingRadius
		{
			get { return Menu.Config_Drawing["drawEnemyBoundingRadius"].Cast<CheckBox>().CurrentValue; }
		}
		public static bool DrawEnemyAARange
		{
			get { return Menu.Config_Drawing["drawEnemyAARange"].Cast<CheckBox>().CurrentValue; }
		}
		public static bool DrawMyHoldArea
		{
			get { return Menu.Config_Drawing["drawMyHoldArea"].Cast<CheckBox>().CurrentValue; }
		}

		public static bool DrawMyAARange
		{
			get { return Menu.Config_Drawing["drawMyAARange"].Cast<CheckBox>().CurrentValue; }
		}

		public static int HoldArea
		{
			get { return Menu.Config_Extra["holdArea"].Cast<Slider>().CurrentValue; }
		}
	}
}
