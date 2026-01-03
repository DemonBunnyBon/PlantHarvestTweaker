using MelonLoader;
using UnityEngine;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection;
using System.Collections;
using Il2CppTLD.Gear;
using Il2Cpp;
using Il2CppTLD.IntBackedUnit;
using Il2CppTLD.AI;
using UnityEngine.AddressableAssets;


namespace PlantHarvestTweaker
{
    internal static class Patches
    {

        [HarmonyPatch(typeof(Harvestable), nameof(Harvestable.Harvest))]
        public class HarvestToolPatch
        {
            public static void Postfix(ref Harvestable __instance)
            {
                GearItem tool = __instance.GetRequiredTool();
                if (tool != null)
                {
                    tool.Degrade(Settings.instance.ToolDegrade);

                }

            }
        }

        [HarmonyPatch(typeof(Harvestable), nameof(Harvestable.Harvest))]
        public class ZeroItemsPatch
        {
            public static void Prefix(ref Harvestable __instance)
            {
                if (Settings.instance.CanFail == true)
                {
                    float failChance = (Settings.instance.FailChance + (0.75f * __instance.m_GearItemCountMax) + (0.25f * __instance.m_GearItemCountMin));
                    if (Utils.RollChance(failChance))
                    {
                        __instance.m_Harvested = true;
                        MeshRenderer primaryMesh = __instance.gameObject.GetComponent<MeshRenderer>();
                        if (primaryMesh != null)
                        {
                            primaryMesh.enabled = false;
                        }
                        Transform cattails = __instance.gameObject.transform.FindChild("OBJ_CatTailShrubFlowers");

                        if (cattails != null)
                        {
                            MeshRenderer cattailsMesh = cattails.GetComponent<MeshRenderer>();
                            if (cattailsMesh != null)
                            {
                                cattailsMesh.enabled = false;
                            }
                        }
                        if ((__instance.gameObject.name.ToLowerInvariant().Contains("preharvest") || __instance.gameObject.name.ToLowerInvariant().Contains("sapling") || __instance.gameObject.name.ToLowerInvariant().Contains("burdock")) && __instance.m_ActivateObjectPostHarvest != null)
                        {
                            __instance.m_ActivateObjectPostHarvest.active = true;
                        }
                        if (__instance.gameObject.GetComponent<Collider>() != null)
                        {
                            __instance.gameObject.GetComponent<Collider>().enabled = false;
                        }
                        HUDMessage.AddMessage(HarvestTweakerUtils.FailMessage());
                        GameAudioManager.PlayGUIError();
                        return;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(Harvestable), nameof(Harvestable.InitializeRequiredTools))]
        public class ToolPatch
        {
            public static void Prefix(ref Harvestable __instance)
            {
                GameObject[] NoToolsArray = [];
                List<GameObject> fulllist = new List<GameObject>();
                GameObject[] KnifeArray = [Addressables.LoadAssetAsync<GameObject>("GEAR_Knife").WaitForCompletion(), Addressables.LoadAssetAsync<GameObject>("GEAR_KnifeImprovised").WaitForCompletion()];
                GameObject[] DLCKnifeArray = [];
                GameObject[] CTKnifeArray = [];
                if (GearItem.LoadGearItemPrefab("GEAR_JeremiahKnife") != null)
                {
                    CTKnifeArray = [Addressables.LoadAssetAsync<GameObject>("GEAR_JeremiahKnife").WaitForCompletion(), Addressables.LoadAssetAsync<GameObject>("GEAR_KnifeScrapMetal").WaitForCompletion()];
                    fulllist.AddRange(CTKnifeArray);
                }
                if (Addressables.LoadAssetAsync<GameObject>("GEAR_CougarClawKnife").WaitForCompletion() != null)
                {
                    DLCKnifeArray = [Addressables.LoadAssetAsync<GameObject>("GEAR_SurvivalKnife").WaitForCompletion(), Addressables.LoadAssetAsync<GameObject>("GEAR_CougarClawKnife").WaitForCompletion()];
                    fulllist.AddRange(KnifeArray);
                    fulllist.AddRange(DLCKnifeArray);

                }
                KnifeArray = fulllist.ToArray();
                GameObject[] HatchetArray = [Addressables.LoadAssetAsync<GameObject>("GEAR_Hatchet").WaitForCompletion(), Addressables.LoadAssetAsync<GameObject>("GEAR_HatchetImprovised").WaitForCompletion(), Addressables.LoadAssetAsync<GameObject>("GEAR_Hacksaw").WaitForCompletion()];
                GameObject[] ExtraArray = [GearItem.LoadGearItemPrefab("GEAR_Prybar").gameObject];
                GameObject[] ToolArray = [];
                fulllist = new List<GameObject>();
                fulllist.AddRange(HatchetArray);
                fulllist.AddRange(KnifeArray);
                fulllist.AddRange(ExtraArray);
                ToolArray = fulllist.ToArray();

                string gearName = __instance.m_GearPrefab?.name ?? "";
                string secondGearName = __instance.m_SecondGearPrefab?.name ?? "";

                if (gearName == "GEAR_RoseHip")
                {
                    switch (Settings.instance.rosehiptool)
                    {
                        case 0:
                            __instance.m_RequiredToolList = NoToolsArray;
                            break;
                        case 1:
                            __instance.m_RequiredToolList = KnifeArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.KnifeMessage();
                            break;
                        case 2:
                            __instance.m_RequiredToolList = HatchetArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.HatchetMessage();
                            break;
                        case 3:
                            __instance.m_RequiredToolList = ToolArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.ToolMessage();
                            break;
                    }
                }
                if (gearName == "GEAR_ReishiMushroom")
                {
                    switch (Settings.instance.reishitool)
                    {
                        case 0:
                            __instance.m_RequiredToolList = NoToolsArray;
                            break;
                        case 1:
                            __instance.m_RequiredToolList = KnifeArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.KnifeMessage();
                            break;
                        case 2:
                            __instance.m_RequiredToolList = HatchetArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.HatchetMessage();
                            break;
                        case 3:
                            __instance.m_RequiredToolList = ToolArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.ToolMessage();
                            break;
                    }
                }
                if (gearName == "GEAR_OldMansBeardHarvested")
                {
                    switch (Settings.instance.lichentool)
                    {
                        case 0:
                            __instance.m_RequiredToolList = NoToolsArray;
                            break;
                        case 1:
                            __instance.m_RequiredToolList = KnifeArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.KnifeMessage();
                            break;
                        case 2:
                            __instance.m_RequiredToolList = HatchetArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.HatchetMessage();
                            break;
                        case 3:
                            __instance.m_RequiredToolList = ToolArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.ToolMessage();
                            break;
                    }
                }
                if (gearName == "GEAR_CattailStalk" || secondGearName == "GEAR_CattailTinder")
                {
                    switch (Settings.instance.cattailtool)
                    {
                        case 0:
                            __instance.m_RequiredToolList = NoToolsArray;
                            break;
                        case 1:
                            __instance.m_RequiredToolList = KnifeArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.KnifeMessage();
                            break;
                        case 2:
                            __instance.m_RequiredToolList = HatchetArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.HatchetMessage();
                            break;
                        case 3:
                            __instance.m_RequiredToolList = ToolArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.ToolMessage();
                            break;
                    }
                }
                if (gearName == "GEAR_Burdock")
                {
                    switch (Settings.instance.burdocktool)
                    {
                        case 0:
                            __instance.m_RequiredToolList = NoToolsArray;
                            break;
                        case 1:
                            __instance.m_RequiredToolList = KnifeArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.KnifeMessage();
                            break;
                        case 2:
                            __instance.m_RequiredToolList = HatchetArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.HatchetMessage();
                            break;
                        case 3:
                            __instance.m_RequiredToolList = ToolArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.ToolMessage();
                            break;
                    }
                }
                if (gearName == "GEAR_Acorn")
                {
                    switch (Settings.instance.acorntool)
                    {
                        case 0:
                            __instance.m_RequiredToolList = NoToolsArray;
                            break;
                        case 1:
                            __instance.m_RequiredToolList = KnifeArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.KnifeMessage();
                            break;
                        case 2:
                            __instance.m_RequiredToolList = HatchetArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.HatchetMessage();
                            break;
                        case 3:
                            __instance.m_RequiredToolList = ToolArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.ToolMessage();
                            break;
                    }
                }
                if (gearName == "GEAR_BirchSapling")
                {
                    switch (Settings.instance.birchtool)
                    {
                        case 0:
                            __instance.m_RequiredToolList = NoToolsArray;
                            break;
                        case 1:
                            __instance.m_RequiredToolList = KnifeArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.KnifeMessage();
                            break;
                        case 2:
                            __instance.m_RequiredToolList = HatchetArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.HatchetMessage();
                            break;
                        case 3:
                            __instance.m_RequiredToolList = ToolArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.ToolMessage();
                            break;
                    }
                }
                if (gearName == "GEAR_MapleSapling")
                {
                    switch (Settings.instance.mapletool)
                    {
                        case 0:
                            __instance.m_RequiredToolList = NoToolsArray;
                            break;
                        case 1:
                            __instance.m_RequiredToolList = KnifeArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.KnifeMessage();
                            break;
                        case 2:
                            __instance.m_RequiredToolList = HatchetArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.HatchetMessage();
                            break;
                        case 3:
                            __instance.m_RequiredToolList = ToolArray;
                            __instance.m_RequiredToolText = HarvestTweakerUtils.ToolMessage();
                            break;
                    }
                }
            }
        }


        [HarmonyPatch(typeof(Harvestable), nameof(Harvestable.Awake))]

        public class HarvestablePatch
        {
            public static void Postfix(ref Harvestable __instance)
            {
                string gearName = __instance.m_GearPrefab?.name ?? "";
                string secondGearName = __instance.m_SecondGearPrefab?.name ?? "";

                if (gearName == "GEAR_RoseHip")
                {
                    __instance.m_GearItemCountMin = Settings.instance.RoseMin;
                    __instance.m_GearItemCountMax = Settings.instance.RoseMax;
                }
                if (gearName == "GEAR_ReishiMushroom")
                {
                    __instance.m_GearItemCountMin = Settings.instance.ReishiMin;
                    __instance.m_GearItemCountMax = Settings.instance.ReishiMax;
                }
                if (gearName == "GEAR_OldMansBeardHarvested")
                {
                    __instance.m_GearItemCountMin = Settings.instance.LichenMin;
                    __instance.m_GearItemCountMax = Settings.instance.LichenMax;
                }
                if (gearName == "GEAR_CattailStalk" || secondGearName == "GEAR_CattailTinder")
                {
                    __instance.m_GearItemCountMax = Settings.instance.CatTailStalkMax;
                    __instance.m_GearItemCountMin = Settings.instance.CatTailStalkMin;
                    __instance.m_SecondGearItemCountMin = Settings.instance.CatTailHeadMin;
                    __instance.m_SecondGearItemCountMax = Settings.instance.CatTailHeadMax;
                }
                if (gearName == "GEAR_Burdock")
                {
                    __instance.m_GearItemCountMax = Settings.instance.BurdockMax;
                    __instance.m_GearItemCountMin = Settings.instance.BurdockMin;
                }
                if (gearName == "GEAR_Acorn")
                {
                    __instance.m_GearItemCountMax = Settings.instance.AcornMax;
                    __instance.m_GearItemCountMin = Settings.instance.AcornMin;
                }
                if (gearName == "GEAR_BirchSapling")
                {
                    __instance.m_GearItemCountMax = Settings.instance.BirchMax;
                    __instance.m_GearItemCountMin = Settings.instance.BirchMin;
                }
                if (gearName == "GEAR_MapleSapling")
                {
                    __instance.m_GearItemCountMax = Settings.instance.MapleMax;
                    __instance.m_GearItemCountMin = Settings.instance.MapleMin;
                }
            }
        }


        [HarmonyPatch(typeof(HarvestableInteraction), nameof(Harvestable.Awake))]

        public class HarvestableInteractionPatch
        {
            public static void Postfix(ref HarvestableInteraction __instance)
            {
                string gearName = __instance.m_Harvestable.m_GearPrefab?.name ?? "";
                string secondGearName = __instance.m_Harvestable.m_SecondGearPrefab?.name ?? "";

                if (gearName == "GEAR_RoseHip")
                {
                    __instance.m_DefaultHoldTime = Settings.instance.RoseHarvest;
                }
                if (gearName == "GEAR_ReishiMushroom")
                {
                    __instance.m_DefaultHoldTime = Settings.instance.ReishiHarvest;
                }
                if (gearName == "GEAR_OldMansBeardHarvested")
                {
                    __instance.m_DefaultHoldTime = Settings.instance.LichenHarvest;
                }
                if (gearName == "GEAR_CattailStalk" || secondGearName == "GEAR_CattailTinder")
                {
                    __instance.m_DefaultHoldTime = Settings.instance.CatTailHarvest;
                }
                if (gearName == "GEAR_Burdock")
                {
                    __instance.m_DefaultHoldTime = Settings.instance.BurdockHarvest;
                }
                if (gearName == "GEAR_Acorn")
                {
                    __instance.m_DefaultHoldTime = Settings.instance.AcornHarvest;
                }
                if (gearName == "GEAR_BirchSapling")
                {
                    __instance.m_DefaultHoldTime = Settings.instance.BirchHarvest;
                }
                if (gearName == "GEAR_MapleSapling")
                {
                    __instance.m_DefaultHoldTime = Settings.instance.MapleHarvest;
                }
                if (gearName == "GEAR_Salt")
                {
                    __instance.m_DefaultHoldTime = Settings.instance.SaltHarvest;
                }
            }
        }
    }
}