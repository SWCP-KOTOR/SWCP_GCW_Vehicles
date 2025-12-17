using HarmonyLib;
using RimWorld;
using Verse;
using Vehicles;

namespace SWCP_GCW_Vehicles
{
    [HarmonyPatch(typeof(HealthUtility), nameof(HealthUtility.AdjustSeverity))]
    public static class HealthUtility_AdjustSeverity_Patch
    {
        public static bool Prefix(Pawn pawn, HediffDef hdDef, float sevOffset)
        {
            if (sevOffset > 0)
            {
                var vehicle = GetVehiclePawnContaining(pawn);
                if (vehicle != null)
                {
                    var protection = vehicle.VehicleDef.GetModExtension<VehicleTemperatureProtection>();
                    if (protection != null)
                    {
                        if ((hdDef == HediffDefOf.Heatstroke && protection.protectFromHeat) || (hdDef == HediffDefOf.Hypothermia && protection.protectFromCold))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static VehiclePawn GetVehiclePawnContaining(Pawn pawn)
        {
            if (pawn.ParentHolder is VehicleRoleHandler roleHandler)
            {
                return roleHandler.vehicle;
            }
            return null;
        }
    }
}
