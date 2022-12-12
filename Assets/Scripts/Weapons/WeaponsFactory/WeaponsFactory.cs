using Unit.CharacterCreationFactory;

namespace Weapons.WeaponsFactory
{
    public class WeaponsFactory : IWeaponsFactory
    {
        private Balance _balans;
        
        public WeaponsFactory(Balance balance)
        {
            _balans = balance;
        }

        // Создаем оружие по типу из json
        public IWeapon CreateWeapon(string idWeapon)
        {
            IWeapon weapon = null;

            _balans.Weapons.TryGetValue(idWeapon, out WeaponData weaponData);

            // Создаем оружие
            weapon = new Weapon(weaponData, 10000, true);

            // switch (weaponData.Type)
            // {
            //     case TypesOfWeapons.Gun:
            //         break;
            //     case TypesOfWeapons.Rifle:
            //         break;
            //     case TypesOfWeapons.AutomaticRifle:
            //         break;
            //     case TypesOfWeapons.Shotgun:
            //         break;
            //     case TypesOfWeapons.Knife:
            //         break;
            //
            //     default:
            //         throw new Exception("Weapon not found");
            // }

            return weapon;
        }
    }
}