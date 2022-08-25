using System;
using Rpg.Target;

namespace RPG.Weapons
{
    public class Gun : IWeapon
    {
        public int CountCartridges { get; }     // Количество патронов
        public int IsReloading     { get; }     // В процессе перезарядки
        public int Range           { get; }     // Диапазон выстрела
        public bool CanShoot       { get; }     // Возможность стрелять
        public int ShotDamage      { get; }     // Урон от выстрела / броска

        public Gun(WeaponData weaponData)
        {
            CountCartridges = weaponData.CountCartridges;
            Range = weaponData.Range;
            ShotDamage = weaponData.ShotDamage;
        }

        public ITarget Shoot()
        {
            throw new System.NotImplementedException();
        }

        public void Reload()
        {
            throw new System.NotImplementedException();
        }

        public bool Equals(Gun other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CountCartridges == other.CountCartridges && IsReloading == other.IsReloading && Range == other.Range && CanShoot == other.CanShoot;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Gun)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CountCartridges;
                hashCode = (hashCode * 397) ^ IsReloading;
                hashCode = (hashCode * 397) ^ Range;
                hashCode = (hashCode * 397) ^ CanShoot.GetHashCode();
                return hashCode;
            }
        }
    }
}