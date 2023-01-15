using UnityEngine;
using UnityEngine.AI;

namespace CharacterControl
{
    public class GetPath : IPath
    {
        private Camera _camera;

        public NavMeshPath generalPath { get; }
        public NavMeshPath allowedPath { get; private set; }
        public NavMeshPath forbiddenPath { get; private set; }

        public GetPath(Camera camera)
        {
            _camera = camera;

            generalPath   = new NavMeshPath();
            allowedPath   = new NavMeshPath();
            forbiddenPath = new NavMeshPath();
        }

        public Vector3 GetNextPosition()
        {
            RaycastHit hit;
    
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            return hit.point;
        }

        public void CalculatePath(NavMeshAgent agent, float maxDistance)
        {
            Vector3 generalPosition = GetNextPosition();

            // Вычисляем общий путь до конечной позиции
            agent.CalculatePath(generalPosition, generalPath);

            // Если длинна общего пути меньше максимальной дистанции, то разрешенный путь приравниваем к общему
            if (CalculatePathLength() < maxDistance)
            {
                allowedPath = generalPath;

                // Отчищаем forbiddenPath
                forbiddenPath.ClearCorners();
                return ;
            }

            // Если задана максимальная дистанция, то 
            if (maxDistance != 0)
            {
                // Вычисляем координаты максимальной возможной точки для передвижения 
                Vector3 allowedLastCoordinate = MaxAllowedDistanceCoordinate(maxDistance);

                agent.CalculatePath(allowedLastCoordinate, allowedPath);
                
                // Вычисляем путь от разрешенной точки до конечной
                NavMesh.CalculatePath(allowedLastCoordinate, generalPosition, 
                    NavMesh.AllAreas, forbiddenPath);
            }
        }

        public float CalculatePathLength()
        {
            float lengthSoFar = 0.0f;

            for (int i = 0; i < generalPath.corners.Length - 1; i++)
            {
                lengthSoFar += Vector3.Distance(generalPath.corners[i], generalPath.corners[i + 1]);
            }

            return lengthSoFar;
        }
        
        // Вычисляем координату с максимально разренной дистанцией
        public Vector3 MaxAllowedDistanceCoordinate(float maxDistance)
        {
            float lenghtCurrentRib = 0.0f;
            float lengthSoFar      = 0.0f;
            float tempMaxDistance  = maxDistance;

            for (int i = 0; i < generalPath.corners.Length - 1; i++)
            {
                // Определяем, на каком ребре находится точка максимальной дистанции
                lenghtCurrentRib = Vector3.Distance(generalPath.corners[i], generalPath.corners[i + 1]);
                
                lengthSoFar += lenghtCurrentRib;

                if (lengthSoFar >= maxDistance)
                {
                    // Находим координаты вектора до какой точки разрешено ходить игроку
                    return Vector3.MoveTowards(generalPath.corners[i], generalPath.corners[i + 1], tempMaxDistance);
                }

                tempMaxDistance -= lenghtCurrentRib;
            }

            return Vector3.zero;
        }

        public void DrawPath(NavMeshPath argPath, Material material, Color color)
        {
            Vector3 current = Vector3.zero;
            Vector3 target  = Vector3.zero;

            GL.Begin(GL.LINES);
            material.SetPass(0);
            GL.Color(color);

            for (int i = 0; i < argPath.corners.Length-1; i++)
            {
                current = argPath.corners[i];
                target  = argPath.corners[i+1];

                GL.Vertex(current);
                GL.Vertex(target);
            }

            GL.End();
        }

        public void DrawTestPath(Material material, Color color)
        {
            Vector3 current = Vector3.zero;
            Vector3 target  = Vector3.zero;

            GL.Begin(GL.LINES);
            material.SetPass(0);
            GL.Color(color);

            current = new Vector3(1f,1f,1f);
            target  = new Vector3(8.86f,1,1.43f);

            GL.Vertex(current);
            GL.Vertex(target);

            GL.End();
        }
    }
}