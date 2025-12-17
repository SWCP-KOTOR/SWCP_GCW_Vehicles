using HarmonyLib;
using Verse;

namespace SWCP_GCW_Vehicles
{
    public class SWCP_GCW_VehiclesMod : Mod
    {
        public SWCP_GCW_VehiclesMod(ModContentPack pack) : base(pack)
        {
            new Harmony("SWCP_GCW_VehiclesMod").PatchAll();
        }
    }
}