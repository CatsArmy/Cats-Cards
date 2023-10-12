using HarmonyLib;
using Lightsaber.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightsaber.Patches
{
    internal class AttackPatch
    {
        [HarmonyPatch(typeof(Gun), nameof(Gun.Attack))]
        class GunPatchAttack
        {
            static bool Prefix(Gun __instance)
            {
                return (!__instance.GetData().disabled);
            }
        }
    }
}
