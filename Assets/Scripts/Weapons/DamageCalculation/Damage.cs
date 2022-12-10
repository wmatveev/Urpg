using Rpg.Target;
using RPG.Weapons;
using UnityEngine;

namespace RPG.Weapons.DamageCalculation
{
    public struct Damage
    {
        public Damage(Rpg.Character attacking, ITarget target, IWeapon sourceAttack)
        {
            Attacking    = attacking;
            Target       = target;
            SourceAttack = sourceAttack;
        }

        public Rpg.Character Attacking;        // Атакующий
        public ITarget       Target;           // Цель
        public IWeapon       SourceAttack;     // Источник атаки
    }
}