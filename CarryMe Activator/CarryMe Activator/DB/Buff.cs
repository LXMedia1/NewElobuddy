using System.Collections.Generic;
using EloBuddy;

namespace CarryMe_Activator.DB
{
	public class Buff
	{
		public static List<Buff> ActiveBuffList = new List<Buff>();

		public static List<Buff> BuffList = new List<Buff>
		{
			new Buff
			{
				Name = "summonerdot",
				MenuName = "Summoner Ignite",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = 1.0
			},
			new Buff
			{
				Name = "summonerdot",
				MenuName = "Summoner Ignite",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = 1.0
			},
			new Buff
			{
				Name = "summonerexhaust",
				MenuName = "Summoner Exhaust",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = 1.0
			},
			new Buff
			{
				Name = "masteryburndebuff",
				MenuName = "Deathfire Touch",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = 0.5
			},
			new Buff
			{
				Name = "itemdusknightfall",
				MenuName = "Duskblade (Nightfall)",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 1650,
				Slot = SpellSlot.Unknown,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "vi",
				Name = "virknockup",
				MenuName = "Vi R Knockup",
				Evade = true,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "amumu",
				Name = "curseofthesadmummy",
				MenuName = "Amumu Curse of the Sad Mummy",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = 1.0
			},
			new Buff
			{
				Name = "itemsmitechallenge",
				MenuName = "Challenging Smite",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = 0.7
			},
			new Buff
			{
				ChampionName = "gangplank",
				Name = "gangplankpassiveattackdot",
				MenuName = "Gangplank Passive Burn",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = .8
			},
			new Buff
			{
				ChampionName = "teemo",
				Name = "bantamtraptarget",
				MenuName = "Teemo Shroom",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "teemo",
				Name = "toxicshotparticle",
				MenuName = "Teemo Toxic Shot",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.E,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "ahri",
				Name = "ahriseduce",
				MenuName = "Ahri Charm",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.E,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "elise",
				Name = "elisehumane",
				MenuName = "Elise Cocoon",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 25,
				Slot = SpellSlot.E,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "heimerdinger",
				Name = "heimerdingerespell",
				MenuName = "Heimerdinger Grenade",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 25,
				Slot = SpellSlot.E,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "talon",
				Name = "talonbleeddebuf",
				MenuName = "Talon Bleed",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Q,
				Interval = .8
			},
			new Buff
			{
				ChampionName = "malzahar",
				Name = "alzaharnethergrasp",
				MenuName = "Malzahar Nether Grasp",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.R,
				Interval = .8
			},
			new Buff
			{
				ChampionName = "malzahar",
				Name = "alzaharmaleficvisions",
				MenuName = "Malzahar Aids",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.E,
				Interval = .8
			},
			new Buff
			{
				ChampionName = "fiddlesticks",
				Name = "drainchannel",
				MenuName = "Fiddle Drain",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.W,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "galio",
				Name = "galioidolofdurand",
				MenuName = "Galio Idol of Durand",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.R,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "nasus",
				Name = "nasusw",
				MenuName = "Nasus Wither",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.W,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "gnar",
				Name = "gnarstun",
				MenuName = "Gnar Ultimate",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 100,
				Slot = SpellSlot.R,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "gragas",
				Name = "gragasestun",
				MenuName = "Gragas Body Slam",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 100,
				Slot = SpellSlot.E,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "bard",
				Name = "bardqshackledebuff",
				MenuName = "Bard Cosmic Binding",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 25,
				Slot = SpellSlot.Q,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "akali",
				Name = "akalimota",
				MenuName = "Akali Mark of the Assassin",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Q,
				Interval = 1.5
			},
			new Buff
			{
				ChampionName = "hecarim",
				Name = "hecarimdefilelifeleech",
				MenuName = "Hecarim Defile Leech",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.W,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "swain",
				Name = "swaintorment",
				MenuName = "Swain Torment",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.E,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "brand",
				Name = "brandablaze",
				MenuName = "Brand Burn Passive",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = 0.5
			},
			new Buff
			{
				ChampionName = "fizz",
				Name = "fizzseastonetrident",
				MenuName = "Fizz Burn Passive",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = .8
			},
			new Buff
			{
				ChampionName = "tristana",
				Name = "tristanaechargesound",
				MenuName = "Tristana Explosive Charge",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.E,
				Interval = .8
			},
			new Buff
			{
				ChampionName = "darius",
				Name = "dariushemo",
				MenuName = "Darius Hemorrhage",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.W,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "nidalee",
				Name = "bushwackdamage",
				MenuName = "Nidalee Bushwhack",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.W,
				Interval = .8
			},
			new Buff
			{
				ChampionName = "nidalee",
				Name = "nidaleepassivehunted",
				MenuName = "Nidalee Passive Mark",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = .8
			},
			new Buff
			{
				Name = "shyvanaimmolationaura",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.W,
				Interval = 1.0
			},
			new Buff
			{
				Name = "missfortunescattershotslow",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.E,
				Interval = 0.5
			},
			new Buff
			{
				Name = "missfortunepassivestack",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.R,
				Interval = 0.5
			},
			new Buff
			{
				Name = "shyvanaimmolatedragon",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.W,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "zilean",
				Name = "zileanqenemybomb",
				MenuName = "Zilean Bomb",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Q,
				Interval = 3.8
			},
			new Buff
			{
				ChampionName = "wukong",
				Name = "monkeykingspintowin",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.R,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "katarina",
				Name = "katarinaqmark",
				MenuName = "Katarina Bouncing Blades",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Q,
				Interval = 1.5
			},
			new Buff
			{
				ChampionName = "kindred",
				Name = "kindredecharge",
				MenuName = "Kindred Mounting Dread",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.E,
				Interval = 2.0
			},
			new Buff
			{
				ChampionName = "cassiopeia",
				Name = "cassiopeianoxiousblastpoison",
				MenuName = "Cassio Noxious Blast",
				Evade = false,
				Cleanse = false,
				DoT = true,
				EvadeTimer = 0,
				CleanseTimer = 0,
				Slot = SpellSlot.Q,
				Interval = 0.4
			},
			new Buff
			{
				ChampionName = "cassiopeia",
				Name = "cassiopeiamiasmapoison",
				MenuName = "Cassio Miasma",
				Evade = false,
				Cleanse = false,
				DoT = true,
				EvadeTimer = 0,
				CleanseTimer = 0,
				Slot = SpellSlot.Q,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "cassiopeia",
				Name = "cassiopeiapetrifyinggazestun",
				MenuName = "Cassio Petrifying Gaze",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 100,
				Slot = SpellSlot.R,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "ekko",
				Name = "ekkowstun",
				MenuName = "Ekko Parellel Convergence",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.W,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "lissandra",
				Name = "lissandrarenemy2",
				MenuName = "Lissandra Frozen Tomb",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 100,
				Slot = SpellSlot.R,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "sejuani",
				Name = "sejuaniglacialprison",
				MenuName = "Sejuani Glacial Prison",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 100,
				Slot = SpellSlot.R,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "fiora",
				Name = "fiorarmark",
				MenuName = "Fiora Grand Challenge",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 100,
				Slot = SpellSlot.R,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "twitch",
				Name = "twitchdeadlyvenon",
				MenuName = "Twitch Deadly Venom",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.E,
				Interval = 0.6
			},
			new Buff
			{
				ChampionName = "urgot",
				Name = "urgotcorrosivedebuff",
				MenuName = "Urgot Corrosive Charge",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.E,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "zac",
				Name = "zacr",
				Evade = true,
				DoT = true,
				EvadeTimer = 150,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.R,
				Interval = 1.5
			},
			new Buff
			{
				ChampionName = "mordekaiser",
				Name = "mordekaiserchildrenofthegrave",
				MenuName = "Mordekaiser Children of the Grave",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = 1.5
			},
			new Buff
			{
				Name = "burningagony",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Unknown,
				Interval = 1.0
			},
			new Buff
			{
				Name = "garene",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.E,
				Interval = 1.0
			},
			new Buff
			{
				Name = "auraofdespair",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.W,
				Interval = 1.0
			},
			new Buff
			{
				Name = "hecarimw",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.W,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "braum",
				Name = "braummark",
				MenuName = "Braum Passive",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 200,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				ChampionName = "zed",
				Name = "zedultexecute",
				MenuName = "Zed Mark",
				Evade = true,
				DoT = false,
				EvadeTimer = 2600,
				Cleanse = true,
				CleanseTimer = 500,
				Slot = SpellSlot.R,
				Interval = 1.0
			},
			new Buff
			{
				ChampionName = "karthus",
				Name = "fallenonetarget",
				Evade = true,
				DoT = false,
				EvadeTimer = 2600,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.R
			},
			new Buff
			{
				ChampionName = "karthus",
				Name = "karthusfallenonetarget",
				Evade = true,
				DoT = false,
				EvadeTimer = 2600,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.R
			},
			new Buff
			{
				ChampionName = "fizz",
				Name = "fizzmarinerdoombomb",
				MenuName = "Fizz Shark Bait",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.R
			},
			new Buff
			{
				ChampionName = "morgana",
				Name = "soulshackles",
				MenuName = "Morgana Soul Shackles",
				Evade = true,
				DoT = false,
				EvadeTimer = 2600,
				Cleanse = true,
				CleanseTimer = 1100,
				Slot = SpellSlot.R,
				Interval = 3.9
			},
			new Buff
			{
				ChampionName = "varus",
				Name = "varusrsecondary",
				MenuName = "Varus Chains of Corruption",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.R
			},
			new Buff
			{
				ChampionName = "caitlyn",
				Name = "caitlynaceinthehole",
				MenuName = "Caitlyn Ace in the Hole",
				Evade = true,
				DoT = false,
				EvadeTimer = 900,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.R
			},
			new Buff
			{
				ChampionName = "vladimir",
				Name = "vladimirhemoplague",
				MenuName = "Vladimir Hemoplague",
				Evade = true,
				DoT = false,
				EvadeTimer = 4500,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.R
			},
			new Buff
			{
				ChampionName = "diana",
				Name = "dianamoonlight",
				MenuName = "Diana Moonlight",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.Q
			},
			new Buff
			{
				ChampionName = "urgot",
				Name = "urgotswap2",
				MenuName = "Urgot Swap",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.R
			},
			new Buff
			{
				ChampionName = "skarner",
				Name = "skarnerimpale",
				MenuName = "Skarner Impale",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 500,
				Slot = SpellSlot.R
			},
			new Buff
			{
				ChampionName = "maokai",
				Name = "maokaiunstablegrowthroot",
				MenuName = "Maokai Root",
				Evade = false,
				DoT = false,
				EvadeTimer = 0,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.W
			},
			new Buff
			{
				ChampionName = "leesin",
				Name = "blindmonkqonechaos",
				MenuName = "Lee Sonic Wave",
				Evade = false,
				DoT = true,
				EvadeTimer = 0,
				Cleanse = false,
				CleanseTimer = 0,
				Slot = SpellSlot.Q,
				Interval = 3.0
			},
			new Buff
			{
				ChampionName = "leblanc",
				Name = "leblancsoulshackle",
				MenuName = "Leblanc Shackle",
				Evade = false,
				DoT = false,
				EvadeTimer = 2000,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.E
			},
			new Buff
			{
				ChampionName = "leblanc",
				Name = "leblancsoulshacklem",
				MenuName = "Leblanc Shackle (R)",
				Evade = true,
				DoT = false,
				EvadeTimer = 2000,
				Cleanse = true,
				CleanseTimer = 0,
				Slot = SpellSlot.E
			},
			new Buff
			{
				ChampionName = "rammus",
				Name = "puncturingtauntarmordebuff",
				MenuName = "Rammus Puncturing Taunt",
				Evade = false,
				DoT = false,
				Cleanse = true,
				CleanseTimer = 0,
				EvadeTimer = 0,
				Slot = SpellSlot.E
			},
			new Buff
			{
				Name = "vir",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "virknockup",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "yasuorknockupcombo",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "yasuorknockupcombotar",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "zyrabramblezoneknockup",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "velkozresearchstack",
				Evade = false,
				DoT = true,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown,
				Interval = 0.3
			},
			new Buff
			{
				Name = "frozenheartaura",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "dariusaxebrabcone",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "frozenheartauracosmetic",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "itemsunfirecapeaura",
				Evade = false,
				DoT = true,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown,
				Interval = 1.0
			},
			new Buff
			{
				Name = "fizzmoveback",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "blessingofthelizardelderslow",
				Evade = false,
				DoT = true,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown,
				Interval = 1.0
			},
			new Buff
			{
				Name = "dragonburning",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "rocketgrab2",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "frostarrow",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "pulverize",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Q
			},
			new Buff
			{
				Name = "chilled",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "azirqslow",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Q
			},
			new Buff
			{
				Name = "powerballslow",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Q
			},
			new Buff
			{
				Name = "powerballstun",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Q
			},
			new Buff
			{
				Name = "monkeykingspinknockup",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "headbutttarget",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.W
			},
			new Buff
			{
				Name = "snare",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "hecarimrampstuncheck",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			},
			new Buff
			{
				Name = "hecarimrampattackknockback",
				Evade = false,
				DoT = false,
				Cleanse = false,
				CleanseTimer = 0,
				EvadeTimer = 0,
				QssIgnore = true,
				Slot = SpellSlot.Unknown
			}
		};

		public string ChampionName;
		public bool Cleanse;
		public int CleanseTimer;
		public bool DoT;
		public bool Evade;
		public int EvadeTimer;
		public bool Included;
		public int IncomeDamage;
		public double Interval;
		public string MenuName;
		public string Name;
		public bool QssIgnore;
		public AIHeroClient Sender;
		public SpellSlot Slot;
		public int TickLimiter;
	}
}