using System;
using JetBrains.Annotations;
using RPG.Weapons;
using RPG.Weapons.DamageCalculation;

namespace RPG.Character
{
    public class CharacterHealth : IHealthStatus
    {
        [CanBeNull]
        public event Action<Damage> OnHit;
        public event Action<Damage> OnDie;
        
        private int _injuries;               // Количество повреждения
        private readonly Stats _stats;
        private readonly IDamageCalculator _calculator;
        
        public int   MaxHealth     => _stats.MaxHealth;
        public int   CurrentHealth => _stats.MaxHealth - _injuries;
        public float HealthAmount  => (float)CurrentHealth / MaxHealth;

        public bool  IsAlive      { get; private set; }



        public CharacterHealth(Stats Stats, IDamageCalculator calculator)
        {
            _stats = Stats;
            _calculator = calculator;
        }

        /// Нанести удар
        public void DealDamage(Damage damage)
        {
            _injuries += _calculator.GetDamage(damage, _stats);
            if (_injuries > MaxHealth)
                Death(damage);
        }

        /// Нанести удар
        public void DealDamage(IWeapon attackersWeapon)
        {
            _injuries += _calculator.GetDamage(attackersWeapon, _stats);
            if (_injuries > MaxHealth)
            {
                // TODO: привести к OnDie!!!
                IsAlive = false;
                OnDie?.Invoke(new Damage());
            }
                //Death(damage);
        }

        /// Исцеляем повреждения
        public void HealDamage(int amount)
        {
            _injuries -= amount;
            if (_injuries < 0)
                _injuries = 0;
        }

        /// Смерть персонажа
        public void Death(Damage damage)
        {
            IsAlive = false;

            OnDie?.Invoke(damage);
            // if (OnDie != null)
            //     OnDie();

        }
    }
}