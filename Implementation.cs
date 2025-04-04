using MelonLoader;
using UnityEngine;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection; 
using System.Collections;

namespace PlantHarvestTweaker
{
	public class PlantHarvestTweakerMod : MelonMod
	{
		public override void OnInitializeMelon()
		{
			Settings.instance.AddToModSettings("Plant Harvest Tweaker");
        }

		

    }
}