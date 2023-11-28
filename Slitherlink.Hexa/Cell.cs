using Slitherlink.Core;

namespace Slitherlink.Hexa;

/// <summary>
/// Hexagonal cell with properties which allow it to border with neighbour cells in exactly 6 directions (NW, NE, E, SE, SW, W).
/// </summary>
public sealed record Cell<TCell, TEdge> : IHexaCell
    where TCell : notnull, new()
    where TEdge : notnull, new()
{
    /// <summary>
    /// All custom information attached to the cell
    /// </summary>
    public required TCell Info { get; init; }

    public override string ToString()
    {
        return Info.ToString() ?? "";
    }

    public required IHexaEdge NorthWestEdge { get; init; }
    public required IHexaEdge NorthEastEdge { get; init; }
    public required IHexaEdge SouthWestEdge { get; init; }
    public required IHexaEdge SouthEastEdge { get; init; }
    public required IHexaEdge WestEdge { get; init; }
    public required IHexaEdge EastEdge { get; init; }
}
