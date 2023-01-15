using System;
using System.Collections;
using System.Collections.Generic;
using CharacterControl;
using UnityEngine;
using UnityEngine.AI;

public class PostRenerTest : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _mainHeroAgent;
    [SerializeField] private Material     _material;
    [SerializeField] private Camera       _camera;
    [SerializeField] private float        _maxDistance;

    private IPath _path;
    
    // Start is called before the first frame update
    void Start()
    {
        _path = new GetPath(_camera);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Передвигаем персонажа на разрешенное расстояние
            _mainHeroAgent.SetDestination(_path.allowedPath.corners[_path.allowedPath.corners.Length-1]);
        }
    }

    private void DrawLineOfPlannedPath()
    {
        // Debug.Log($"Позиция игрока: {_mainHeroAgent.transform.position}");

        // Вычисляем предполагаемый путь с учетом максимальной дистанции
        _path.CalculatePath(_mainHeroAgent, _maxDistance);
        
        // Отрисовываем разрешенный путь
        _path.DrawPath(_path.allowedPath, _material, Color.green);

        // Отрисовываем запрещенный путь
        _path.DrawPath(_path.forbiddenPath, _material, Color.red);
    }
    
    private void OnPostRender()
    {
        if (!_mainHeroAgent.hasPath)
            DrawLineOfPlannedPath();
    }
}
