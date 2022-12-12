using Unit;

namespace Weapons.DamageCalculation
{
    public interface IDamageCalculator
    {
        int GetDamage(Damage damage, Stats stats);
        int GetDamage(IWeapon attackersWeapon, Stats statsTarget);
    }
}