using UnityEngine;
using UnityEngine.AI;

namespace CharacterControl
{
    public interface IPath
    {
        Vector3 GetNextPosition();

        float CalculatePathLength(NavMeshAgent agent, Vector3 nextPosition);
    }
}