using ModSettings;

namespace PlantHarvestTweaker
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

        [Section("Rose Hips Settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of rosehips per bush.")]
        [Slider(1,16)]
        public int RoseMin = 8;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of rosehips per bush.")]
        [Slider(1,16)]
        public int RoseMax = 8;

        [Name("Rosehip harvest time")]
        [Description("Time in seconds to harvest a rosehip bush.")]
        [Slider(1, 10)]
        public int RoseHarvest = 2;

        [Section("Reishi Settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of reishi per plant.")]
        [Slider(1, 4)]
        public int ReishiMin = 1;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of reishi per plant.")]
        [Slider(1, 4)]
        public int ReishiMax = 1;

        [Name("Reishi harvest time")]
        [Description("Time in seconds to harvest a reishi mushroom.")]
        [Slider(1, 10)]
        public int ReishiHarvest = 2;

        [Section("Lichen Settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of beard lichen per plant.")]
        [Slider(1, 4)]
        public int LichenMin = 1;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of beard lichen per plant.")]
        [Slider(1, 4)]
        public int LichenMax = 1;

        [Name("Lichen harvest time")]
        [Description("Time in seconds to harvest beard lichen.")]
        [Slider(1, 10)]
        public int LichenHarvest = 2;

        [Section("Cattail Settings")]

        [Name("Minimum harvest amount: Stalk")]
        [Description("Controls the minimum harvest amount of cattail stalk per plant.")]
        [Slider(1, 4)]
        public int CatTailStalkMin = 1;

        [Name("Maximum harvest amount: Stalk")]
        [Description("Controls the maximum harvest amount of cattail stalk per plant.")]
        [Slider(1, 4)]
        public int CatTailStalkMax = 1;

        [Name("Minimum harvest amount: Head")]
        [Description("Controls the minimum harvest amount of cattail head per plant.")]
        [Slider(1, 4)]
        public int CatTailHeadMin = 1;

        [Name("Maximum harvest amount: Head")]
        [Description("Controls the maximum harvest amount of cattail head per plant.")]
        [Slider(1, 4)]
        public int CatTailHeadMax = 1;

        [Name("Cattail harvest time")]
        [Description("Time in seconds to harvest a cattail plant.")]
        [Slider(1, 10)]
        public int CatTailHarvest = 2;

        [Section("Burdock settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of burdock per plant.")]
        [Slider(1, 5)]
        public int BurdockMin = 1;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of burdock per plant.")]
        [Slider(1, 5)]
        public int BurdockMax = 1;

        [Name("Burdock harvest time")]
        [Description("Time in seconds to harvest a burdock plant.")]
        [Slider(1, 20)]
        public int BurdockHarvest = 10;

        [Section("Acorn settings")]

        [Name("Minimum harvest amount")]
        [Description("Controls the minimum harvest amount of acorn batches per pile.")]
        [Slider(1, 5)]
        public int AcornMin = 1;

        [Name("Maximum harvest amount")]
        [Description("Controls the maximum harvest amount of acorn batches per pile.")]
        [Slider(1, 5)]
        public int AcornMax = 1;

        [Name("Lichen harvest time")]
        [Description("Time in seconds to dig up acorns.")]
        [Slider(1, 10)]
        public int AcornHarvest = 2;





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

                instance.ResetSettings = false;
                instance.RefreshFields();
                instance.RefreshGUI();
            }
        }
    }
}
