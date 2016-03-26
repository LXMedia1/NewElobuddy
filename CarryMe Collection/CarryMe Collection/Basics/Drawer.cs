using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace CarryMe_Collection.Basics
{
	static class Drawer
	{
		public enum DrawType
		{
			Skillshot,
			Active
		}

		internal class DrawRange
		{
			public  DrawType Type;
			public  Spell.Skillshot Spell_Skillshot;
			public  Spell.Active Spell_Active;
			public  CheckBox CheckBox;
			public  DrawRange(Spell.Skillshot spell, CheckBox checkbox)
			{
				Type = DrawType.Skillshot;
				Spell_Skillshot = spell;
				CheckBox = checkbox;
				Drawing.OnDraw += OnDraw;
			}

			public DrawRange(Spell.Active spell, CheckBox checkbox)
			{
				Type = DrawType.Active;
				Spell_Active = spell;
				CheckBox = checkbox;
				Drawing.OnDraw += OnDraw;
			}

			private void OnDraw(EventArgs args)
			{
				if (!CheckBox.CurrentValue)
					return;
				switch (Type)
				{
					case DrawType.Skillshot:
						if (Spell_Skillshot.IsLearned)
						{
							EloBuddy.SDK.Rendering.Circle.Draw(Spell_Skillshot.IsReady() ? SharpDX.Color.DarkGreen : SharpDX.Color.DarkRed,Spell_Skillshot.Range,2,ObjectManager.Player);
						}
						break;
					case DrawType.Active:
						if (Spell_Active.IsLearned)
						{
							EloBuddy.SDK.Rendering.Circle.Draw(Spell_Active.IsReady() ? SharpDX.Color.DarkGreen : SharpDX.Color.DarkRed, Spell_Active.Range,2, ObjectManager.Player);
						}
						break;
				}

			}
		}
	}
}
