using System.Collections.Generic;
using RPG.Weapons;

namespace RPG.Character.CharacterCreationFactory
{
    public class PlayerBalance
    {
        public Stats Stats;
        public List<string> AvailableWeapons;
    }

    // + тип поведения
    public class EnemyBalance
    {
        public Stats Stats;
        public List<string> AvailableWeapons;
    }

    public class Balance
    {
        public Dictionary<string, PlayerBalance> PlayerBalance;
        public Dictionary<string, EnemyBalance>  EnemyBalance;
        public Dictionary<string, WeaponData> Weapons;
    }
}