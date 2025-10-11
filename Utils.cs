using Harmony;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantHarvestTweaker
{
    public class HarvestTweakerUtils
    {
        public static string FailMessage()
        {
            string[] msgs = ["Nothing usable to harvest.","Can't use any part of this plant.","This plant has gone bad.","Can't get any ingredients out of this plant.","This plant is rotten.","Nothing harvestable left from this plant."];
            System.Random rnd = new System.Random(); 
            if(Settings.instance.funny)
            {
                string[] funny = ["YOU'RE FIRED!","Honk.","These damn plants!", "Kilroy was here.", "This is not the plant you're looking for.", "Plant delivery expected in 99999 hours.", "The red M&M would like to say something about this.", "This town is full of monsters! How can you just sit here and harvest plants?", "This plant did not consent.", "But it refused.", "Clown emoji."];
                return funny[rnd.Next(0, 11)];
            }
            return msgs[rnd.Next(0, 6)];
        }
        public static string KnifeMessage()
        {
            return "Requires a knife to harvest.";
        }

        public static string HatchetMessage()
        {
            return "Requires a hatchet or hacksaw to harvest.";
        }

        public static string ToolMessage()
        {
            return "Requires a tool to harvest.";
        }
    }
}
