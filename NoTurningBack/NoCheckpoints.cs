using System;
using HarmonyLib;
using UnityEngine;

namespace NoTurningBack
{
    [HarmonyPatch(typeof(HeroController), nameof(HeroController.SetCheckPointInternal))]
    public static class NoCheckpointsPatch
    {
        private static void Prefix(HeroController __instance, ref Vector2 checkPointPos, ref int checkPointID)
        {
            if (!Mod.enabled || !Mod.settings.noCheckpoints || Map.isEditing)
            {
                return;
            }

            try
            {
                Map.ClearSuperCheckpointStatus();
                checkPointPos = Map.FindStartLocation();
                checkPointID = 0;
            }
            catch(Exception e)
            {
                Mod.Log(e);
            }
        }
    }
}

