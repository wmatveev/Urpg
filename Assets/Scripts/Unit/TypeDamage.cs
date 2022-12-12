namespace Unit
{
    public enum TypeDamage
    {
        MagicDamage    = 1,  // Магический урон
        PhysicalDamage = 2,  // Физический урон
        FireDamage     = 3,  // Огненный урон
        LightDamage    = 4   // Урон от света
    }

    public enum DefaultStatsValue
    {
        Power            = 1,    // Сила персонажа
        Level            = 2,    // Уровень персонажа
        Energy           = 3,    // Енергия персонажа
        Agility          = 4,    // Ловкость персонажа
        Endurance        = 5,    // Выносливость персонажа
        DamageProtection = 6     // Защита от урона
    }
}