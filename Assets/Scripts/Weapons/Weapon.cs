using Target;
using Unit.CharacterCreationFactory;
using Weapons.DamageCalculation;

namespace Weapons
{
    public class Weapon : IWeapon
    {
        public Weapon(WeaponData weaponData, int currentBulletsAmount, bool canShoot)
        {
            TypeOfWeapon         = weaponData.Type;
            CurrentBulletsAmount = currentBulletsAmount;
            TotalBulletsInClip   = weaponData.CountCartridges;
            Range                = weaponData.Range;
            ShotDamage           = weaponData.ShotDamage;
            CanShoot             = canShoot;
            IsReloading          = false;
        }

        public TypesOfWeapons TypeOfWeapon { get; }

        public int    CurrentBulletsAmount { get; set; }
        public int    TotalBulletsInClip   { get; set; }
        public int    Range                { get; set; }
        public bool   CanShoot             { get; set; }
        public bool   IsReloading          { get; set; }
        public int    ShotDamage           { get; set; }

        public ITarget Shoot(Damage damage)
        {
            damage.Target.Health.DealDamage(damage);

            return damage.Target;
            // throw new System.NotImplementedException();
        }
    }
}