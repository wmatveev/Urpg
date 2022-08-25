using Rpg.Target;

namespace RPG.Weapons
{
    public class Shotgun : IWeapon
    {
        public int CountCartridges { get; }
        public int IsReloading     { get; }
        public int Range           { get; }
        public bool CanShoot       { get; }
        public int ShotDamage      { get; }

        public Shotgun(WeaponData weaponData)
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

        protected bool Equals(Shotgun other)
        {
            return CountCartridges == other.CountCartridges && IsReloading == other.IsReloading && Range == other.Range && CanShoot == other.CanShoot;
        }

        public bool Equals(Gun other)
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Shotgun)obj);
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