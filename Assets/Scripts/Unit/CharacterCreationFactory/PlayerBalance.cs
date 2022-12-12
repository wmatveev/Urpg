using System.Collections.Generic;
using Weapons;

namespace Character.CharacterCreationFactory
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

    public struct WeaponData
    {
        public TypesOfWeapons Type;
        public int CountCartridges;
        public int Range;
        public int ShotDamage;
    }

    public struct InventoryData
    {
        public int GunBullets;
    }

    public class Balance
    {
        public Dictionary<string, PlayerBalance> PlayerBalance;
        public Dictionary<string, EnemyBalance>  EnemyBalance;
        public Dictionary<string, WeaponData>    Weapons;
        public Dictionary<string, InventoryData> Inventory;
    }
}