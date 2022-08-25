namespace RPG.Character
{
    public class Stats
    {
        private const int DEFAULT_STAT = 5;
        private const int DEFAULT_HP   = 100;
        
        public int Power;            // Сила персонажа
        public int Energy;           // Енергия персонажа
        public int Agility;          // Ловкость персонажа
        public int Endurance;        // Выносливость персонажа
        public int DamageProtection; // Защита от урона
        public int MaxHealth;        // Максимальное здоровье

        public static Stats Default => new Stats()
        { 
            Power            = DEFAULT_STAT,
            Energy           = DEFAULT_STAT,
            Agility          = DEFAULT_STAT,
            Endurance        = DEFAULT_STAT,
            DamageProtection = DEFAULT_STAT,
            MaxHealth        = DEFAULT_HP
        };

        public static Stats operator +(Stats a, Stats b)
        {
            return new Stats()
            {
                Power     = a.Power + b.Power,
                Energy    = a.Energy + b.Energy,
                Agility   = a.Agility + b.Agility,
                Endurance = a.Endurance + b.Endurance,
                DamageProtection = a.DamageProtection + b.DamageProtection,
            };
        }
        
        public static Stats operator -(Stats a, Stats b)
        {
            return new Stats()
            {
                Power     = a.Power - b.Power,
                Energy    = a.Energy - b.Energy,
                Agility   = a.Agility - b.Agility,
                Endurance = a.Endurance - b.Endurance,
                DamageProtection = a.DamageProtection - b.DamageProtection,
            };
        }

    }
}