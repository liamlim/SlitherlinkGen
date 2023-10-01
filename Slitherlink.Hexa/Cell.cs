namespace Slitherlink.Hexa;

public sealed record Cell<TCell, TEdge>
    where TCell : new()
    where TEdge : new()
{
    public required TCell Info { get; init; }

    public required int RowIndex { get; init; }
    public required int ColumnIndex { get; init; }

    private IEnumerable<Cell<TCell, TEdge>?> GetAllNeighboursInternal()
    {
        yield return NorthWest;
        yield return NorthEast;
        yield return SouthWest;
        yield return SouthEast;
        yield return West;
        yield return East;
    }

    public IEnumerable<Edge<TCell, TEdge>> GetAllEdges()
    {
        yield return NorthWestEdge;
        yield return NorthEastEdge;
        yield return SouthWestEdge;
        yield return SouthEastEdge;
        yield return EastEdge;
        yield return WestEdge;
    }

    public IEnumerable<Cell<TCell, TEdge>> GetAllNeighbourCells()
    {

        return GetAllNeighboursInternal().Where(x => x != null)!;
    }

    public required Edge<TCell, TEdge> NorthWestEdge { get; init; }
    public Cell<TCell, TEdge>? NorthWest
    {
        get => NorthWestEdge.CellOnLeftSide;
    }

    public required Edge<TCell, TEdge> NorthEastEdge { get; init; }
    public Cell<TCell, TEdge>? NorthEast
    {
        get => NorthEastEdge.CellOnRightSide;
    }

    public required Edge<TCell, TEdge> SouthWestEdge { get; init; }
    public Cell<TCell, TEdge>? SouthWest
    {
        get => SouthWestEdge.CellOnLeftSide;
    }

    public required Edge<TCell, TEdge> SouthEastEdge { get; init; }
    public Cell<TCell, TEdge>? SouthEast
    {
        get => SouthEastEdge.CellOnRightSide;
    }

    public required Edge<TCell, TEdge> WestEdge { get; init; }
    public Cell<TCell, TEdge>? West
    {
        get => WestEdge.CellOnLeftSide;
    }

    public required Edge<TCell, TEdge> EastEdge { get; init; }
    public Cell<TCell, TEdge>? East
    {
        get => EastEdge.CellOnRightSide;
    }

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

    public Cell<TCell, TEdge>? GetCell(Direction direction)
    {
        return direction switch
        {
            Direction.East => East,
            Direction.West => West,
            Direction.NorthEast => NorthEast,
            Direction.NorthWest => NorthWest,
            Direction.SouthEast => SouthEast,
            Direction.SouthWest => SouthWest,

            _ => throw new NotSupportedException()
        };
    }
}
