using RPG.Character;

namespace Rpg.Target
{
    public interface ITarget
    {
        string Id { get; }

        IHealthStatus Health { get; }
    }
}