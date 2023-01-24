namespace GameGrid
{
    public interface IGridOnFloor
    {
        float CellSize { get; }

        void DrawGrid();
    }
}