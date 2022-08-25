using RPG.Character;

namespace RPG.Weapons.DamageCalculation
{
    public interface IDamageCalculator
    {
        int GetDamage(Damage damage, Stats stats);
        int GetDamage(IWeapon attackersWeapon, Stats statsTarget);
    }
}