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

            switch (weaponData.Type)
            {
                case TypesOfWeapons.Gun:
                    weapon = new Gun(weaponData);
                    break;
                case TypesOfWeapons.Rifle:
                    weapon = new Rifle(weaponData);
                    break;
                case TypesOfWeapons.AutomaticRifle:
                    weapon = new AutomaticRifle(weaponData);
                    break;
                case TypesOfWeapons.Shotgun:
                    weapon = new Shotgun(weaponData);
                    break;
                case TypesOfWeapons.Knife:
                    weapon = new Knife(weaponData);
                    break;

                default:
                    throw new Exception("Weapon not found");
                    break;
            }

            return weapon;
        }
    }
}