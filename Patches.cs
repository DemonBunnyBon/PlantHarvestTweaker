using MelonLoader;
using UnityEngine;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection;
using System.Collections;
using Il2CppTLD.Gear;
using Il2Cpp;
using Il2CppTLD.IntBackedUnit;

namespace PlantHarvestTweaker
{
    internal static class Patches
    {

        [HarmonyPatch(typeof(Harvestable), "Harvest")]
        public class HarvestToolPatch
        {
            public static void Postfix(ref Harvestable __instance)
            {
                GearItem tool = __instance.GetRequiredTool();
                if(tool != null)
                {
                    tool.Degrade(Settings.instance.ToolDegrade);
                }
                
            }
        }

        [HarmonyPatch(typeof(Harvestable), "Awake")]

        public class HarvestablePatch
        {
            public static void Postfix(ref Harvestable __instance)
            {
                if(__instance.m_GearPrefab==GearItem.LoadGearItemPrefab("GEAR_Rosehip"))
                {
                    __instance.m_GearItemCountMin = Settings.instance.RoseMin;
                    __instance.m_GearItemCountMax = Settings.instance.RoseMax;
                }
                if(__instance.m_GearPrefab==GearItem.LoadGearItemPrefab("GEAR_ReishiMushroom"))
                {
                    __instance.m_GearItemCountMin = Settings.instance.ReishiMin;
                    __instance.m_GearItemCountMax = Settings.instance.ReishiMax;
                }
                if(__instance.m_GearPrefab == GearItem.LoadGearItemPrefab("GEAR_OldMansBeardHarvested"))
                {
                    __instance.m_GearItemCountMin = Settings.instance.LichenMin;
                    __instance.m_GearItemCountMax = Settings.instance.LichenMax;
                }
                if(__instance.m_GearPrefab == GearItem.LoadGearItemPrefab("GEAR_CattailStalk") || __instance.m_SecondGearPrefab == GearItem.LoadGearItemPrefab("GEAR_CattailTinder"))
                {
                    __instance.m_GearItemCountMax = Settings.instance.CatTailStalkMax;
                    __instance.m_GearItemCountMin = Settings.instance.CatTailStalkMin;
                    __instance.m_SecondGearItemCountMin = Settings.instance.CatTailHeadMin;
                    __instance.m_SecondGearItemCountMax = Settings.instance.CatTailHeadMax;
                }
                if(__instance.m_GearPrefab == GearItem.LoadGearItemPrefab("GEAR_Burdock"))
                {
                    __instance.m_GearItemCountMax = Settings.instance.BurdockMax;
                    __instance.m_GearItemCountMin = Settings.instance.BurdockMin;
                }
                if(__instance.m_GearPrefab == GearItem.LoadGearItemPrefab("GEAR_Acorn"))
                {
                    __instance.m_GearItemCountMax = Settings.instance.AcornMax;
                    __instance.m_GearItemCountMin = Settings.instance.AcornMin;
                }
                if(__instance.m_GearPrefab == GearItem.LoadGearItemPrefab("GEAR_BirchSapling"))
                {
                    __instance.m_GearItemCountMax = Settings.instance.BirchMax;
                    __instance.m_GearItemCountMin = Settings.instance.BirchMin;
                }
                if (__instance.m_GearPrefab == GearItem.LoadGearItemPrefab("GEAR_MapleSapling"))
                {
                    __instance.m_GearItemCountMax = Settings.instance.MapleMax;
                    __instance.m_GearItemCountMin = Settings.instance.MapleMin;
                }
            }
        }


        [HarmonyPatch(typeof(HarvestableInteraction), "Awake")]

        public class HarvestableInteractionPatch
        {
            public static void Postfix(ref HarvestableInteraction __instance)
            {
                if(__instance.m_Harvestable.m_GearPrefab==GearItem.LoadGearItemPrefab("Gear_Rosehip"))
                {
                    __instance.m_DefaultHoldTime = Settings.instance.RoseHarvest;
                }
                if(__instance.m_Harvestable.m_GearPrefab == GearItem.LoadGearItemPrefab("Gear_ReishiMushroom"))
                {
                    __instance.m_DefaultHoldTime = Settings.instance.ReishiHarvest;
                }
                if(__instance.m_Harvestable.m_GearPrefab == GearItem.LoadGearItemPrefab("Gear_OldMansBeardHarvested"))
                {
                    __instance.m_DefaultHoldTime = Settings.instance.LichenHarvest;
                }
                if(__instance.m_Harvestable.m_GearPrefab == GearItem.LoadGearItemPrefab("GEAR_CattailStalk") || __instance.m_Harvestable.m_SecondGearPrefab == GearItem.LoadGearItemPrefab("GEAR_CattailTinder"))
                {
                    __instance.m_DefaultHoldTime = Settings.instance.CatTailHarvest;
                }
                if(__instance.m_Harvestable.m_GearPrefab == GearItem.LoadGearItemPrefab("GEAR_Burdock"))
                {
                    __instance.m_DefaultHoldTime = Settings.instance.BurdockHarvest;
                }
                if(__instance.m_Harvestable.m_GearPrefab == GearItem.LoadGearItemPrefab("Gear_Acorn"))
                {
                    __instance.m_DefaultHoldTime = Settings.instance.AcornHarvest;
                }
                if (__instance.m_Harvestable.m_GearPrefab == GearItem.LoadGearItemPrefab("Gear_BirchSapling"))
                {
                    __instance.m_DefaultHoldTime = Settings.instance.BirchHarvest;
                }
                if (__instance.m_Harvestable.m_GearPrefab == GearItem.LoadGearItemPrefab("Gear_MapleSapling"))
                {
                    __instance.m_DefaultHoldTime = Settings.instance.MapleHarvest;
                }
                if (__instance.m_Harvestable.m_GearPrefab == GearItem.LoadGearItemPrefab("Gear_Salt"))
                {
                    __instance.m_DefaultHoldTime = Settings.instance.SaltHarvest;
                }
            }
        }
    }
}
