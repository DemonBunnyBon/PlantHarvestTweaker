using ModSettings;

namespace PlantHarvestTweaker
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

        [Section("Rose Hips Settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of rosehips per bush. (Confirm and scene reload/transition required.) [Default: 8]")]
        [Slider(1,16)]
        public int RoseMin = 8;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of rosehips per bush. (Confirm and scene reload/transition required.) [Default: 8]")]
        [Slider(1,16)]
        public int RoseMax = 8;

        [Name("Rosehip harvest time")]
        [Description("Time in seconds to harvest a rosehip bush. (Confirm and scene reload/transition required.) [Default: 2]")]
        [Slider(0, 10, 21, NumberFormat = "{0:0.##}s")]
        public float RoseHarvest = 2;

        [Section("Reishi Settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of reishi per plant. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 4)]
        public int ReishiMin = 1;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of reishi per plant. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 4)]
        public int ReishiMax = 1;

        [Name("Reishi harvest time")]
        [Description("Time in seconds to harvest a reishi mushroom. (Confirm and scene reload/transition required.) [Default: 2]")]
        [Slider(0, 10, 21, NumberFormat = "{0:0.##}s")]
        public float ReishiHarvest = 2;

        [Section("Lichen Settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of beard lichen per plant. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 4)]
        public int LichenMin = 1;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of beard lichen per plant. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 4)]
        public int LichenMax = 1;

        [Name("Lichen harvest time")]
        [Description("Time in seconds to harvest beard lichen. (Confirm and scene reload/transition required.) [Default: 2]")]
        [Slider(0, 10, 21, NumberFormat = "{0:0.##}s")]
        public float LichenHarvest = 2;

        [Section("Cattail Settings")]

        [Name("Minimum harvest amount: Stalk")]
        [Description("Controls the minimum harvest amount of cattail stalk per plant. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 4)]
        public int CatTailStalkMin = 1;

        [Name("Maximum harvest amount: Stalk")]
        [Description("Controls the maximum harvest amount of cattail stalk per plant. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 4)]
        public int CatTailStalkMax = 1;

        [Name("Minimum harvest amount: Head")]
        [Description("Controls the minimum harvest amount of cattail head per plant. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 4)]
        public int CatTailHeadMin = 1;

        [Name("Maximum harvest amount: Head")]
        [Description("Controls the maximum harvest amount of cattail head per plant. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 4)]
        public int CatTailHeadMax = 1;

        [Name("Cattail harvest time")]
        [Description("Time in seconds to harvest a cattail plant. (Confirm and scene reload/transition required.) [Default: 2]")]
        [Slider(0, 10, 21, NumberFormat = "{0:0.##}s")]
        public float CatTailHarvest = 2;

        [Section("Burdock settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of burdock per plant. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 5)]
        public int BurdockMin = 1;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of burdock per plant. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 5)]
        public int BurdockMax = 1;

        [Name("Burdock harvest time")]
        [Description("Time in seconds to harvest a burdock plant. (Confirm and scene reload/transition required.) [Default: 10]")]
        [Slider(0, 20, 41, NumberFormat = "{0:0.##}s")]
        public float BurdockHarvest = 10;

        [Section("Acorn settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of acorn batches per pile. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 5)]
        public int AcornMin = 1;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of acorn batches per pile. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 5)]
        public int AcornMax = 1;

        [Name("Acorn harvest time")]
        [Description("Time in seconds to dig up acorns. (Confirm and scene reload/transition required.) [Default: 2]")]
        [Slider(0, 10, 21, NumberFormat = "{0:0.##}s")]
        public float AcornHarvest = 2;

        [Section("Birch Sapling Settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of a birch sapling. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 3)]
        public int BirchMin = 1;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of a birch sapling. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 3)]
        public int BirchMax = 1;

        [Name("Birch sapling harvest time")]
        [Description("Time in seconds to harvest a birch sapling. (Confirm and scene reload/transition required.) [Default: 2]")]
        [Slider(0, 10, 21, NumberFormat = "{0:0.##}s")]
        public float BirchHarvest = 2;

        [Section("Maple Sapling Settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of a maple sapling. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 3)]
        public int MapleMin = 1;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of a maple sapling. (Confirm and scene reload/transition required.) [Default: 1]")]
        [Slider(1, 3)]
        public int MapleMax = 1;

        [Name("Maple sapling harvest time")]
        [Description("Time in seconds to harvest a maple sapling. (Confirm and scene reload/transition required.) [Default: 2]")]
        [Slider(0, 10, 21, NumberFormat = "{0:0.##}s")]
        public float MapleHarvest = 2;

        [Section("Other")]

        [Name("Salt harvest time")]
        [Description("Time in seconds to harvest salt. (Confirm and scene reload/transition required.) [Default: 2]")]
        [Slider(0, 10, 21, NumberFormat = "{0:0.##}s")]
        public float SaltHarvest = 2;

        [Section("Difficulty")]

        [Name("Harvest fail possibility")]
        [Description("If enabled adds a small variable probability to fail a harvest and get nothing out of a plant. [Default: false]")]
        public bool CanFail = false;

        [Name("Base fail chance")]
        [Description("Base chance to fail a harvest in %. Harvest fail possibility needs to be enabled. [Default: 5]\nThis is adjusted by the following formula:\n(Base Chance + (0.75 * maximum harvest amount) + (0.25 * minimum harvest amount))%")]
        [Slider(0, 50, NumberFormat = "{0:0.##}%")]
        public int FailChance = 5;

        [Name("Tool degrade per harvest")]
        [Description("The amount of HP a tool will lose when harvesting plants. (Eg. When harvesting a sapling with a hatchet.) [Default: 0]")]
        [Slider(0, 10, 21, NumberFormat = "{0:0.##}%")]
        public float ToolDegrade = 0f;

        [Name("Rosehip needed tool")]
        [Description("Tool type needed to harvest rosehips. (Confirm and scene reload/transition required.) [Default: none]")]
        [Choice("None", "Knife", "Hatchet/Hacksaw", "Any tool")]
        public int rosehiptool = 0;

        [Name("Reishi needed tool")]
        [Description("Tool type needed to harvest reishi. (Confirm and scene reload/transition required.) [Default: none]")]
        [Choice("None", "Knife", "Hatchet/Hacksaw", "Any tool")]
        public int reishitool = 0;

        [Name("Lichen needed tool")]
        [Description("Tool type needed to harvest lichen. (Confirm and scene reload/transition required.) [Default: none]")]
        [Choice("None", "Knife", "Hatchet/Hacksaw", "Any tool")]
        public int lichentool = 0;

        [Name("Cattail needed tool")]
        [Description("Tool type needed to harvest cattails. (Confirm and scene reload/transition required.) [Default: none]")]
        [Choice("None", "Knife", "Hatchet/Hacksaw", "Any tool")]
        public int cattailtool = 0;

        [Name("Burdock needed tool")]
        [Description("Tool type needed to harvest burdock. (Confirm and scene reload/transition required.) [Default: Any tool]")]
        [Choice("None", "Knife", "Hatchet/Hacksaw", "Any tool")]
        public int burdocktool = 3;

        [Name("Acorn needed tool")]
        [Description("Tool type needed to harvest acorns. (Confirm and scene reload/transition required.) [Default: none]")]
        [Choice("None", "Knife", "Hatchet/Hacksaw", "Any tool")]
        public int acorntool = 0;

        [Name("Birch Sapling needed tool")]
        [Description("Tool type needed to harvest birch saplings. (Confirm and scene reload/transition required.) [Default: Hatchet/Hacksaw]")]
        [Choice("None", "Knife", "Hatchet/Hacksaw", "Any tool")]
        public int birchtool = 2;

        [Name("Maple Sapling needed tool")]
        [Description("Tool type needed to harvest maple saplings. (Confirm and scene reload/transition required.) [Default: Hatchet/Hacksaw]")]
        [Choice("None", "Knife", "Hatchet/Hacksaw", "Any tool")]
        public int mapletool = 2;


        [Section("Joke Settings")]

        [Name("Funny")]
        [Description("Enables the funny messages.")]
        public bool funny = false;







        [Section("Reset Settings")]
        [Name("Reset To Default")]
        [Description("Resets all settings to Default. (Confirm and scene reload/transition required.)")]
        public bool ResetSettings = false;
        protected override void OnConfirm()
        {
            ApplyReset();
            instance.ResetSettings = false;
            base.OnConfirm();
        }
        internal static void OnLoad()
        {
            instance.RefreshFields();
        }
        internal void RefreshFields()
        {
            
        }
        public static void ApplyReset()
        {
            if (instance.ResetSettings == true)
            {
                Settings.instance.rosehiptool = 0;
                Settings.instance.reishitool = 0;
                Settings.instance.mapletool = 2;
                Settings.instance.birchtool = 2;
                Settings.instance.burdocktool = 3;
                Settings.instance.lichentool = 0;
                Settings.instance.cattailtool = 0;
                Settings.instance.acorntool = 0;
                Settings.instance.funny = false;
                Settings.instance.FailChance = 5;
                Settings.instance.CanFail = false;
                Settings.instance.RoseHarvest = 2;
                Settings.instance.RoseMax = 8;
                Settings.instance.RoseMin = 8;
                Settings.instance.ReishiMin = 1;
                Settings.instance.ReishiMax = 1;
                Settings.instance.ReishiHarvest = 2;
                Settings.instance.LichenHarvest = 2;
                Settings.instance.LichenMax = 1;
                Settings.instance.LichenMin = 1;
                Settings.instance.CatTailHarvest = 2;
                Settings.instance.CatTailHeadMax = 1;
                Settings.instance.CatTailHeadMin = 1;
                Settings.instance.CatTailStalkMax = 1;
                Settings.instance.CatTailStalkMin = 1;
                Settings.instance.BurdockHarvest = 10;
                Settings.instance.BurdockMax = 1;
                Settings.instance.BurdockMin = 1;
                Settings.instance.AcornHarvest = 2;
                Settings.instance.AcornMax = 1;
                Settings.instance.AcornMin = 1;
                Settings.instance.BirchHarvest = 2;
                Settings.instance.BirchMax = 1;
                Settings.instance.BirchMin = 1;
                Settings.instance.MapleHarvest = 2;
                Settings.instance.MapleMin = 1;
                Settings.instance.MapleMax = 1;
                Settings.instance.ToolDegrade = 0;
                Settings.instance.SaltHarvest = 2;

                instance.ResetSettings = false;
                instance.RefreshFields();
                instance.RefreshGUI();
            }
        }
    }
}
