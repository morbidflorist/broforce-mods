using UnityModManagerNet;

namespace NoTurningBack
{
    public class Settings : UnityModManager.ModSettings
    {
        public bool noCheckpoints;
        public bool noPrisoners;

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Mod.Log($"No Checkpoints: {noCheckpoints}");
            Mod.Log($"No Prisoners: {noPrisoners}");
            Save(this, modEntry);
        }
    }
}

