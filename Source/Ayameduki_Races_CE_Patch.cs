﻿using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace zades.ayamedukiracece
{
    [StaticConstructorOnStartup]
    public static class Aya_CE_Patch
    {
        private static readonly Type TargetType = AccessTools.TypeByName("HAR_IH_Comp_Specification");

        // Harmony initializer
        static Aya_CE_Patch()
        {
            try
            {
                if (TargetType != null)
                {
                    // Create Harmony patch
                    var harmony = new Harmony("zades.ayamedukiracece");
                    harmony.Patch(
                        original: AccessTools.Method(TargetType, "CompTick"),
                        prefix: new HarmonyMethod(typeof(Aya_CE_Patch), nameof(Prefix))
                    );

                    Log.Message("[Ayameduki CE Patch] Harmony patches applied for Idhale mod.");
                }
                else
                {
                    Log.Warning("[Ayameduki CE Patch] HAR_IH_Comp_Specification type not found. Skipping patch.");
                }
            }
            catch (Exception ex)
            {
                Log.Error($"[Ayameduki CE Patch] Error in static constructor: {ex}");
            }
        }

        public static bool Prefix(object __instance, ref int ___EX_Skill_Count)
        {
            // Access and modify EX_Skill_Count directly
            if (___EX_Skill_Count == 5)
            {
                ___EX_Skill_Count = 6;
                Log.Message("[Ayameduki CE Patch] EX_Skill_Count set to 6.");
            }

            return true; // Let the original method run
        }
    }
}
