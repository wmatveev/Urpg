
using Rpg.Target;

namespace Rpg.Attack
{
    public interface IAttack
    {
        ITarget Target { get; }

        void CharacterAttack(Character attackable, Character attacked);
    }
}