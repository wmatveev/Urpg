using Target;
using Unit;

namespace Weapons.DamageCalculation
{
    public struct Damage
    {
        public Damage(Character attacking, ITarget target, IWeapon sourceAttack)
        {
            Attacking    = attacking;
            Target       = target;
            SourceAttack = sourceAttack;
        }

        public Character Attacking;        // Атакующий
        public ITarget   Target;           // Цель
        public IWeapon   SourceAttack;     // Источник атаки
    }
}