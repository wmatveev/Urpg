using UnityEngine;
using UnityEngine.AI;

namespace CharacterControl
{
    public class GetPath : IPath
    {
        private RaycastHit hit;
        private Camera _camera;


        public GetPath(Camera camera)
        {
            _camera = camera;
        }
        
        public Vector3 GetNextPosition()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

            Physics.Raycast(ray, out hit);

            // GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //
            // sphere.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            // sphere.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
            // sphere.GetComponent<Renderer>().material.color = new Color(255,0,255);

            return hit.point;
        }

        public float CalculatePathLength(NavMeshAgent agent, Vector3 nextPosition)
        {
            float lengthSoFar = 0.0F;
            NavMeshPath path = new NavMeshPath();

            agent.CalculatePath(nextPosition, path);

            for (int i = 0; i < path.corners.Length - 1; i++)
            {
                lengthSoFar += Vector3.Distance(path.corners[i], path.corners[i + 1]);

                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            }

            return lengthSoFar;
        }
    }
}