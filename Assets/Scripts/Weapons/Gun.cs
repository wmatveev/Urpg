using System;
using RPG.Character.CharacterCreationFactory;
using Rpg.Target;
using RPG.Weapons.DamageCalculation;

namespace RPG.Weapons
{
    public class Gun : IWeapon
    {
        public int IsReloading     { get; }     // В процессе перезарядки
        public int Range           { get; }     // Диапазон выстрела
        public bool CanShoot       { get; }     // Возможность стрелять
        public int ShotDamage      { get; }     // Урон от выстрела / броска

        private readonly Clip _clip;

        public Gun(WeaponData weaponData)
        {
            Range = weaponData.Range;
            ShotDamage = weaponData.ShotDamage;

            // Создаиние обоймы
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