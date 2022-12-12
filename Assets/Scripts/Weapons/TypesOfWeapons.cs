namespace Weapons
{
    public struct WeaponsAndOptions
    {
        public int TypeOfWeapon;
        public int WeaponDamage;
        public int AmountOfCartiridges;
        // public Dictionary<int, TypeOfCartridges> AcceptableCartridges;
    }

    public struct TypeOfCartridges
    {
        public int None;
        public int Lead;
        public int Fire;
        public int Explosive;
        public int Shot;
        public int Tranquilizer;
    }

    public struct IDWeapon
    {
        public const int Gun            = 1;
        public const int Rifle          = 2;
        public const int AutomaticRifle = 3;
        public const int Shotgun        = 4;
        public const int Knife          = 5;
    }

    public enum TypesOfWeapons : int
    {
        /// Винтовка
        Rifle = 1,
        
        /// Пистолет
        Gun = 2,
        
        /// Атомат
        AutomaticRifle = 3,
        
        /// Нож
        Knife = 4,
        
        /// Дробовик
        Shotgun = 5
    }
    
    public enum TypesOfCartridges : int
    {
        None = 0,
        /// Свинцовые патроны
        Lead = 1,
        
        /// Возгорающиеся патроны
        Fire = 2,
        
        /// Разрывные патроны
        Explosive = 3,
        
        /// Дробь
        Shot = 4,
        
        /// Транквилизатор
        Tranquilizer = 5
    }
}