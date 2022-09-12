using RPG.Character;

namespace RPG.Weapons.DamageCalculation
{
    public class TestDamageCalculator : IDamageCalculator
    {
        public int GetDamage(Damage damage, Stats stats)
        {
            return 0; // damage.Amount;
        }

        public int GetDamage(IWeapon attackersWeapon, Stats statsTarget)
        {
            throw new System.NotImplementedException();
        }
    }
}