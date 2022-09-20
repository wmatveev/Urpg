using RPG.Character.CharacterCreationFactory;
using Rpg.Target;
using RPG.Weapons.DamageCalculation;

namespace RPG.Weapons
{
    public class Knife : IWeapon
    {
        public int IsReloading     { get; }
        public int Range           { get; }
        public bool CanShoot       { get; }
        public int ShotDamage      { get; }

        public Knife(WeaponData weaponData)
        {
            Range = weaponData.Range;
            ShotDamage = weaponData.ShotDamage;
        }

        public ITarget Shoot(Damage damage)
        {
            throw new System.NotImplementedException();
        }

        public void Reload()
        {
            throw new System.NotImplementedException();
        }
    }
}