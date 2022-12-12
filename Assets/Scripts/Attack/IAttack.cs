
using Target;
using Unit;

namespace Attack
{
    public interface IAttack
    {
        ITarget Target { get; }

        void CharacterAttack(Character attackable, Character attacked);
    }
}