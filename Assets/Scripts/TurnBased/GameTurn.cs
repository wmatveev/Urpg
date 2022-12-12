using System;
using Unit;

namespace TurnBased
{
    // Игровой ход
    public class GameTurn
    {
        public Character Owner { get; }
        private readonly Action<GameTurn> _onComplete;

        public GameTurn(Character character, Action<GameTurn> onComplete)
        {
            _onComplete = onComplete;
            Owner = character;
        }

        public void Attack(Character target)
        {
            // Owner.WeaponController.CurrentWeapon.Shoot(target);
            //target.Health.DealDamage(Owner.WeaponController.CurrentWeapon);
            Owner.WeaponController.Attack(target);
            FinalizeTurn();
        }

        public void Skip()
        {
            FinalizeTurn();
        }

        // TODO: Move
        private void FinalizeTurn()
        {
            _onComplete?.Invoke(this);
        }
    }
}