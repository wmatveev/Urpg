using System;
using RPG.Character.CharacterCreationFactory;

namespace RPG.Weapons.WeaponsFactory
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

            // weapon = new Weapon(weaponData.Type., 10000, weaponData.CountCartridges,
            //     weaponData.Range, true, false);

            // Создаем оружие
            switch (weaponData.Type)
            {
                case TypesOfWeapons.Gun:
                    // weapon = new Gun(weaponData);
                    break;
                case TypesOfWeapons.Rifle:
                    break;
                case TypesOfWeapons.AutomaticRifle:
                    break;
                case TypesOfWeapons.Shotgun:
                    break;
                case TypesOfWeapons.Knife:
                    break;

                default:
                    throw new Exception("Weapon not found");
            }

            return weapon;
        }
    }
}