using RPG.Character;

namespace Rpg.Target
{
    public interface ITarget
    {
        IHealthStatus Health { get; }
    }
}