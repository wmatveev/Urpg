using System.Collections.Generic;
using Unit;

namespace Weapons.DamageCalculation
{
    public class DamageCalculator : IDamageCalculator
    {
        /// Коэффициент от типа патрона
        private readonly Dictionary<TypesOfCartridges, float> _damageCoefOfCartridgeType;
        private readonly Dictionary<TypesOfWeapons, float>    _damageCoefOfWeaponType;

        public DamageCalculator(Dictionary<TypesOfCartridges, float> damageCoef, Dictionary<TypesOfWeapons, float> damageCoefWeapon)
        {
            _damageCoefOfCartridgeType = damageCoef;
            _damageCoefOfWeaponType    = damageCoefWeapon;
        }

        public DamageCalculator()
        {
            
        }

        public int GetDamage(Damage damage, Stats stats)
        {
            // // Количество урона * на коэффициент от типа пули * на коэффициент от оружия – защита персонажа
            // int result = (int)(damage.Amount * 
            //     _damageCoefOfCartridgeType[damage.CartridgeType] * _damageCoefOfWeaponType[damage.WeaponType] - stats.DamageProtection);
            //
            // if (result <= 0)
            //     return 0;
            
            return 0;
        }

        public int GetDamage(IWeapon attackersWeapon, Stats statsTarget)
        {
            int result = attackersWeapon.ShotDamage - statsTarget.DamageProtection;

            return result;
        }
    }
}