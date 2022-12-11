using RPG.Character.CharacterCreationFactory;
using Rpg.Target;
using RPG.Weapons.DamageCalculation;

namespace RPG.Weapons
{
    public class Weapon : IWeapon
    {
        public Weapon(WeaponData weaponData, int currentBulletsAmount, bool canShoot)
        {
            TypeOfWeapon         = weaponData.Type;
            CurrentBulletsAmount = currentBulletsAmount;
            TotalBulletsInClip   = weaponData.CountCartridges;
            Range                = weaponData.Range;
            CanShoot             = canShoot;
            IsReloading          = false;
        }

        public TypesOfWeapons TypeOfWeapon { get; set; }

        public int    CurrentBulletsAmount { get; set; }
        public int    TotalBulletsInClip   { get; set; }
        public int    Range                { get; set; }
        public bool   CanShoot             { get; set; }
        public bool   IsReloading          { get; set; }

        public int ShotDamage { get; }
        
        public ITarget Shoot(Damage damage)
        {
            throw new System.NotImplementedException();
        }
    }
}