using System;
using Weapons;
using Weapons.DamageCalculation;
using Weapons.WeaponsFactory;

namespace Character.CharacterCreationFactory
{
    public class CharactersFactory : ICharatersFactory
    {
        private readonly Balance           _balance;
        private readonly IDamageCalculator _damageCalculator;
        private readonly IWeaponsFactory   _weaponsFactory;

        public CharactersFactory(Balance balance, IDamageCalculator damageCalculator, IWeaponsFactory weaponsFactory)
        {
            _balance          = balance;
            _damageCalculator = damageCalculator;
            _weaponsFactory   = weaponsFactory;
        }

        public Character CreateCharacter(string idCharacter)
        {
            Character Character = null;

            if (_balance.PlayerBalance.TryGetValue(idCharacter, out var playerData))
            {
                Character = new Character(idCharacter, playerData.Stats, _damageCalculator);

                // Бежим по списку оружия из json и создаем его
                foreach (string i in playerData.AvailableWeapons) {
                    IWeapon weapon = _weaponsFactory.CreateWeapon(i);

                    if( weapon != null) {
                        Character.Weapons.Add( i, weapon );
                        Character.WeaponController.AddWeaponToCharacter(weapon);
                    }
                }
            }
            else if (_balance.EnemyBalance.TryGetValue(idCharacter, out var enemyData))
            {
                Character = new Character(idCharacter, enemyData.Stats, _damageCalculator);

                // Бежим по списку оружия из json и создаем его
                foreach (string i in enemyData.AvailableWeapons) {
                    IWeapon weapon = _weaponsFactory.CreateWeapon(i);

                    if( weapon != null) {
                        Character.Weapons.Add( i, weapon );
                        Character.WeaponController.AddWeaponToCharacter(weapon);
                    }
                }
            }
            else { throw new Exception("Key not found"); }

            return Character;
        }
    }
}