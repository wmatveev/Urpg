using Rpg.Target;
using RPG.Weapons.DamageCalculation;

namespace RPG.Weapons
{
    public class Shotgun : IWeapon
    {
        public int IsReloading     { get; }
        public int Range           { get; }
        public bool CanShoot       { get; }
        public int ShotDamage      { get; }

        private readonly Clip _clip;

        public Shotgun(WeaponData weaponData)
        {
            Range = weaponData.Range;
            ShotDamage = weaponData.ShotDamage;

            _clip = new Clip(weaponData.CountCartridges);
        }

        public ITarget Shoot(Damage damage)
        {
            if (_clip != null)
            {
                if (_clip.CheckBulletsInClip())
                {
                    damage.Target.Health.DealDamage(damage);
                }
            }

            return damage.Target;
        }

        public void Reload()
        {
            throw new System.NotImplementedException();
        }
    }
}