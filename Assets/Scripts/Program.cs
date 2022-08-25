using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Rpg.Attack;
using Rpg.Balans;
//using Rpg.Balans;
using RPG.Character;
using RPG.Character.CharacterCreationFactory;
using RPG.Weapons;
using RPG.Weapons.DamageCalculation;
using RPG.Weapons.WeaponsFactory;

namespace Rpg
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Balance balance = new GetCharactersBalans("MyJson.json").GetBalans();

            // GetCharactersBalans b = new GetCharactersBalans("MyJson.json");
            // b.CreateJsonBalansFromExample();

            IWeaponsFactory WeaponsFactory = new WeaponsFactory(balance);
            
            ICharatersFactory MainCharacter = new CharactersFactory(balance, new DamageCalculator(), WeaponsFactory);

            Character Player  = MainCharacter.CreateCharacter("Player1");
            Character Enemy1  = MainCharacter.CreateCharacter("Enemy1");


            IAttack Attack = new Attack.Attack();
            Attack.CharacterAttack(Player, Enemy1);
        }
    }

    public class Character
    {
        public int Level;

        public Stats Stats          { get; private set; }
        public IHealthStatus Health { get; private set; }

        public IWeaponController WeaponController;

        // Создаем словарь, а не лист, потому что мы должны помимо инстанса на оружие хранить наименование (ID)
        public Dictionary<string, IWeapon> Weapons = new Dictionary<string, IWeapon>();
        // public List<IWeapon> Weapons = new List<IWeapon>();

        public Character(Stats stats, IDamageCalculator damageCalculator)
        {
            Stats = stats;

            // Здоровье персонажа
            Health = new CharacterHealth(stats, damageCalculator);

            // Добавляем оружие персонажу из листа полученного из баланса
            WeaponController = new WeaponController();
        }
    }
}
