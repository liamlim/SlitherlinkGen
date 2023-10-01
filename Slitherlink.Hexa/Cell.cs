namespace Slitherlink.Hexa;

/// <summary>
/// Hexagonal cell with properties which allow it to border with neighbour cells in exactly 6 directions (NW, NE, E, SE, SW, W).
/// </summary>
public sealed record Cell<TCell, TEdge>
    where TCell : new()
    where TEdge : new()
{
    /// <summary>
    /// All custom information attached to the cell
    /// </summary>
    public required TCell Info { get; init; }

    /// <summary>
    /// Returns all edges in order NW -> NE -> E -> SE -> SW -> W
    /// </summary>
    public IEnumerable<Edge<TCell, TEdge>> GetAllEdges()
    {
        yield return NorthWestEdge;
        yield return NorthEastEdge;
        yield return EastEdge;
        yield return SouthEastEdge;
        yield return SouthWestEdge;
        yield return WestEdge;
    }

    /// <summary>
    /// Edge in NW direction (upper left)
    /// </summary>
    public required Edge<TCell, TEdge> NorthWestEdge { get; init; }

    /// <summary>
    /// Edge in NE direction (upper right)
    /// </summary>
    public required Edge<TCell, TEdge> NorthEastEdge { get; init; }

    /// <summary>
    /// Edge in SW direction (lower left)
    /// </summary>
    public required Edge<TCell, TEdge> SouthWestEdge { get; init; }

    /// <summary>
    /// Edge in SE direction (lower right)
    /// </summary>
    public required Edge<TCell, TEdge> SouthEastEdge { get; init; }

    /// <summary>
    /// Edge in W direction (left)
    /// </summary>
    public required Edge<TCell, TEdge> WestEdge { get; init; }

    /// <summary>
    /// Edge in E direction (right)
    /// </summary>
    public required Edge<TCell, TEdge> EastEdge { get; init; }

    /// <summary>
    /// Gets the edge in the specified direction
    /// </summary>
    public Edge<TCell, TEdge> GetEdge(Direction direction)
    {
        return direction switch
        {
            Direction.East => EastEdge,
            Direction.West => WestEdge,
            Direction.NorthEast => NorthEastEdge,
            Direction.NorthWest => NorthWestEdge,
            Direction.SouthEast => SouthEastEdge,
            Direction.SouthWest => SouthWestEdge,

            _ => throw new NotSupportedException()
        };
    }

    /// <summary>
    /// Gets the neighbouring cell in the specified direction
    /// </summary>
    public Cell<TCell, TEdge>? GetCell(Direction direction)
    {
        return direction switch
        {
            Direction.East => EastEdge.CellOnEast,
            Direction.West => WestEdge.CellOnWest,
            Direction.NorthEast => NorthEastEdge.CellOnEast,
            Direction.NorthWest => NorthWestEdge.CellOnWest,
            Direction.SouthEast => SouthEastEdge.CellOnEast,
            Direction.SouthWest => SouthWestEdge.CellOnWest,

            _ => throw new NotSupportedException()
        };
    }
}
