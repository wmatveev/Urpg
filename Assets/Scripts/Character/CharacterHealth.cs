using System;
using JetBrains.Annotations;
using RPG.Weapons;
using RPG.Weapons.DamageCalculation;
using UnityEngine;

namespace RPG.Character
{
    public class CharacterHealth : IHealthStatus
    {
        [CanBeNull]
        public event Action<Damage> OnHit;
        public event Action<Damage> OnDie;
        
        /// Количество повреждения
        private int _injuries;               
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
            // Суммируем количество повреждения
            _injuries += _calculator.GetDamage(damage.SourceAttack, _stats);
            
            Debug.Log($"<color=green>[{damage.Attacking.Id} attacked {damage.Target.Id}]</color> : " +
                      $"<color=red>[Damage: {_injuries}]</color>");

            if (_injuries >= MaxHealth)
            {
                Debug.Log($"<color=red>[{damage.Target.Id}] is died</color>");

                Death(damage);
            }
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