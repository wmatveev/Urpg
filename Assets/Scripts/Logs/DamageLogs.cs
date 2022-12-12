using UnityEngine;
using Weapons.DamageCalculation;

namespace Logs
{
    public static class DamageLogs
    {
        public static void DieLogConsoleOutput(Damage damage)
        {
            Debug.Log($"<color=red>[{damage.Target.Id}] is died</color>");
        }

        public static void HitLogConsoleOutput(Damage damage, int hitAmount)
        {
            Debug.Log($"<color=green>[{damage.Attacking.Id} attacked {damage.Target.Id}]</color> : " +
                      $"<color=red>[Damage: {hitAmount}]</color>");
        }
    }
}