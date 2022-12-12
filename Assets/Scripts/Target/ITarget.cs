using Unit;

namespace Target
{
    public interface ITarget
    {
        string Id { get; }

        IHealthStatus Health { get; }
    }
}