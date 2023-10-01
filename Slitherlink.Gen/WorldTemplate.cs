using Slitherlink.Hexa;

namespace Slitherlink.Gen;

public sealed class WorldTemplate : World<CellInfo, EdgeInfo>
{
    public WorldTemplate(Setup setup) 
        : base(setup.WorldSize)
    { }

    private static void FixCellInfoAfterColorChange(Cell<CellInfo, EdgeInfo>? cell)
    {
        static int BoolToInt(bool value)
        {
            return value ? 1 : 0;
        }

        // check if there is anything to fix
        if (cell == null)
        {
            return;
        }

        cell.Info.LoopEdgesCount =
            BoolToInt(cell.SouthWestEdge.Info.IsOnLoop) +
            BoolToInt(cell.SouthEastEdge.Info.IsOnLoop) +
            BoolToInt(cell.NorthWestEdge.Info.IsOnLoop) +
            BoolToInt(cell.NorthEastEdge.Info.IsOnLoop) +
            BoolToInt(cell.WestEdge.Info.IsOnLoop) +
            BoolToInt(cell.WestEdge.Info.IsOnLoop);
    }

    private static void SetColor(Cell<CellInfo, EdgeInfo> cell, CellColor color)
    {
        // check if we need to do anything
        if (cell.Info.Color == color)
        {
            return;
        }

        cell.Info.Color = color;

        cell.SouthWestEdge.Info.IsOnLoop = !cell.SouthWestEdge.Info.IsOnLoop;
        cell.SouthEastEdge.Info.IsOnLoop = !cell.SouthEastEdge.Info.IsOnLoop;
        cell.NorthWestEdge.Info.IsOnLoop = !cell.NorthWestEdge.Info.IsOnLoop;
        cell.SouthWestEdge.Info.IsOnLoop = !cell.SouthWestEdge.Info.IsOnLoop;
        cell.WestEdge.Info.IsOnLoop = !cell.WestEdge.Info.IsOnLoop;
        cell.WestEdge.Info.IsOnLoop = !cell.WestEdge.Info.IsOnLoop;

        FixCellInfoAfterColorChange(cell.GetCell(Direction.SouthWest));
        FixCellInfoAfterColorChange(cell.GetCell(Direction.SouthEast));
        FixCellInfoAfterColorChange(cell.GetCell(Direction.NorthWest));
        FixCellInfoAfterColorChange(cell.GetCell(Direction.NorthEast));
        FixCellInfoAfterColorChange(cell.GetCell(Direction.West));
        FixCellInfoAfterColorChange(cell.GetCell(Direction.East));
    }

    public void SetColor(int rowIndex, int columnIndex, CellColor color)
    {
        var cell = GetCell(rowIndex, columnIndex);

        SetColor(cell, color);
    }

    public void InverseColor(int rowIndex, int columnIndex)
    {
        var cell = GetCell(rowIndex, columnIndex);

        SetColor(cell, cell.Info.Color.Inverse());
    }
}
