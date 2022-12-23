using System.Collections;
using System.Collections.Generic;
using CharacterControl;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Camera       _camera;

    private Vector3 nextPosition;

    private IPath getPath;
    
    // Start is called before the first frame update
    void Start()
    {
        getPath = new GetPath(_camera);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 nextPosition = getPath.GetNextPosition();

            _agent.SetDestination(nextPosition);
        }
    }

}
