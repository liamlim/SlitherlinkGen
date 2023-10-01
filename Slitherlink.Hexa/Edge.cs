namespace Slitherlink.Hexa;

public sealed record Edge<TCell, TEdge>
    where TCell : new()
    where TEdge : new()
{
    public required TEdge Info { get; init; }

    public Cell<TCell, TEdge>? CellOnWest { get; internal set; }
    public Cell<TCell, TEdge>? CellOnEast { get; internal set; }
}