using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;
using System.Reflection;

namespace NoTurningBack
{
    public static class Mod
    {
        public static UnityModManager.ModEntry mod;
        public static bool enabled;
        public static Settings settings;

        private static bool Load(UnityModManager.ModEntry modEntry)
        {
            mod = modEntry;
            mod.OnGUI = OnGUI;
            mod.OnSaveGUI = OnSaveGUI;
            mod.OnToggle = OnToggle;

            settings = Settings.Load<Settings>(mod);

            new Harmony(mod.Info.Id).PatchAll(Assembly.GetExecutingAssembly());

            return true;
        }

        private static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            settings.noCheckpoints = GUILayout.Toggle(settings.noCheckpoints, "No Checkpoints", GUILayout.Width(400));
            settings.noPrisoners = GUILayout.Toggle(settings.noPrisoners, "No Prisoners", GUILayout.Width(400));
        }

        private static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            settings.Save(modEntry);
        }

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            enabled = value;
            return true;
        }

        public static void Log(object msg)
        {
            mod.Logger.Log(msg.ToString());
        }
    }
}

