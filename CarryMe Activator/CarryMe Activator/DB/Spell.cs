using System.Collections.Generic;
using System.Linq;
using CarryMe_Activator.Enums;
using EloBuddy;

namespace CarryMe_Activator.DB
{
	internal class Spell
	{
		public static List<Spell> ActiveSpellList = new List<Spell>(); 
		public float CastRange;
		public string ChampionName;
		public float Delay;
		public string[] ExtraMissileNames;
		public bool FixedRange;
		public string[] FromObject;
		public bool Global;
		public HitType[] HitType;
		public string MissileName;
		public int MissileSpeed;
		public string SDataName;
		public SpellSlot Slot;

		public  Spell GetByMissileName(string missilename)
		{
			return
				SpellList.FirstOrDefault(
					sdata =>
						sdata.MissileName != null && sdata.MissileName.ToLower() == missilename ||
						sdata.ExtraMissileNames != null && sdata.ExtraMissileNames.Contains(missilename));
		}

		public static List<Spell> SpellList = new List<Spell>
			{
				new Spell
				{
					SDataName = "aatroxq",
					ChampionName = "aatrox",
					Slot = SpellSlot.Q,
					CastRange = 875,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "",
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "aatroxw",
					ChampionName = "aatrox",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "aatroxw2",
					ChampionName = "aatrox",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "aatroxe",
					ChampionName = "aatrox",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1025,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "aatroxeconemissile",
					MissileSpeed = 1250
				},
				new Spell
				{
					SDataName = "aatroxr",
					ChampionName = "aatrox",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "ahriorbofdeception",
					ChampionName = "ahri",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 900,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "ahriorbmissile",
					ExtraMissileNames = new[] {"ahriorbreturn"},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "ahrifoxfire",
					ChampionName = "ahri",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 550,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1800
				},
				new Spell
				{
					SDataName = "ahriseduce",
					ChampionName = "ahri",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 975,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "ahriseducemissile",
					MissileSpeed = 1550
				},
				new Spell
				{
					SDataName = "ahritumble",
					ChampionName = "ahri",
					Slot = SpellSlot.R,
					CastRange = 600,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "akalimota",
					ChampionName = "akali",
					Slot = SpellSlot.Q,
					CastRange = 600,
					Delay = 650,
					HitType = new HitType[] {},
					MissileSpeed = 1000
				},
				new Spell
				{
					SDataName = "akalismokebomb",
					ChampionName = "akali",
					Slot = SpellSlot.W,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.Stealth},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "akalishadowswipe",
					ChampionName = "akali",
					Slot = SpellSlot.E,
					CastRange = 325,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "akalishadowdance",
					ChampionName = "akali",
					Slot = SpellSlot.R,
					CastRange = 710,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "pulverize",
					ChampionName = "alistar",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 365,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "headbutt",
					ChampionName = "alistar",
					Slot = SpellSlot.W,
					CastRange = 660,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "triumphantroar",
					ChampionName = "alistar",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "feroucioushowl",
					ChampionName = "alistar",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "bandagetoss",
					ChampionName = "amumu",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1100,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "sadmummybandagetoss",
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "auraofdespair",
					ChampionName = "amumu",
					Slot = SpellSlot.W,
					CastRange = 300,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "tantrum",
					ChampionName = "amumu",
					Slot = SpellSlot.E,
					CastRange = 350,
					Delay = 150,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "curseofthesadmummy",
					ChampionName = "amumu",
					Slot = SpellSlot.R,
					CastRange = 560,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "flashfrost",
					ChampionName = "anivia",
					Slot = SpellSlot.Q,
					CastRange = 1150,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "flashfrostspell",
					MissileSpeed = 850
				},
				new Spell
				{
					SDataName = "crystalize",
					ChampionName = "anivia",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "frostbite",
					ChampionName = "anivia",
					Slot = SpellSlot.E,
					CastRange = 650,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "glacialstorm",
					ChampionName = "anivia",
					Slot = SpellSlot.R,
					CastRange = 625,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "disintegrate",
					ChampionName = "annie",
					Slot = SpellSlot.Q,
					CastRange = 625,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "incinerate",
					ChampionName = "annie",
					Slot = SpellSlot.W,
					CastRange = 625,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "moltenshield",
					ChampionName = "annie",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "infernalguardian",
					ChampionName = "annie",
					Slot = SpellSlot.R,
					CastRange = 900, 
					Delay = 0,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "frostshot",
					ChampionName = "ashe",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "frostarrow",
					ChampionName = "ashe",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 0,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "volley",
					ChampionName = "ashe",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 1200,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "volleyattack",
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "ashespiritofthehawk",
					ChampionName = "ashe",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "enchantedcrystalarrow",
					ChampionName = "ashe",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 20000,
					Global = true,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "enchantedcrystalarrow",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "azirq",
					ChampionName = "azir",
					Slot = SpellSlot.Q,
					CastRange = 875,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "azirsoldiermissile",
					FromObject = new[] {"AzirSoldier"},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "azirr",
					ChampionName = "azir",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 475,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "bardq",
					ChampionName = "bard",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 950,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "bardqmissile",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "bardw",
					ChampionName = "bard",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "barde",
					ChampionName = "bard",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 350,
					HitType = new HitType[] {},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "bardr",
					ChampionName = "bard",
					Slot = SpellSlot.R,
					CastRange = 3400,
					Delay = 450,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "bardr",
					MissileSpeed = 2100
				},
				new Spell
				{
					SDataName = "rocketgrabmissile",
					ChampionName = "blitzcrank",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1050,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileSpeed = 1800
				},
				new Spell
				{
					SDataName = "overdrive",
					ChampionName = "blitzcrank",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "powerfist",
					ChampionName = "blitzcrank",
					Slot = SpellSlot.E,
					CastRange = 100,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "staticfield",
					ChampionName = "blitzcrank",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "brandblaze",
					ChampionName = "brand",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1150,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "brandblazemissile",
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "brandfissure",
					ChampionName = "brand",
					Slot = SpellSlot.W,
					CastRange = 240,
					Delay = 550,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "",
					MissileSpeed = 20
				},
				new Spell
				{
					SDataName = "brandconflagration",
					ChampionName = "brand",
					Slot = SpellSlot.E,
					CastRange = 625,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "brandwildfire",
					ChampionName = "brand",
					Slot = SpellSlot.R,
					CastRange = 750,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileSpeed = 1000
				},
				new Spell
				{
					SDataName = "braumq",
					ChampionName = "braum",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1100,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "braumqmissile",
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "braumqmissle",
					ChampionName = "braum",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1100,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "braumw",
					ChampionName = "braum",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "braume",
					ChampionName = "braum",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "braumrwrapper",
					ChampionName = "braum",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 1250,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "braumrmissile",
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "caitlynpiltoverpeacemaker",
					ChampionName = "caitlyn",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 2000,
					Delay = 625,
					HitType = new HitType[] {},
					MissileName = "caitlynpiltoverpeacemaker",
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "caitlynyordletrap",
					ChampionName = "caitlyn",
					Slot = SpellSlot.W,
					CastRange = 800,
					Delay = 550,
					HitType = new HitType[] {},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "caitlynentrapment",
					ChampionName = "caitlyn",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1050,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "caitlynentrapmentmissile",
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "cassiopeianoxiousblast",
					ChampionName = "cassiopeia",
					Slot = SpellSlot.Q,
					CastRange = 925,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "cassiopeianoxiousblast",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "cassiopeiamiasma",
					ChampionName = "cassiopeia",
					Slot = SpellSlot.W,
					CastRange = 925,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 2500
				},
				new Spell
				{
					SDataName = "cassiopeiatwinfang",
					ChampionName = "cassiopeia",
					Slot = SpellSlot.E,
					CastRange = 700,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1900
				},
				new Spell
				{
					SDataName = "cassiopeiapetrifyinggaze",
					ChampionName = "cassiopeia",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 875,
					Delay = 350,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "cassiopeiapetrifyinggaze",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "rupture",
					ChampionName = "chogath",
					Slot = SpellSlot.Q,
					CastRange = 950,
					Delay = 1000,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "rupture",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "feralscream",
					ChampionName = "chogath",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 675,
					Delay = 175,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "vorpalspikes",
					ChampionName = "chogath",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = 347
				},
				new Spell
				{
					SDataName = "feast",
					ChampionName = "chogath",
					Slot = SpellSlot.R,
					CastRange = 500,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "phosphorusbomb",
					ChampionName = "corki",
					Slot = SpellSlot.Q,
					CastRange = 875,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "phosphorusbombmissile",
					MissileSpeed = 1125
				},
				new Spell
				{
					SDataName = "carpetbomb",
					ChampionName = "corki",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = 700
				},
				new Spell
				{
					SDataName = "ggun",
					ChampionName = "corki",
					Slot = SpellSlot.E,
					CastRange = 750,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "missilebarrage",
					ChampionName = "corki",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 1225,
					Delay = 150,
					HitType = new HitType[] {},
					MissileName = "missilebarragemissile",
					ExtraMissileNames = new[] {"missilebarragemissile2"},
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "dariuscleave",
					ChampionName = "darius",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 425,
					Delay = 750,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "dariusnoxiantacticsonh",
					ChampionName = "darius",
					Slot = SpellSlot.W,
					CastRange = 205,
					Delay = 150,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "dariusaxegrabcone",
					ChampionName = "darius",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 555,
					Delay = 150,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileName = "dariusaxegrabcone",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "dariusexecute",
					ChampionName = "darius",
					Slot = SpellSlot.R,
					CastRange = 465,
					Delay = 450,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "dianaarc",
					ChampionName = "diana",
					Slot = SpellSlot.Q,
					CastRange = 830,
					Delay = 300,
					HitType = new HitType[] {},
					MissileName = "dianaarc",
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "dianaorbs",
					ChampionName = "diana",
					Slot = SpellSlot.W,
					CastRange = 200,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "dianavortex",
					ChampionName = "diana",
					Slot = SpellSlot.E,
					CastRange = 350,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "dianateleport",
					ChampionName = "diana",
					Slot = SpellSlot.R,
					CastRange = 825,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "dravenspinning",
					ChampionName = "draven",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "dravenfury",
					ChampionName = "draven",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "dravendoubleshot",
					ChampionName = "draven",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1050,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "dravendoubleshotmissile",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "dravenrcast",
					ChampionName = "draven",
					Slot = SpellSlot.R,
					CastRange = 20000,
					Global = true,
					Delay = 500,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileName = "dravenr",
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "infectedcleavermissilecast",
					ChampionName = "drmundo",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "infectedcleavermissile",
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "burningagony",
					ChampionName = "drmundo",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "masochism",
					ChampionName = "drmundo",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "sadism",
					ChampionName = "drmundo",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "ekkoq",
					ChampionName = "ekko",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1075,
					Delay = 66,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "ekkoqmis",
					ExtraMissileNames = new[] {"ekkoqreturn"},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "ekkoeattack",
					ChampionName = "ekko",
					Slot = SpellSlot.E,
					CastRange = 300,
					Delay = 0,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "ekkor",
					ChampionName = "ekko",
					Slot = SpellSlot.R,
					CastRange = 425,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					FromObject = new[] {"Ekko_Base_R_TrailEnd"},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "elisehumanq",
					ChampionName = "elise",
					Slot = SpellSlot.Q,
					CastRange = 625,
					Delay = 550,
					HitType = new HitType[] {},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "elisespiderqcast",
					ChampionName = "elise",
					Slot = SpellSlot.Q,
					CastRange = 475,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "elisehumanw",
					ChampionName = "elise",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 750,
					HitType = new HitType[] {},
					MissileSpeed = 5000
				},
				new Spell
				{
					SDataName = "elisespiderw",
					ChampionName = "elise",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "elisehumane",
					ChampionName = "elise",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1075,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileName = "elisehumane",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "elisespidereinitial",
					ChampionName = "elise",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "elisespideredescent",
					ChampionName = "elise",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "eliser",
					ChampionName = "elise",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "elisespiderr",
					ChampionName = "elise",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "evelynnq",
					ChampionName = "evelynn",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 500,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "evelynnw",
					ChampionName = "evelynn",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "evelynne",
					ChampionName = "evelynn",
					Slot = SpellSlot.E,
					CastRange = 225,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "evelynnr",
					ChampionName = "evelynn",
					Slot = SpellSlot.R,
					CastRange = 900,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "evelynnr",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "ezrealmysticshot",
					ChampionName = "ezreal",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1150,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "ezrealmysticshotmissile",
					ExtraMissileNames = new[] {"ezrealmysticshotpulsemissile"},
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "ezrealessenceflux",
					ChampionName = "ezreal",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 1050,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "ezrealessencefluxmissile",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "ezrealessencemissle",
					ChampionName = "ezreal",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 1050,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "ezrealarcaneshift",
					ChampionName = "ezreal",
					Slot = SpellSlot.E,
					CastRange = 750, 
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "ezrealtrueshotbarrage",
					ChampionName = "ezreal",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 20000,
					Global = true,
					Delay = 1000,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileName = "ezrealtrueshotbarrage",
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "terrify",
					ChampionName = "fiddlesticks",
					Slot = SpellSlot.Q,
					CastRange = 575,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "drain",
					ChampionName = "fiddlesticks",
					Slot = SpellSlot.W,
					CastRange = 575,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "fiddlesticksdarkwind",
					ChampionName = "fiddlesticks",
					Slot = SpellSlot.E,
					CastRange = 750,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1100
				},
				new Spell
				{
					SDataName = "crowstorm",
					ChampionName = "fiddlesticks",
					Slot = SpellSlot.R,
					CastRange = 800,
					Delay = 250,
					HitType = new[] {Enums.HitType.UglyAura},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "fioraq",
					ChampionName = "fiora",
					Slot = SpellSlot.Q,
					CastRange = 400,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "fioraw",
					ChampionName = "fiora",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 750,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "fiorae",
					ChampionName = "fiora",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "fiorar",
					ChampionName = "fiora",
					Slot = SpellSlot.R,
					CastRange = 500,
					Delay = 150,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "fizzpiercingstrike",
					ChampionName = "fizz",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 550,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1900
				},
				new Spell
				{
					SDataName = "fizzseastonepassive",
					ChampionName = "fizz",
					Slot = SpellSlot.W,
					CastRange = 175,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "fizzjump",
					ChampionName = "fizz",
					Slot = SpellSlot.E,
					CastRange = 450,
					Delay = 700,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "fizzjumpbuffer",
					ChampionName = "fizz",
					Slot = SpellSlot.E,
					CastRange = 330,
					Delay = 0,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "fizzjumptwo",
					ChampionName = "fizz",
					Slot = SpellSlot.E,
					CastRange = 270,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "fizzmarinerdoom",
					ChampionName = "fizz",
					Slot = SpellSlot.R,
					CastRange = 1275,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "fizzmarinerdoommissile",
					MissileSpeed = 1350
				},
				new Spell
				{
					SDataName = "galioresolutesmite",
					ChampionName = "galio",
					Slot = SpellSlot.Q,
					CastRange = 1040,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "galioresolutesmite",
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "galiobulwark",
					ChampionName = "galio",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "galiorighteousgust",
					ChampionName = "galio",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1280,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "galiorighteousgust",
					MissileSpeed = 1300
				},
				new Spell
				{
					SDataName = "galioidolofdurand",
					ChampionName = "galio",
					Slot = SpellSlot.R,
					CastRange = 600,
					Delay = 0,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "gangplankqwrapper",
					ChampionName = "gangplank",
					Slot = SpellSlot.Q,
					CastRange = 625,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "gangplankqproceed",
					ChampionName = "gangplank",
					Slot = SpellSlot.Q,
					CastRange = 625,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "gangplankw",
					ChampionName = "gangplank",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "gangplanke",
					ChampionName = "gangplank",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "gangplankr",
					ChampionName = "gangplank",
					Slot = SpellSlot.R,
					CastRange = 20000,
					Global = true,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "garenq",
					ChampionName = "garen",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 300,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "garenqattack",
					ChampionName = "garen",
					Slot = SpellSlot.Q,
					CastRange = 350,
					Delay = 0,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "gnarq",
					ChampionName = "gnar",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1185,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 2400,
					MissileName = "gnarqmissile",
					ExtraMissileNames = new[] {"gnarqmissilereturn"}
				},
				new Spell
				{
					SDataName = "gnarbigq",
					ChampionName = "gnar",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1150,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 2000,
					MissileName = "gnarbigqmissile"
				},
				new Spell
				{
					SDataName = "gnarbigw",
					ChampionName = "gnar",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 600,
					Delay = 600,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "gnarult",
					ChampionName = "gnar",
					CastRange = 600, 
					Slot = SpellSlot.R,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "garenw",
					ChampionName = "garen",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "garene",
					ChampionName = "garen",
					Slot = SpellSlot.E,
					CastRange = 300,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "garenr",
					ChampionName = "garen",
					Slot = SpellSlot.R,
					CastRange = 400,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "gragasq",
					ChampionName = "gragas",
					Slot = SpellSlot.Q,
					CastRange = 1000, 
					Delay = 500,
					HitType = new HitType[] {},
					MissileName = "gragasqmissile",
					MissileSpeed = 1000
				},
				new Spell
				{
					SDataName = "gragasqtoggle",
					ChampionName = "gragas",
					Slot = SpellSlot.Q,
					CastRange = 1100,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "gragasw",
					ChampionName = "gragas",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "gragase",
					ChampionName = "gragas",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 600,
					Delay = 200,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "gragase",
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "gragasr",
					ChampionName = "gragas",
					Slot = SpellSlot.R,
					CastRange = 1150,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "gragasrboom",
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "gravesq",
					ChampionName = "graves",
					Slot = SpellSlot.Q,
					CastRange = 1025,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "gravesclustershotattack",
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "gravesw",
					ChampionName = "graves",
					Slot = SpellSlot.W,
					CastRange = 1100, 
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1350
				},
				new Spell
				{
					SDataName = "gravese",
					ChampionName = "graves",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 300,
					HitType = new HitType[] {},
					MissileSpeed = 1000
				},
				new Spell
				{
					SDataName = "gravesr",
					ChampionName = "graves",
					Slot = SpellSlot.R,
					CastRange = 1000,
					FixedRange = true,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileName = "graveschargeshotshot",
					MissileSpeed = 2100
				},
				new Spell
				{
					SDataName = "hecarimrapidslash",
					ChampionName = "hecarim",
					Slot = SpellSlot.Q,
					CastRange = 350,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "hecarimw",
					ChampionName = "hecarim",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "hecarimramp",
					ChampionName = "hecarim",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "hecarimult",
					ChampionName = "hecarim",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 1350,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "hecarimultmissilesknr1",
					ExtraMissileNames =
						new[]
						{
							"hecarimultmissileskn4r1", "hecarimultmissileskn4r2", "hecarimultmissileskn411",
							"hecarimultmissileskn412"
						},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "heimerdingerturretenergyblast",
					ChampionName = "heimerdinger",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1000,
					Delay = 435,
					HitType = new HitType[] {},
					FromObject = new[] {"heimerdinger_turret_idle"},
					MissileSpeed = 1650
				},
				new Spell
				{
					SDataName = "heimerdingerturretbigenergyblast",
					ChampionName = "heimerdinger",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1000,
					Delay = 350,
					HitType = new HitType[] {},
					FromObject = new[] {"heimerdinger_base_r"},
					MissileSpeed = 1650
				},
				new Spell
				{
					SDataName = "heimerdingerw",
					ChampionName = "heimerdinger",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 1100,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "heimerdingere",
					ChampionName = "heimerdinger",
					Slot = SpellSlot.E,
					CastRange = 1025, 
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "heimerdingerespell",
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "heimerdingerr",
					ChampionName = "heimerdinger",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 230,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "heimerdingereult",
					ChampionName = "heimerdinger",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1450,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "ireliagatotsu",
					ChampionName = "irelia",
					Slot = SpellSlot.Q,
					CastRange = 650,
					Delay = 150,
					HitType = new HitType[] {},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "ireliahitenstyle",
					ChampionName = "irelia",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 230,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "ireliaequilibriumstrike",
					ChampionName = "irelia",
					Slot = SpellSlot.E,
					CastRange = 450,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "ireliatranscendentblades",
					ChampionName = "irelia",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 1200,
					Delay = 0,
					HitType = new HitType[] {},
					MissileName = "ireliatranscendentbladesspell",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "illaoiq",
					ChampionName = "illaoi",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 950,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "illaoiemis",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "illaoiw",
					ChampionName = "illaoi",
					Slot = SpellSlot.W,
					CastRange = 365,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "illaoie",
					ChampionName = "illaoi",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 950,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "illaoiemis",
					MissileSpeed = 1900
				},
				new Spell
				{
					SDataName = "illaoir",
					ChampionName = "illaoi",
					Slot = SpellSlot.R,
					CastRange = 450,
					Delay = 500,
					HitType = new[] {Enums.HitType.KillSpell, Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "howlinggalespell",
					ChampionName = "janna",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1550,
					Delay = 0,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "howlinggalespell",
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "sowthewind",
					ChampionName = "janna",
					Slot = SpellSlot.W,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "eyeofthestorm",
					ChampionName = "janna",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "reapthewhirlwind",
					ChampionName = "janna",
					Slot = SpellSlot.R,
					CastRange = 725,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jarvanivdragonstrike",
					ChampionName = "jarvaniv",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 700,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "",
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "jarvanivgoldenaegis",
					ChampionName = "jarvaniv",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jarvanivdemacianstandard",
					ChampionName = "jarvaniv",
					Slot = SpellSlot.E,
					CastRange = 830,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "jarvanivdemacianstandard",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jarvanivcataclysm",
					ChampionName = "jarvaniv",
					Slot = SpellSlot.R,
					CastRange = 825,
					Delay = 0,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jaxleapstrike",
					ChampionName = "jax",
					Slot = SpellSlot.Q,
					CastRange = 700,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "jaxempowertwo",
					ChampionName = "jax",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jaxrelentlessasssault",
					ChampionName = "jax",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jaycetotheskies",
					ChampionName = "jayce",
					Slot = SpellSlot.Q,
					CastRange = 600,
					Delay = 450,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jayceshockblast",
					ChampionName = "jayce",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1570,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileName = "jayceshockblastmis",
					MissileSpeed = 2350
				},
				new Spell
				{
					SDataName = "jaycestaticfield",
					ChampionName = "jayce",
					Slot = SpellSlot.W,
					CastRange = 285,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "jaycehypercharge",
					ChampionName = "jayce",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 750,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jaycethunderingblow",
					ChampionName = "jayce",
					Slot = SpellSlot.E,
					CastRange = 325,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jayceaccelerationgate",
					ChampionName = "jayce",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "jaycestancehtg",
					ChampionName = "jayce",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 750,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jaycestancegth",
					ChampionName = "jayce",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 750,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jhinq",
					ChampionName = "jhin",
					Slot = SpellSlot.Q,
					CastRange = 575,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "jhinq",
					ChampionName = "jhin",
					Slot = SpellSlot.W,
					CastRange = 2250,
					Delay = 750,
					FixedRange = true,
					HitType = new HitType[] {},
					MissileName = "jhinwmissile",
					MissileSpeed = 5000
				},
				new Spell
				{
					SDataName = "jhine",
					ChampionName = "jhin",
					Slot = SpellSlot.E,
					CastRange = 2250,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "jhinrshot",
					ChampionName = "jhin",
					Slot = SpellSlot.R,
					CastRange = 3500,
					Delay = 250,
					FixedRange = true,
					MissileName = "jhinrshotmis",
					HitType = new HitType[] {},
					ExtraMissileNames = new[] {"jhinRMissile"},
					MissileSpeed = 5000
				},
				new Spell
				{
					SDataName = "jinxq",
					ChampionName = "jinx",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jinxw",
					ChampionName = "jinx",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 1550,
					Delay = 600,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "jinxwmissile",
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "jinxe",
					ChampionName = "jinx",
					Slot = SpellSlot.E,
					CastRange = 900,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1000
				},
				new Spell
				{
					SDataName = "jinxr",
					ChampionName = "jinx",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 25000,
					Global = true,
					Delay = 600,
					MissileName = "jinxr",
					ExtraMissileNames = new[] {"jinxrwrapper"},
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileSpeed = 1700
				},
				new Spell
				{
					SDataName = "karmaq",
					ChampionName = "karma",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1050,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "karmaqmissile",
					MissileSpeed = 1800
				},
				new Spell
				{
					SDataName = "karmaspiritbind",
					ChampionName = "karma",
					Slot = SpellSlot.W,
					CastRange = 800,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "karmasolkimshield",
					ChampionName = "karma",
					Slot = SpellSlot.E,
					CastRange = 800,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "karmamantra",
					ChampionName = "karma",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1300
				},
				new Spell
				{
					SDataName = "laywaste",
					ChampionName = "karthus",
					Slot = SpellSlot.Q,
					CastRange = 875,
					Delay = 900,
					HitType = new HitType[] {},
					ExtraMissileNames = new[]
					{
						"karthuslaywastea3", "karthuslaywastea1", "karthuslaywastedeada1", "karthuslaywastedeada2",
						"karthuslaywastedeada3"
					},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "wallofpain",
					ChampionName = "karthus",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "defile",
					ChampionName = "karthus",
					Slot = SpellSlot.E,
					CastRange = 550,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1000
				},
				new Spell
				{
					SDataName = "fallenone",
					ChampionName = "karthus",
					Slot = SpellSlot.R,
					CastRange = 22000,
					Global = true,
					Delay = 2800,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "nulllance",
					ChampionName = "kassadin",
					Slot = SpellSlot.Q,
					CastRange = 650,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileSpeed = 1900
				},
				new Spell
				{
					SDataName = "netherblade",
					ChampionName = "kassadin",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "forcepulse",
					ChampionName = "kassadin",
					Slot = SpellSlot.E,
					CastRange = 700,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "riftwalk",
					ChampionName = "kassadin",
					Slot = SpellSlot.R,
					CastRange = 675,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "riftwalk",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "katarinaq",
					ChampionName = "katarina",
					Slot = SpellSlot.Q,
					CastRange = 675,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1800
				},
				new Spell
				{
					SDataName = "katarinaw",
					ChampionName = "katarina",
					Slot = SpellSlot.W,
					CastRange = 400,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1800
				},
				new Spell
				{
					SDataName = "katarinae",
					ChampionName = "katarina",
					Slot = SpellSlot.E,
					CastRange = 700,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "katarinar",
					ChampionName = "katarina",
					Slot = SpellSlot.R,
					CastRange = 550,
					Delay = 250,
					HitType = new[] {Enums.HitType.UglyAura},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "judicatorreckoning",
					ChampionName = "kayle",
					Slot = SpellSlot.Q,
					CastRange = 650,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "judicatordevineblessing",
					ChampionName = "kayle",
					Slot = SpellSlot.W,
					CastRange = 900,
					Delay = 220,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "judicatorrighteousfury",
					ChampionName = "kayle",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "judicatorintervention",
					ChampionName = "kayle",
					Slot = SpellSlot.R,
					CastRange = 900,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "kennenshurikenhurlmissile1",
					ChampionName = "kennen",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1175,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "kennenshurikenhurlmissile1",
					MissileSpeed = 1700
				},
				new Spell
				{
					SDataName = "kennenbringthelight",
					ChampionName = "kennen",
					Slot = SpellSlot.W,
					CastRange = 900,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "kennenlightningrush",
					ChampionName = "kennen",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "kennenshurikenstorm",
					ChampionName = "kennen",
					Slot = SpellSlot.R,
					CastRange = 550,
					Delay = 500,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "khazixq",
					ChampionName = "khazix",
					Slot = SpellSlot.Q,
					CastRange = 325,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "khazixqlong",
					ChampionName = "khazix",
					Slot = SpellSlot.Q,
					CastRange = 375,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "khazixw",
					ChampionName = "khazix",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "khazixwmissile",
					MissileSpeed = 81700
				},
				new Spell
				{
					SDataName = "khazixwlong",
					ChampionName = "khazix",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1700
				},
				new Spell
				{
					SDataName = "khazixe",
					ChampionName = "khazix",
					Slot = SpellSlot.E,
					CastRange = 600,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "khazixe",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "khazixelong",
					ChampionName = "khazix",
					Slot = SpellSlot.E,
					CastRange = 900,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "khazixr",
					ChampionName = "khazix",
					Slot = SpellSlot.R,
					CastRange = 1000,
					Delay = 0,
					HitType = new[] {Enums.HitType.Stealth},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "khazixrlong",
					ChampionName = "khazix",
					Slot = SpellSlot.R,
					CastRange = 1000,
					Delay = 0,
					HitType = new[] {Enums.HitType.Stealth},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "kindredq",
					ChampionName = "kindred",
					Slot = SpellSlot.Q,
					CastRange = 350,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "kindrede",
					ChampionName = "kindred",
					Slot = SpellSlot.E,
					CastRange = 510,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "kogmawq",
					ChampionName = "kogmaw",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1300,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "kogmawq",
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "kogmawbioarcanebarrage",
					ChampionName = "kogmaw",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "kogmawvoidooze",
					ChampionName = "kogmaw",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1150,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "kogmawvoidoozemissile",
					MissileSpeed = 1250
				},
				new Spell
				{
					SDataName = "kogmawlivingartillery",
					ChampionName = "kogmaw",
					Slot = SpellSlot.R,
					CastRange = 2200,
					Delay = 1200,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "kogmawlivingartillery",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "leblancchaosorb",
					ChampionName = "leblanc",
					Slot = SpellSlot.Q,
					CastRange = 700,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "leblancslide",
					ChampionName = "leblanc",
					Slot = SpellSlot.W,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "leblancslide",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "leblacslidereturn",
					ChampionName = "leblanc",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "leblancsoulshackle",
					ChampionName = "leblanc",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 925,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "leblancsoulshackle",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "leblancchaosorbm",
					ChampionName = "leblanc",
					Slot = SpellSlot.R,
					CastRange = 700,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "leblancslidem",
					ChampionName = "leblanc",
					Slot = SpellSlot.R,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileName = "leblancslidem",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "leblancslidereturnm",
					ChampionName = "leblanc",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "leblancsoulshacklem",
					ChampionName = "leblanc",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 925,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "leblancsoulshacklem",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "blindmonkqone",
					ChampionName = "leesin",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "blindmonkqone",
					MissileSpeed = 1800
				},
				new Spell
				{
					SDataName = "blindmonkqtwo",
					ChampionName = "leesin",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "blindmonkwone",
					ChampionName = "leesin",
					Slot = SpellSlot.W,
					CastRange = 700,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "blindmonkwtwo",
					ChampionName = "leesin",
					Slot = SpellSlot.W,
					CastRange = 700,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "blindmonkeone",
					ChampionName = "leesin",
					Slot = SpellSlot.E,
					CastRange = 425,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "blindmonketwo",
					ChampionName = "leesin",
					Slot = SpellSlot.E,
					CastRange = 350,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "blindmonkrkick",
					ChampionName = "leesin",
					Slot = SpellSlot.R,
					CastRange = 375,
					Delay = 500,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "leonashieldofdaybreak",
					ChampionName = "leona",
					Slot = SpellSlot.Q,
					CastRange = 215,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "leonasolarbarrier",
					ChampionName = "leona",
					Slot = SpellSlot.W,
					CastRange = 250,
					Delay = 3000,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "leonazenithblade",
					ChampionName = "leona",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 900,
					Delay = 0,
					HitType = new HitType[] {},
					MissileName = "leonazenithblademissile",
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "leonasolarflare",
					ChampionName = "leona",
					Slot = SpellSlot.R,
					CastRange = 1200,
					Delay = 1200,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "leonasolarflare",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "lissandraq",
					ChampionName = "lissandra",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 725,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "lissandraqmissile",
					MissileSpeed = 2250
				},
				new Spell
				{
					SDataName = "lissandraw",
					ChampionName = "lissandra",
					Slot = SpellSlot.W,
					CastRange = 450,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "lissandrae",
					ChampionName = "lissandra",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1050,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "lissandraemissile",
					MissileSpeed = 850
				},
				new Spell
				{
					SDataName = "lissandrar",
					ChampionName = "lissandra",
					Slot = SpellSlot.R,
					CastRange = 550,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "lucianq",
					ChampionName = "lucian",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1150,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "lucianq",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "lucianw",
					ChampionName = "lucian",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 1050,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "lucianwmissile",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "luciane",
					ChampionName = "lucian",
					Slot = SpellSlot.E,
					CastRange = 650,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "lucianr",
					ChampionName = "lucian",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 1400,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "lucianrmissileoffhand",
					ExtraMissileNames = new[] {"lucianrmissile"},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "luluq",
					ChampionName = "lulu",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 925,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "luluqmissile",
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "luluw",
					ChampionName = "lulu",
					Slot = SpellSlot.W,
					CastRange = 650,
					Delay = 640,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "lulue",
					ChampionName = "lulu",
					Slot = SpellSlot.E,
					CastRange = 650,
					Delay = 640,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "lulur",
					ChampionName = "lulu",
					Slot = SpellSlot.R,
					CastRange = 900,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "luxlightbinding",
					ChampionName = "lux",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1300,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "luxlightbindingmis",
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "luxprismaticwave",
					ChampionName = "lux",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "luxlightstrikekugel",
					ChampionName = "lux",
					Slot = SpellSlot.E,
					CastRange = 1100,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "luxlightstrikekugel",
					MissileSpeed = 1300
				},
				new Spell
				{
					SDataName = "luxlightstriketoggle",
					ChampionName = "lux",
					Slot = SpellSlot.E,
					CastRange = 1100,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "luxmalicecannon",
					ChampionName = "lux",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 3340,
					Delay = 1000,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileName = "luxmalicecannonmis",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "kalistamysticshot",
					ChampionName = "kalista",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1200,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "kalistamysticshotmis",
					ExtraMissileNames = new[] {"kalistamysticshotmistrue"},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "kalistaw",
					ChampionName = "kalista",
					Slot = SpellSlot.W,
					CastRange = 5000,
					Delay = 800,
					HitType = new HitType[] {},
					MissileSpeed = 200
				},
				new Spell
				{
					SDataName = "kalistaexpungewrapper",
					ChampionName = "kalista",
					Slot = SpellSlot.E,
					CastRange = 1200,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "seismicshard",
					ChampionName = "malphite",
					Slot = SpellSlot.Q,
					CastRange = 625,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "obduracy",
					ChampionName = "malphite",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "landslide",
					ChampionName = "malphite",
					Slot = SpellSlot.E,
					CastRange = 400,
					Delay = 500,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "ufslash",
					ChampionName = "malphite",
					Slot = SpellSlot.R,
					CastRange = 1000,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "ufslash",
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "alzaharcallofthevoid",
					ChampionName = "malzahar",
					Slot = SpellSlot.Q,
					CastRange = 900,
					Delay = 600,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "alzaharcallofthevoid",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "alzaharnullzone",
					ChampionName = "malzahar",
					Slot = SpellSlot.W,
					CastRange = 800,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "alzaharmaleficvisions",
					ChampionName = "malzahar",
					Slot = SpellSlot.E,
					CastRange = 650,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "alzaharnethergrasp",
					ChampionName = "malzahar",
					Slot = SpellSlot.R,
					CastRange = 700,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "maokaitrunkline",
					ChampionName = "maokai",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "maokaiunstablegrowth",
					ChampionName = "maokai",
					Slot = SpellSlot.W,
					CastRange = 650,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "maokaisapling2",
					ChampionName = "maokai",
					Slot = SpellSlot.E,
					CastRange = 1100,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "maokaidrain3",
					ChampionName = "maokai",
					Slot = SpellSlot.R,
					CastRange = 625,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "alphastrike",
					ChampionName = "masteryi",
					Slot = SpellSlot.Q,
					CastRange = 600,
					Delay = 600,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "meditate",
					ChampionName = "masteryi",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "wujustyle",
					ChampionName = "masteryi",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 230,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "highlander",
					ChampionName = "masteryi",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 370,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "missfortunericochetshot",
					ChampionName = "missfortune",
					Slot = SpellSlot.Q,
					CastRange = 650,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "missfortuneviciousstrikes",
					ChampionName = "missfortune",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "missfortunescattershot",
					ChampionName = "missfortune",
					Slot = SpellSlot.E,
					CastRange = 1000,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "missfortunebullettime",
					ChampionName = "missfortune",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 1400,
					Delay = 200,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "monkeykingdoubleattack",
					ChampionName = "monkeyking",
					Slot = SpellSlot.Q,
					CastRange = 300,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 20
				},
				new Spell
				{
					SDataName = "monkeykingdecoy",
					ChampionName = "monkeyking",
					Slot = SpellSlot.W,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.Stealth},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "monkeykingdecoyswipe",
					ChampionName = "monkeyking",
					Slot = SpellSlot.W,
					CastRange = 325,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "monkeykingnimbus",
					ChampionName = "monkeyking",
					Slot = SpellSlot.E,
					CastRange = 625,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "monkeykingspintowin",
					ChampionName = "monkeyking",
					Slot = SpellSlot.R,
					CastRange = 450,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "monkeykingspintowinleave",
					ChampionName = "monkeyking",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = 700
				},
				new Spell
				{
					SDataName = "mordekaisermaceofspades",
					ChampionName = "mordekaiser",
					Slot = SpellSlot.Q,
					CastRange = 600,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "mordekaisercreepindeathcast",
					ChampionName = "mordekaiser",
					Slot = SpellSlot.W,
					CastRange = 750,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "mordekaisersyphoneofdestruction",
					ChampionName = "mordekaiser",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 700,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "mordekaiserchildrenofthegrave",
					ChampionName = "mordekaiser",
					Slot = SpellSlot.R,
					CastRange = 850,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "darkbindingmissile",
					ChampionName = "morgana",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1175,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "darkbindingmissile",
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "tormentedsoil",
					ChampionName = "morgana",
					Slot = SpellSlot.W,
					CastRange = 850,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "blackshield",
					ChampionName = "morgana",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "soulshackles",
					ChampionName = "morgana",
					Slot = SpellSlot.R,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "namiq",
					ChampionName = "nami",
					Slot = SpellSlot.Q,
					CastRange = 875,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "namiqmissile",
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "namiw",
					ChampionName = "nami",
					Slot = SpellSlot.W,
					CastRange = 725,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1100
				},
				new Spell
				{
					SDataName = "namie",
					ChampionName = "nami",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "namir",
					ChampionName = "nami",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 2550,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileName = "namirmissile",
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "nasusq",
					ChampionName = "nasus",
					Slot = SpellSlot.Q,
					CastRange = 450,
					Delay = 500,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "nasusw",
					ChampionName = "nasus",
					Slot = SpellSlot.W,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "nasuse",
					ChampionName = "nasus",
					Slot = SpellSlot.E,
					CastRange = 850,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "nasusr",
					ChampionName = "nasus",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "nautilusanchordrag",
					ChampionName = "nautilus",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1080,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileName = "nautilusanchordragmissile",
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "nautiluspiercinggaze",
					ChampionName = "nautilus",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "nautilussplashzone",
					ChampionName = "nautilus",
					Slot = SpellSlot.E,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1300
				},
				new Spell
				{
					SDataName = "nautilusgandline",
					ChampionName = "nautilus",
					Slot = SpellSlot.R,
					CastRange = 1250,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "javelintoss",
					ChampionName = "nidalee",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1500,
					Delay = 125,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "javelintoss",
					MissileSpeed = 1300
				},
				new Spell
				{
					SDataName = "takedown",
					ChampionName = "nidalee",
					Slot = SpellSlot.Q,
					CastRange = 150,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "bushwhack",
					ChampionName = "nidalee",
					Slot = SpellSlot.W,
					CastRange = 900,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "pounce",
					ChampionName = "nidalee",
					Slot = SpellSlot.W,
					CastRange = 375,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "primalsurge",
					ChampionName = "nidalee",
					Slot = SpellSlot.E,
					CastRange = 600,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "swipe",
					ChampionName = "nidalee",
					FixedRange = true,
					Slot = SpellSlot.E,
					CastRange = 350,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "aspectofthecougar",
					ChampionName = "nidalee",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "nocturneduskbringer",
					ChampionName = "nocturne",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1125,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "nocturneshroudofdarkness",
					ChampionName = "nocturne",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 500
				},
				new Spell
				{
					SDataName = "nocturneunspeakablehorror",
					ChampionName = "nocturne",
					Slot = SpellSlot.E,
					CastRange = 350,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "nocturneparanoia",
					ChampionName = "nocturne",
					Slot = SpellSlot.R,
					CastRange = 20000,
					Global = true,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 500
				},
				new Spell
				{
					SDataName = "consume",
					ChampionName = "nunu",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "bloodboil",
					ChampionName = "nunu",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "iceblast",
					ChampionName = "nunu",
					Slot = SpellSlot.E,
					CastRange = 550,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1000
				},
				new Spell
				{
					SDataName = "absolutezero",
					ChampionName = "nunu",
					Slot = SpellSlot.R,
					CastRange = 650,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "olafaxethrowcast",
					ChampionName = "olaf",
					Slot = SpellSlot.Q,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "olafaxethrow",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "olaffrenziedstrikes",
					ChampionName = "olaf",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "olafrecklessstrike",
					ChampionName = "olaf",
					Slot = SpellSlot.E,
					CastRange = 325,
					Delay = 500,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "olafragnarok",
					ChampionName = "olaf",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "orianaizunacommand",
					ChampionName = "orianna",
					Slot = SpellSlot.Q,
					CastRange = 900,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "orianaizuna",
					FromObject = new[] {"yomu_ring"},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "orianadissonancecommand",
					ChampionName = "orianna",
					Slot = SpellSlot.W,
					CastRange = 400,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "orianadissonancecommand",
					FromObject = new[] {"yomu_ring"},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "orianaredactcommand",
					ChampionName = "orianna",
					Slot = SpellSlot.E,
					CastRange = 1095,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "orianaredact",
					FromObject = new[] {"yomu_ring"},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "orianadetonatecommand",
					ChampionName = "orianna",
					Slot = SpellSlot.R,
					CastRange = 425,
					Delay = 500,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "orianadetonatecommand",
					FromObject = new[] {"yomu_ring"},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "pantheonq",
					ChampionName = "pantheon",
					Slot = SpellSlot.Q,
					CastRange = 600,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1900
				},
				new Spell
				{
					SDataName = "pantheonw",
					ChampionName = "pantheon",
					Slot = SpellSlot.W,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "pantheone",
					ChampionName = "pantheon",
					Slot = SpellSlot.E,
					CastRange = 600,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "pantheonrjump",
					ChampionName = "pantheon",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 1000,
					HitType = new HitType[] {},
					MissileSpeed = 3000
				},
				new Spell
				{
					SDataName = "pantheonrfall",
					ChampionName = "pantheon",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 1000,
					HitType = new HitType[] {},
					MissileSpeed = 3000
				},
				new Spell
				{
					SDataName = "poppyq",
					ChampionName = "poppy",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 450,
					Delay = 500,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "poppyw",
					ChampionName = "poppy",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "poppye",
					ChampionName = "poppy",
					Slot = SpellSlot.E,
					CastRange = 525,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "poppyrspell",
					ChampionName = "poppy",
					FixedRange = true,
					Slot = SpellSlot.R,
					CastRange = 1150,
					Delay = 300,
					HitType = new HitType[] {},
					MissileName = "poppyrspellmissile",
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "poppyrspellinstant",
					ChampionName = "poppy",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 450,
					Delay = 300,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "quinnq",
					ChampionName = "quinn",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1050,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "quinnqmissile",
					ExtraMissileNames = new[] {"quinnq"},
					MissileSpeed = 1550
				},
				new Spell
				{
					SDataName = "quinnw",
					ChampionName = "quinn",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "quinne",
					ChampionName = "quinn",
					Slot = SpellSlot.E,
					CastRange = 700,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 775
				},
				new Spell
				{
					SDataName = "quinnr",
					ChampionName = "quinn",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "quinnrfinale",
					ChampionName = "quinn",
					Slot = SpellSlot.R,
					CastRange = 700,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "powerball",
					ChampionName = "rammus",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 775
				},
				new Spell
				{
					SDataName = "defensiveballcurl",
					ChampionName = "rammus",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "puncturingtaunt",
					ChampionName = "rammus",
					Slot = SpellSlot.E,
					CastRange = 325,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "tremors2",
					ChampionName = "rammus",
					Slot = SpellSlot.R,
					CastRange = 300,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "renektoncleave",
					ChampionName = "renekton",
					Slot = SpellSlot.Q,
					CastRange = 225,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "renektonpreexecute",
					ChampionName = "renekton",
					Slot = SpellSlot.W,
					CastRange = 275,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "renektonsliceanddice",
					ChampionName = "renekton",
					Slot = SpellSlot.E,
					CastRange = 450,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "renektonreignofthetyrant",
					ChampionName = "renekton",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "rengarq",
					ChampionName = "rengar",
					Slot = SpellSlot.Q,
					CastRange = 275,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "rengarw",
					ChampionName = "rengar",
					Slot = SpellSlot.W,
					CastRange = 500,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "rengare",
					ChampionName = "rengar",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "rengarefinal",
					ExtraMissileNames = new[] {"rengarefinalmax"},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "rengarr",
					ChampionName = "rengar",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "reksaiq",
					ChampionName = "reksai",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 275,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "reksaiqburrowed",
					ChampionName = "reksai",
					Slot = SpellSlot.W,
					CastRange = 1650,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "reksaiqburrowedmis",
					MissileSpeed = 1950
				},
				new Spell
				{
					SDataName = "reksaiw",
					ChampionName = "reksai",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 350,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "reksaiwburrowed",
					ChampionName = "reksai",
					Slot = SpellSlot.W,
					CastRange = 200,
					Delay = 500,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "reksaie",
					ChampionName = "reksai",
					Slot = SpellSlot.E,
					CastRange = 250,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "reksaieburrowed",
					ChampionName = "reksai",
					Slot = SpellSlot.E,
					CastRange = 350,
					Delay = 900,
					HitType = new HitType[] {},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "reksair",
					ChampionName = "reksai",
					Slot = SpellSlot.R,
					CastRange = float.MaxValue,
					Delay = 1000,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "riventricleave",
					ChampionName = "riven",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 270,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "rivenmartyr",
					ChampionName = "riven",
					Slot = SpellSlot.W,
					CastRange = 260,
					Delay = 0,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "rivenfeint",
					ChampionName = "riven",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "rivenfengshuiengine",
					ChampionName = "riven",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "rivenizunablade",
					ChampionName = "riven",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 1075,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileName = "rivenlightsabermissile",
					ExtraMissileNames = new[] {"rivenlightsabermissileside"},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "rumbleflamethrower",
					ChampionName = "rumble",
					Slot = SpellSlot.Q,
					CastRange = 600,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "rumbleshield",
					ChampionName = "rumble",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "rumbegrenade",
					ChampionName = "rumble",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 850,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "rumblecarpetbomb",
					ChampionName = "rumble",
					Slot = SpellSlot.R,
					CastRange = 1700,
					Delay = 400,
					HitType = new HitType[] {},
					MissileName = "rumblecarpetbombmissile",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "ryzeq",
					ChampionName = "ryze",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 625,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "ryzeqmissile",
					ExtraMissileNames = new[] {"ryzeq"},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "ryzew",
					ChampionName = "ryze",
					Slot = SpellSlot.W,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "ryzee",
					ChampionName = "ryze",
					Slot = SpellSlot.E,
					CastRange = 600,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1000
				},
				new Spell
				{
					SDataName = "ryzer",
					ChampionName = "ryze",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "sejuaniarcticassault",
					ChampionName = "sejuani",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 650,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "",
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "sejuaninorthernwinds",
					ChampionName = "sejuani",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 1000,
					HitType = new HitType[] {},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "sejuaniwintersclaw",
					ChampionName = "sejuani",
					Slot = SpellSlot.E,
					CastRange = 550,
					Delay = 0,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "sejuaniglacialprisoncast",
					ChampionName = "sejuani",
					Slot = SpellSlot.R,
					CastRange = 1200,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "sejuaniglacialprison",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "deceive",
					ChampionName = "shaco",
					Slot = SpellSlot.Q,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.Stealth},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "jackinthebox",
					ChampionName = "shaco",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "twoshivpoison",
					ChampionName = "shaco",
					Slot = SpellSlot.E,
					CastRange = 625,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "hallucinatefull",
					ChampionName = "shaco",
					Slot = SpellSlot.R,
					CastRange = 1125,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 395
				},
				new Spell
				{
					SDataName = "shenq",
					ChampionName = "shen",
					Slot = SpellSlot.Q,
					CastRange = 1650,
					Delay = 0,
					HitType = new HitType[] {},
					FromObject = new[] {"ShenArrowVfxHostMinion"},
					MissileSpeed = 1350
				},
				new Spell
				{
					SDataName = "shenw",
					ChampionName = "shen",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "shene",
					ChampionName = "shen",
					Slot = SpellSlot.E,
					CastRange = 675,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "shene",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "shenr",
					ChampionName = "shen",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "shyvanadoubleattack",
					ChampionName = "shyvana",
					Slot = SpellSlot.Q,
					CastRange = 275,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "shyvanadoubleattackdragon",
					ChampionName = "shyvana",
					Slot = SpellSlot.Q,
					CastRange = 325,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "shyvanaimmolationauraqw",
					ChampionName = "shyvana",
					Slot = SpellSlot.W,
					CastRange = 275,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "shyvanaimmolateddragon",
					ChampionName = "shyvana",
					Slot = SpellSlot.W,
					CastRange = 250,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "shyvanafireball",
					ChampionName = "shyvana",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 925,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "shyvanafireballmissile",
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "shyvanafireballdragon2",
					ChampionName = "shyvana",
					Slot = SpellSlot.E,
					CastRange = 925,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "shyvanatransformcast",
					ChampionName = "shyvana",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 1000,
					Delay = 100,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.SpellCC,
							Enums.HitType.KillSpell
						},
					MissileName = "shyvanatransformcast",
					MissileSpeed = 1100
				},
				new Spell
				{
					SDataName = "poisentrail",
					ChampionName = "singed",
					Slot = SpellSlot.Q,
					CastRange = 250,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "megaadhesive",
					ChampionName = "singed",
					Slot = SpellSlot.W,
					CastRange = 1175,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 700
				},
				new Spell
				{
					SDataName = "fling",
					ChampionName = "singed",
					Slot = SpellSlot.E,
					CastRange = 125,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "insanitypotion",
					ChampionName = "singed",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "sionq",
					ChampionName = "sion",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 600,
					Delay = 2000,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "sionw",
					ChampionName = "sion",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "sione",
					ChampionName = "sion",
					Slot = SpellSlot.E,
					CastRange = 725,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "sionemissile",
					MissileSpeed = 1800
				},
				new Spell
				{
					SDataName = "sionr",
					ChampionName = "sion",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "",
					MissileSpeed = 500
				},
				new Spell
				{
					SDataName = "sivirq",
					ChampionName = "sivir",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1165,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "sivirqmissile",
					ExtraMissileNames = new[] {"sivirqmissilereturn"},
					MissileSpeed = 1350
				},
				new Spell
				{
					SDataName = "sivirw",
					ChampionName = "sivir",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "sivire",
					ChampionName = "sivir",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "sivirr",
					ChampionName = "sivir",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "skarnervirulentslash",
					ChampionName = "skarner",
					Slot = SpellSlot.Q,
					CastRange = 350,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "skarnerexoskeleton",
					ChampionName = "skarner",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "skarnerfracture",
					ChampionName = "skarner",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1100,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "skarnerfracturemissile",
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "skarnerimpale",
					ChampionName = "skarner",
					Slot = SpellSlot.R,
					CastRange = 350,
					Delay = 350,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "sonaq",
					ChampionName = "sona",
					Slot = SpellSlot.Q,
					CastRange = 700,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "sonaw",
					ChampionName = "sona",
					Slot = SpellSlot.W,
					CastRange = 1000,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "sonae",
					ChampionName = "sona",
					Slot = SpellSlot.E,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "sonar",
					ChampionName = "sona",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 1000,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "sonar",
					MissileSpeed = 2400
				},
				new Spell
				{
					SDataName = "sorakaq",
					ChampionName = "soraka",
					Slot = SpellSlot.Q,
					CastRange = 970,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "",
					MissileSpeed = 1100
				},
				new Spell
				{
					SDataName = "sorakaw",
					ChampionName = "soraka",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "sorakae",
					ChampionName = "soraka",
					Slot = SpellSlot.E,
					CastRange = 925,
					Delay = 1750,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "sorakar",
					ChampionName = "soraka",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "swaindecrepify",
					ChampionName = "swain",
					Slot = SpellSlot.Q,
					CastRange = 625,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "swainshadowgrasp",
					ChampionName = "swain",
					Slot = SpellSlot.W,
					CastRange = 1040,
					Delay = 1100,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "swainshadowgrasp",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "swaintorment",
					ChampionName = "swain",
					Slot = SpellSlot.E,
					CastRange = 625,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "swainmetamorphism",
					ChampionName = "swain",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1950
				},
				new Spell
				{
					SDataName = "syndraq",
					ChampionName = "syndra",
					Slot = SpellSlot.Q,
					CastRange = 800,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "syndraq",
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "syndrawcast",
					ChampionName = "syndra",
					Slot = SpellSlot.W,
					CastRange = 950,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "syndrawcast",
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "syndrae",
					ChampionName = "syndra",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 950,
					Delay = 300,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "syndrae",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "syndrar",
					ChampionName = "syndra",
					Slot = SpellSlot.R,
					CastRange = 675,
					Delay = 450,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileSpeed = 1250
				},
				new Spell
				{
					SDataName = "tahmkenchq",
					ChampionName = "tahmkench",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 950,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 2800
				},
				new Spell
				{
					SDataName = "talonnoxiandiplomacy",
					ChampionName = "talon",
					Slot = SpellSlot.Q,
					CastRange = 275,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "talonrake",
					ChampionName = "talon",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 750,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "talonrakemissileone",
					MissileSpeed = 2300
				},
				new Spell
				{
					SDataName = "taloncutthroat",
					ChampionName = "talon",
					Slot = SpellSlot.E,
					CastRange = 750,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "talonshadowassault",
					ChampionName = "talon",
					Slot = SpellSlot.R,
					CastRange = 750,
					Delay = 260,
					HitType = new[] {Enums.HitType.Stealth},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "imbue",
					ChampionName = "taric",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "shatter",
					ChampionName = "taric",
					Slot = SpellSlot.W,
					CastRange = 400,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "dazzle",
					ChampionName = "taric",
					Slot = SpellSlot.E,
					CastRange = 625,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "tarichammersmash",
					ChampionName = "taric",
					Slot = SpellSlot.R,
					CastRange = 400,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "blindingdart",
					ChampionName = "teemo",
					Slot = SpellSlot.Q,
					CastRange = 580,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "movequick",
					ChampionName = "teemo",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = 943
				},
				new Spell
				{
					SDataName = "toxicshot",
					ChampionName = "teemo",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "bantamtrap",
					ChampionName = "teemo",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "threshq",
					ChampionName = "thresh",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1175,
					Delay = 500,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileName = "threshqmissile",
					MissileSpeed = 1900
				},
				new Spell
				{
					SDataName = "threshw",
					ChampionName = "thresh",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "threshe",
					ChampionName = "thresh",
					Slot = SpellSlot.E,
					CastRange = 400,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "threshemissile1",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "threshrpenta",
					ChampionName = "thresh",
					Slot = SpellSlot.R,
					CastRange = 420,
					Delay = 300,
					HitType = new HitType[] {},
					MissileSpeed = 1550
				},
				new Spell
				{
					SDataName = "tristanaq",
					ChampionName = "tristana",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "tristanaw",
					ChampionName = "tristana",
					Slot = SpellSlot.W,
					CastRange = 900,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1150
				},
				new Spell
				{
					SDataName = "tristanae",
					ChampionName = "tristana",
					Slot = SpellSlot.E,
					CastRange = 625,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "tristanar",
					ChampionName = "tristana",
					Slot = SpellSlot.R,
					CastRange = 700,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "trundletrollsmash",
					ChampionName = "trundle",
					Slot = SpellSlot.Q,
					CastRange = 275,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "trundledesecrate",
					ChampionName = "trundle",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "trundlecircle",
					ChampionName = "trundle",
					Slot = SpellSlot.E,
					CastRange = 1100,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "trundlepain",
					ChampionName = "trundle",
					Slot = SpellSlot.R,
					CastRange = 700,
					Delay = 500,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "bloodlust",
					ChampionName = "tryndamere",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "mockingshout",
					ChampionName = "tryndamere",
					Slot = SpellSlot.W,
					CastRange = 400,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "slashcast",
					ChampionName = "tryndamere",
					Slot = SpellSlot.E,
					CastRange = 660,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "slashcast",
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "undyingrage",
					ChampionName = "tryndamere",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "hideinshadows",
					ChampionName = "twich",
					Slot = SpellSlot.Q,
					CastRange = 1000,
					Delay = 450,
					HitType = new[] {Enums.HitType.Stealth},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "twitchvenomcask",
					ChampionName = "twich",
					Slot = SpellSlot.W,
					CastRange = 800,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "twitchvenomcaskmissile",
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "twitchvenomcaskmissle",
					ChampionName = "twich",
					Slot = SpellSlot.W,
					CastRange = 800,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "expunge",
					ChampionName = "twich",
					Slot = SpellSlot.E,
					CastRange = 1200,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "fullautomatic",
					ChampionName = "twich",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 500
				},
				new Spell
				{
					SDataName = "wildcards",
					ChampionName = "twistedfate",
					Slot = SpellSlot.Q,
					CastRange = 1450,
					FixedRange = true,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "sealfatemissile",
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "pickacard",
					ChampionName = "twistedfate",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "goldcardpreattack",
					ChampionName = "twistedfate",
					Slot = SpellSlot.W,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "redcardpreattack",
					ChampionName = "twistedfate",
					Slot = SpellSlot.W,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "bluecardpreattack",
					ChampionName = "twistedfate",
					Slot = SpellSlot.W,
					CastRange = 600,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "cardmasterstack",
					ChampionName = "twistedfate",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1200
				},
				new Spell
				{
					SDataName = "destiny",
					ChampionName = "twistedfate",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "udyrtigerstance",
					ChampionName = "udyr",
					Slot = SpellSlot.Q,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "udyrturtlestance",
					ChampionName = "udyr",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "udyrbearstanceattack",
					ChampionName = "udyr",
					Slot = SpellSlot.E,
					CastRange = 250,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "udyrphoenixstance",
					ChampionName = "udyr",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "urgotheatseekinglineqqmissile",
					ChampionName = "urgot",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "urgotheatseekingmissile",
					ChampionName = "urgot",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1000,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "urgotterrorcapacitoractive2",
					ChampionName = "urgot",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "urgotplasmagrenade",
					ChampionName = "urgot",
					Slot = SpellSlot.E,
					CastRange = 950,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "urgotplasmagrenadeboom",
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "urgotplasmagrenadeboom",
					ChampionName = "urgot",
					Slot = SpellSlot.E,
					CastRange = 950,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "urgotswap2",
					ChampionName = "urgot",
					Slot = SpellSlot.R,
					CastRange = 850,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1800
				},
				new Spell
				{
					SDataName = "varusq",
					ChampionName = "varus",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1250,
					Delay = 0,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "varusqmissile",
					MissileSpeed = 1900
				},
				new Spell
				{
					SDataName = "varusw",
					ChampionName = "varus",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "varuse",
					ChampionName = "varus",
					Slot = SpellSlot.E,
					CastRange = 925,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "varuse",
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "varusr",
					ChampionName = "varus",
					Slot = SpellSlot.R,
					FixedRange = true,
					CastRange = 1300,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileName = "varusrmissile",
					MissileSpeed = 1950
				},
				new Spell
				{
					SDataName = "vaynetumble",
					ChampionName = "vayne",
					Slot = SpellSlot.Q,
					CastRange = 850,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "vaynesilverbolts",
					ChampionName = "vayne",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "vaynecondemnmissile",
					ChampionName = "vayne",
					Slot = SpellSlot.E,
					CastRange = 550,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "vayneinquisition",
					ChampionName = "vayne",
					Slot = SpellSlot.R,
					CastRange = 1200,
					Delay = 250,
					HitType = new[] {Enums.HitType.Stealth},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "veigarbalefulstrike",
					ChampionName = "veigar",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 950,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "veigarbalefulstrikemis",
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "veigardarkmatter",
					ChampionName = "veigar",
					Slot = SpellSlot.W,
					CastRange = 900,
					Delay = 1200,
					HitType = new HitType[] {},
					MissileName = "",
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "veigareventhorizon",
					ChampionName = "veigar",
					Slot = SpellSlot.E,
					CastRange = 650,
					Delay = 0,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "",
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "veigarprimordialburst",
					ChampionName = "veigar",
					Slot = SpellSlot.R,
					CastRange = 850,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "velkozq",
					ChampionName = "velkoz",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1250,
					Delay = 100,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "velkozqmissile",
					MissileSpeed = 1300
				},
				new Spell
				{
					SDataName = "velkozqsplitactivate",
					ChampionName = "velkoz",
					Slot = SpellSlot.Q,
					CastRange = 1050,
					Delay = 0,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileName = "velkozqmissilesplit",
					MissileSpeed = 2100
				},
				new Spell
				{
					SDataName = "velkozw",
					ChampionName = "velkoz",
					Slot = SpellSlot.W,
					FixedRange = true,
					CastRange = 1050,
					Delay = 0,
					HitType = new HitType[] {},
					MissileName = "velkozwmissile",
					MissileSpeed = 1700
				},
				new Spell
				{
					SDataName = "velkoze",
					ChampionName = "velkoz",
					Slot = SpellSlot.E,
					CastRange = 950,
					Delay = 0,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "velkozemissile",
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "velkozr",
					ChampionName = "velkoz",
					Slot = SpellSlot.R,
					CastRange = 1575,
					Delay = 0,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "viq",
					ChampionName = "vi",
					Slot = SpellSlot.Q,
					CastRange = 800,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "viw",
					ChampionName = "vi",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "vie",
					ChampionName = "vi",
					Slot = SpellSlot.E,
					CastRange = 600,
					Delay = 0,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "vir",
					ChampionName = "vi",
					Slot = SpellSlot.R,
					CastRange = 800,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "viktorpowertransfer",
					ChampionName = "viktor",
					Slot = SpellSlot.Q,
					CastRange = 600,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "viktorgravitonfield",
					ChampionName = "viktor",
					Slot = SpellSlot.W,
					CastRange = 815,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "viktordeathray",
					ChampionName = "viktor",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 700,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileName = "viktordeathraymis",
					ExtraMissileNames = new[] {"viktoreaugmissile"},
					MissileSpeed = 1210
				},
				new Spell
				{
					SDataName = "viktorchaosstorm",
					ChampionName = "viktor",
					Slot = SpellSlot.R,
					CastRange = 710,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.SpellCC, Enums.HitType.KillSpell,
							Enums.HitType.DangerSpell
						},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "vladimirtransfusion",
					ChampionName = "vladimir",
					Slot = SpellSlot.Q,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "vladimirsanguinepool",
					ChampionName = "vladimir",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "vladimirtidesofblood",
					ChampionName = "vladimir",
					Slot = SpellSlot.E,
					CastRange = 610,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1100
				},
				new Spell
				{
					SDataName = "vladimirhemoplague",
					ChampionName = "vladimir",
					Slot = SpellSlot.R,
					CastRange = 875,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "volibearq",
					ChampionName = "volibear",
					Slot = SpellSlot.Q,
					CastRange = 300,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "volibearw",
					ChampionName = "volibear",
					Slot = SpellSlot.W,
					CastRange = 400,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = 1450
				},
				new Spell
				{
					SDataName = "volibeare",
					ChampionName = "volibear",
					Slot = SpellSlot.E,
					CastRange = 425,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 825
				},
				new Spell
				{
					SDataName = "volibearr",
					ChampionName = "volibear",
					Slot = SpellSlot.R,
					CastRange = 425,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = 825
				},
				new Spell
				{
					SDataName = "hungeringstrike",
					ChampionName = "warwick",
					Slot = SpellSlot.Q,
					CastRange = 400,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "hunterscall",
					ChampionName = "warwick",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "bloodscent",
					ChampionName = "warwick",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "infiniteduress",
					ChampionName = "warwick",
					Slot = SpellSlot.R,
					CastRange = 700,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "xeratharcanopulsechargeup",
					ChampionName = "xerath",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 750,
					Delay = 750,
					HitType = new HitType[] {},
					MissileSpeed = 500
				},
				new Spell
				{
					SDataName = "xeratharcanebarrage2",
					ChampionName = "xerath",
					Slot = SpellSlot.W,
					CastRange = 1100,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "xeratharcanebarrage2",
					MissileSpeed = 20
				},
				new Spell
				{
					SDataName = "xerathmagespear",
					ChampionName = "xerath",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1050,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileName = "xerathmagespearmissile",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "xerathlocusofpower2",
					ChampionName = "xerath",
					Slot = SpellSlot.R,
					CastRange = 5600,
					Delay = 750,
					HitType = new HitType[] {},
					MissileSpeed = 500
				},
				new Spell
				{
					SDataName = "xenzhaothrust3",
					ChampionName = "xinzhao",
					Slot = SpellSlot.Q,
					CastRange = 400,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "xenzhaobattlecry",
					ChampionName = "xinzhao",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 0,
					HitType = new HitType[] {},
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "xenzhaosweep",
					ChampionName = "xinzhao",
					Slot = SpellSlot.E,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC, Enums.HitType.DangerSpell},
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "xenzhaoparry",
					ChampionName = "xinzhao",
					Slot = SpellSlot.R,
					CastRange = 375,
					Delay = 250,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "yasuoqw",
					ChampionName = "yasuo",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 475,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "yasuoq2w",
					ChampionName = "yasuo",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 475,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "yasuoq3",
					ChampionName = "yasuo",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 1000,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "yasuoq3mis",
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "yasuowmovingwall",
					ChampionName = "yasuo",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 500
				},
				new Spell
				{
					SDataName = "yasuodashwrapper",
					ChampionName = "yasuo",
					Slot = SpellSlot.E,
					CastRange = 475,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 20
				},
				new Spell
				{
					SDataName = "yasuorknockupcombow",
					ChampionName = "yasuo",
					Slot = SpellSlot.R,
					CastRange = 1200,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "yorickspectral",
					ChampionName = "yorick",
					Slot = SpellSlot.Q,
					CastRange = 350,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "yorickdecayed",
					ChampionName = "yorick",
					Slot = SpellSlot.W,
					CastRange = 600,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "yorickravenous",
					ChampionName = "yorick",
					Slot = SpellSlot.E,
					CastRange = 550,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "yorickreviveally",
					ChampionName = "yorick",
					Slot = SpellSlot.R,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "zacq",
					ChampionName = "zac",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 550,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "zacq",
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "zacw",
					ChampionName = "zac",
					Slot = SpellSlot.W,
					CastRange = 350,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "zace",
					ChampionName = "zac",
					Slot = SpellSlot.E,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1500
				},
				new Spell
				{
					SDataName = "zacr",
					ChampionName = "zac",
					Slot = SpellSlot.R,
					CastRange = 850,
					Delay = 250,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "zedq",
					ChampionName = "zed",
					Slot = SpellSlot.Q,
					FixedRange = true,
					CastRange = 900,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "zedqmissile",
					FromObject = new[] {"Zed_Base_W_tar.troy", "Zed_Base_W_cloneswap_buf.troy"},
					ExtraMissileNames = new[] {"zedqmissiletwo", "zedqmissilethree"},
					MissileSpeed = 1700
				},
				new Spell
				{
					SDataName = "zedw",
					ChampionName = "zed",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 1600
				},
				new Spell
				{
					SDataName = "zede",
					ChampionName = "zed",
					Slot = SpellSlot.E,
					CastRange = 300,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "zedr",
					ChampionName = "zed",
					Slot = SpellSlot.R,
					CastRange = 850,
					Delay = 450,
					HitType = new[] {Enums.HitType.DangerSpell},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "ziggsq",
					ChampionName = "ziggs",
					Slot = SpellSlot.Q,
					CastRange = 850,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "ziggsqspell",
					ExtraMissileNames = new[] {"ziggsqspell2", "ziggsqspell3"},
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "ziggsw",
					ChampionName = "ziggs",
					Slot = SpellSlot.W,
					CastRange = 850,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "ziggsw",
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "ziggswtoggle",
					ChampionName = "ziggs",
					Slot = SpellSlot.W,
					CastRange = 850,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "ziggse",
					ChampionName = "ziggs",
					Slot = SpellSlot.E,
					CastRange = 850,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "ziggse",
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "ziggse2",
					ChampionName = "ziggs",
					Slot = SpellSlot.E,
					CastRange = 850,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "ziggsr",
					ChampionName = "ziggs",
					Slot = SpellSlot.R,
					CastRange = 2250,
					Delay = 1800,
					HitType = new[] {Enums.HitType.DangerSpell, Enums.HitType.KillSpell},
					MissileName = "ziggsr",
					MissileSpeed = 1750
				},
				new Spell
				{
					SDataName = "zileanq",
					ChampionName = "zilean",
					Slot = SpellSlot.Q,
					CastRange = 900,
					Delay = 300,
					HitType = new HitType[] {},
					MissileName = "zileanqmissile",
					MissileSpeed = 2000
				},
				new Spell
				{
					SDataName = "zileanw",
					ChampionName = "zilean",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "zileane",
					ChampionName = "zilean",
					Slot = SpellSlot.E,
					CastRange = 700,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileSpeed = 1100
				},
				new Spell
				{
					SDataName = "zileanr",
					ChampionName = "zilean",
					Slot = SpellSlot.R,
					CastRange = 780,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = int.MaxValue
				},
				new Spell
				{
					SDataName = "zyraqfissure",
					ChampionName = "zyra",
					Slot = SpellSlot.Q,
					CastRange = 800,
					Delay = 250,
					HitType = new HitType[] {},
					MissileName = "zyraqfissure",
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "zyraseed",
					ChampionName = "zyra",
					Slot = SpellSlot.W,
					CastRange = 0,
					Delay = 250,
					HitType = new HitType[] {},
					MissileSpeed = 2200
				},
				new Spell
				{
					SDataName = "zyragraspingroots",
					ChampionName = "zyra",
					Slot = SpellSlot.E,
					FixedRange = true,
					CastRange = 1100,
					Delay = 250,
					HitType = new[] {Enums.HitType.SpellCC},
					MissileName = "zyragraspingroots",
					MissileSpeed = 1400
				},
				new Spell
				{
					SDataName = "zyrabramblezone",
					ChampionName = "zyra",
					Slot = SpellSlot.R,
					CastRange = 700,
					Delay = 500,
					HitType =
						new[]
						{
							Enums.HitType.DangerSpell, Enums.HitType.KillSpell,
							Enums.HitType.SpellCC
						},
					MissileSpeed = int.MaxValue
				}
			};
	}
}