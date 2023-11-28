namespace Slitherlink.Core;

public interface IHexaCell
{
    /// <summary>
    /// Returns all edges in order NW -> NE -> E -> SE -> SW -> W
    /// </summary>
    public IEnumerable<IHexaEdge> GetAllEdges()
    {
        yield return NorthWestEdge;
        yield return NorthEastEdge;
        yield return EastEdge;
        yield return SouthEastEdge;
        yield return SouthWestEdge;
        yield return WestEdge;
    }

    /// <summary>
    /// Gets the edge in the specified direction
    /// </summary>
    public IHexaEdge GetEdge(Direction direction)
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
    public IHexaCell? GetCell(Direction direction)
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

    /// <summary>
    /// Edge in NW direction (upper left)
    /// </summary>
    public IHexaEdge NorthWestEdge { get; }

    /// <summary>
    /// Edge in NE direction (upper right)
    /// </summary>
    public IHexaEdge NorthEastEdge { get; }

    /// <summary>
    /// Edge in SW direction (lower left)
    /// </summary>
    public IHexaEdge SouthWestEdge { get; }

    /// <summary>
    /// Edge in SE direction (lower right)
    /// </summary>
    public IHexaEdge SouthEastEdge { get; }

    /// <summary>
    /// Edge in W direction (left)
    /// </summary>
    public IHexaEdge WestEdge { get; }

    /// <summary>
    /// Edge in E direction (right)
    /// </summary>
    public IHexaEdge EastEdge { get; }
}
