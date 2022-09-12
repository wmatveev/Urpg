using RPG.Character;
using Rpg.Target;
using RPG.Weapons;

namespace Rpg.Attack
{
    public class Attack : IAttack
    {
        public ITarget Target { get; }
        
        public void CharacterAttack(Character attackable, Character attacked)
        {
            // attacked.Health.DealDamage(attackable.WeaponController.CurrentWeapon);
        }
    }
}