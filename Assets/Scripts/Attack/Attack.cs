using Target;
using Unit;

namespace Attack
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