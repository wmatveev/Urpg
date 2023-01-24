using UnityEngine;
using UnityEngine.AI;

namespace CharacterControl
{
    public interface IPath
    {
        NavMeshPath generalPath { get; }    // Общий путь
        NavMeshPath allowedPath { get; }    // Разрешенный путь
        NavMeshPath forbiddenPath { get; }  // Запрещенный путь

        
        Vector3 GetNextPosition();

        void CalculatePath(NavMeshAgent agent, float maxDistance = 0);
        float CalculatePathLength();
        Vector3 MaxAllowedDistanceCoordinate(float maxDistance);

        void DrawPath(NavMeshPath path, Material material, Color color);
    }
}