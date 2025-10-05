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
            string[] msgs = ["Nothing usable to harvest.","Can't use anything here.","This plant has gone bad.","Can't get any ingredients out of this plant.","This plant is good for nothing.","Nothing to harvest here."];
            System.Random rnd = new System.Random(); 
            return msgs[rnd.Next(0, 5)];
        }
    }
}
