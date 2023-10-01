namespace Slitherlink.Hexa;

/// <summary>
/// Edge between two hexagonal cells OR between a hexagonal cell and void in case if the edge lays on the border
/// of the world.
/// </summary>
public sealed record Edge<TCell, TEdge>
    where TCell : new()
    where TEdge : new()
{
    /// <summary>
    /// All custom information attached to the edge
    /// </summary>
    public required TEdge Info { get; init; }

    /// <summary>
    /// The bordering cell which is more western. It can be null if the edge lays on the westernmost side of the world.
    /// </summary>
    public Cell<TCell, TEdge>? CellOnWest { get; internal set; }

    /// <summary>
    /// The bordering cell which is more eastern. It can be null if the edge lays on the eaternmost side of the world.
    /// </summary>
    public Cell<TCell, TEdge>? CellOnEast { get; internal set; }
}