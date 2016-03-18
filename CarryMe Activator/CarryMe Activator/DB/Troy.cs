using System.Collections.Generic;
using CarryMe_Activator.Enums;
using EloBuddy;

namespace CarryMe_Activator.DB
{
	internal class Troy
	{
		public static List<Troy> ActiveTroyList = new List<Troy>();

		public static List<Troy> TroyList = new List<Troy>
		{
			new Troy
			{
				Name = "R_Cas",
				ChampionName = "nunu",
				Radius = 650f,
				Slot = SpellSlot.R,
				HitType = new[] {Enums.HitType.SpellCC},
				PredictDmg = true,
				Interval = 0.75
			},
			new Troy
			{
				Name = "E_mis_bounce",
				ChampionName = "ryze",
				Radius = 200f,
				Slot = SpellSlot.E,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = .75
			},
			new Troy
			{
				Name = "R_E_mis_bounce",
				ChampionName = "ryze",
				Radius = 250f,
				Slot = SpellSlot.E,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = .75
			},
			new Troy
			{
				Name = "Hecarim_Defile",
				ChampionName = "hecarim",
				Radius = 425f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = .75
			},
			new Troy
			{
				Name = "W_AoE",
				ChampionName = "hecarim",
				Radius = 425f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = .75
			},
			new Troy
			{
				Name = "R_AoE",
				ChampionName = "gangplank",
				Radius = 450f,
				Slot = SpellSlot.R,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 1.5
			},
			new Troy
			{
				Name = "W_Shield",
				ChampionName = "diana",
				Radius = 225f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "W_aoe_red",
				ChampionName = "malzahar",
				Radius = 325f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "E_Defile",
				ChampionName = "karthus",
				Radius = 425f,
				Slot = SpellSlot.E,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "W_volatile",
				ChampionName = "elise",
				Radius = 250f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 0.3
			},
			new Troy
			{
				Name = "DarkWind_tar",
				ChampionName = "fiddleSticks",
				Radius = 250f,
				Slot = SpellSlot.E,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 0.8
			},
			new Troy
			{
				Name = "lr_buf",
				ChampionName = "kennen",
				Radius = 250f,
				Slot = SpellSlot.E,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 0.8
			},
			new Troy
			{
				Name = "ss_aoe",
				ChampionName = "kennen",
				Radius = 475f,
				Slot = SpellSlot.R,
				HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
				PredictDmg = true,
				Interval = 0.5
			},
			new Troy
			{
				Name = "Ahri_Base_FoxFire",
				ChampionName = "ahri",
				Radius = 550f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "Fizz_Ring_Red",
				ChampionName = "fizz",
				Radius = 300f,
				Slot = SpellSlot.R,
				DelayFromStart = 800,
				HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "katarina_deathLotus_tar",
				ChampionName = "katarina",
				Radius = 550f,
				Slot = SpellSlot.R,
				HitType = new[] {Enums.HitType.UglyAura, Enums.HitType.DangerSpell},
				PredictDmg = true,
				Interval = 0.5
			},
			new Troy
			{
				Name = "Nautilus_R_sequence_impact",
				ChampionName = "nautilus",
				Radius = 250f,
				Slot = SpellSlot.R,
				HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
				PredictDmg = false,
				Interval = 1.0
			},
			new Troy
			{
				Name = "Acidtrail_buf",
				ChampionName = "singed",
				Radius = 200f,
				Slot = SpellSlot.Q,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 0.5
			},
			new Troy
			{
				Name = "Tremors_cas",
				ChampionName = "rammus",
				Radius = 450f,
				Slot = SpellSlot.R,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "Crowstorm",
				ChampionName = "fiddleSticks",
				Radius = 425f,
				Slot = SpellSlot.R,
				HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell, Enums.HitType.UglyAura},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "yordleTrap_idle",
				ChampionName = "caitlyn",
				Radius = 265f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.SpellCC},
				PredictDmg = false,
				Interval = 1.0
			},
			new Troy
			{
				Name = "tar_aoe_red",
				ChampionName = "lux",
				Radius = 400f,
				Slot = SpellSlot.E,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 2.0
			},
			new Troy
			{
				Name = "Viktor_ChaosStorm",
				ChampionName = "viktor",
				Radius = 425f,
				Slot = SpellSlot.R,
				HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "Viktor_Catalyst",
				ChampionName = "viktor",
				Radius = 375f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.SpellCC},
				PredictDmg = false,
				Interval = 1.0
			},
			new Troy
			{
				Name = "W_AUG",
				ChampionName = "viktor",
				Radius = 375f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.SpellCC},
				PredictDmg = false,
				Interval = 1.0
			},
			new Troy
			{
				Name = "cryo_storm",
				ChampionName = "anivia",
				Radius = 400f,
				Slot = SpellSlot.R,
				HitType = new[] {Enums.HitType.SpellCC},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "ZiggsE",
				ChampionName = "ziggs",
				Radius = 325f,
				Slot = SpellSlot.E,
				HitType = new[] {Enums.HitType.SpellCC},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "ZiggsWRing",
				ChampionName = "ziggs",
				Radius = 325f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.SpellCC},
				PredictDmg = false,
				Interval = 1.0
			},
			new Troy
			{
				Name = "W_Miasma_tar",
				ChampionName = "cassiopeia",
				Radius = 365f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "E_rune",
				ChampionName = "soraka",
				Radius = 375f,
				Slot = SpellSlot.E,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = 1.0
			},
			new Troy
			{
				Name = "W_Tar",
				ChampionName = "morgana",
				Radius = 275f,
				Slot = SpellSlot.W,
				HitType = new[] {Enums.HitType.None},
				PredictDmg = true,
				Interval = .75
			}
		};

		public string ChampionName;
		public int DelayFromStart;
		public HitType[] HitType;
		public double Interval;
		public string Name;
		public bool PredictDmg;
		public float Radius;
		public SpellSlot Slot;
	}
}