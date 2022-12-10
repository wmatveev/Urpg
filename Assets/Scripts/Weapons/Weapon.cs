using Rpg.Target;
using RPG.Weapons.DamageCalculation;

namespace RPG.Weapons
{
    public class Weapon : IWeapon
    {
        public Weapon(string typeOfWeapon, int currentBulletsAmount, int totalBulletsInClip, int range, bool canShoot, bool isReloading)
        {
            TypeOfWeapon         = typeOfWeapon;
            CurrentBulletsAmount = currentBulletsAmount;
            TotalBulletsInClip   = totalBulletsInClip;
            Range                = range;
            CanShoot             = canShoot;
            IsReloading          = isReloading;
        }

        public string TypeOfWeapon      { get; set; }
        public int CurrentBulletsAmount { get; set; }
        public int TotalBulletsInClip   { get; set; }
        public int Range                { get; set; }
        public bool CanShoot            { get; set; }
        public bool IsReloading         { get; set; }

        public int ShotDamage { get; }
        
        public ITarget Shoot(Damage damage)
        {
            throw new System.NotImplementedException();
        }
    }
}