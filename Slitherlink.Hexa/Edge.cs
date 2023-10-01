namespace Slitherlink.Hexa;

public sealed record Edge<TCell, TEdge>
    where TCell : new()
    where TEdge : new()
{
    public required TEdge Info { get; init; }

    public Cell<TCell, TEdge>? CellOnLeftSide { get; internal set; }
    public Cell<TCell, TEdge>? CellOnRightSide { get; internal set; }
}