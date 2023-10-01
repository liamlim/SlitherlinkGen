namespace Slitherlink.Hexa;

public sealed record Cell<TCell, TEdge>
    where TCell : new()
    where TEdge : new()
{
    public required TCell Info { get; init; }

    public required int RowIndex { get; init; }
    public required int ColumnIndex { get; init; }

    public required Edge<TCell, TEdge> TopLeftEdge { get; init; }
    public Cell<TCell, TEdge>? TopLeft
    {
        get => TopLeftEdge.CellOnLeftSide;
    }

    public required Edge<TCell, TEdge> TopRightEdge { get; init; }
    public Cell<TCell, TEdge>? TopRight
    {
        get => TopRightEdge.CellOnRightSide;
    }

    public required Edge<TCell, TEdge> BottomLeftEdge { get; init; }
    public Cell<TCell, TEdge>? BottomLeft
    {
        get => BottomLeftEdge.CellOnLeftSide;
    }

    public required Edge<TCell, TEdge> BottomRightEdge { get; init; }
    public Cell<TCell, TEdge>? BottomRight
    {
        get => BottomRightEdge.CellOnRightSide;
    }

    public required Edge<TCell, TEdge> LeftEdge { get; init; }
    public Cell<TCell, TEdge>? Left
    {
        get => LeftEdge.CellOnLeftSide;
    }

    public required Edge<TCell, TEdge> RightEdge { get; init; }
    public Cell<TCell, TEdge>? Right
    {
        get => RightEdge.CellOnRightSide;
    }
}
