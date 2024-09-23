using HarmonyLib;

namespace NoTurningBack
{
    [HarmonyPatch(typeof(Map), nameof(Map.PlaceDoodad))]
    public static class NoPrisonersPatch
    {
        private static void Prefix(Map __instance, ref DoodadInfo doodad)
        {
            if (!Mod.enabled || !Mod.settings.noPrisoners || Map.isEditing)
            {
                return;
            }

            if (doodad.type == DoodadType.Cage || doodad.type == DoodadType.AlienCage)
            {
                doodad.type = DoodadType.CageEmpty;
            }
        }
    }
}

