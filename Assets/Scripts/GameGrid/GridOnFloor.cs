using UnityEngine;

namespace GameGrid
{
    public class GridOnFloor : IGridOnFloor
    {
        public float CellSize { get; private set; }

        private Material _material;
        private Terrain  _terrain;
        
        private int _countLinesX;
        private int _countLinesZ;

        public GridOnFloor(float cellSize, Material material, Terrain terrain)
        {
            CellSize = cellSize;

            _material = material;
            _terrain  = terrain;

            _countLinesX = (int)(terrain.terrainData.size.x / cellSize);
            _countLinesZ = (int)(terrain.terrainData.size.z / cellSize);
        }

        public void DrawGrid()
        {
            Vector3 current = Vector3.zero;
            Vector3 target  = Vector3.zero;

            float delta = 0.0f;

            GL.Begin(GL.LINES);
            _material.SetPass(0);
            GL.Color(Color.black);

            // Рисуем линии по оси Z
            for(float i=0; i<=_countLinesX; i++)
            {
                current = new Vector3(delta, 0, 0);
                target  = new Vector3(delta, 0, _terrain.terrainData.size.z);

                GL.Vertex(current);
                GL.Vertex(target);

                delta += CellSize;
            }

            delta = 0.0f;

            // Рисуем линии по оси X
            for(float i=0; i<=_countLinesZ; i++)
            {
                current = new Vector3(0, 0, delta);
                target  = new Vector3(_terrain.terrainData.size.x, 0, delta);

                GL.Vertex(current);
                GL.Vertex(target);

                delta += CellSize;
            }

            GL.End();
        }
    }
}