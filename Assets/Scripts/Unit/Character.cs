using System.Collections.Generic;
using Target;
using Weapons;
using Weapons.DamageCalculation;

namespace Unit
{
    public class Character : ITarget
    {
        public string Id { get; }
        public int Level;

        public Stats Stats          { get; private set; }
        public IHealthStatus Health { get; private set; }

        public IWeaponController WeaponController;

        // Создаем словарь, а не лист, потому что мы должны помимо инстанса на оружие хранить наименование (ID)
        public Dictionary<string, IWeapon> Weapons = new Dictionary<string, IWeapon>();
        // public List<IWeapon> Weapons = new List<IWeapon>();

        public Character(string id, Stats stats, IDamageCalculator damageCalculator)
        {
            Id = id;
            Stats = stats;

            // Здоровье персонажа
            Health = new CharacterHealth(stats, damageCalculator);

            // Добавляем оружие персонажу из листа полученного из баланса
            WeaponController = new WeaponController();
        }
    }
}