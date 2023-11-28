using Slitherlink.Core;

namespace Slitherlink.Hexa;

/// <summary>
/// Edge between two hexagonal cells OR between a hexagonal cell and void in case if the edge lays on the border
/// of the world.
/// </summary>
public sealed record Edge<TCell, TEdge> : IHexaEdge
    where TCell : notnull, new()
    where TEdge : notnull, new()
{
    /// <summary>
    /// All custom information attached to the edge
    /// </summary>
    public required TEdge Info { get; init; }

    public override string ToString()
    {
        return Info.ToString() ?? "";
    }

    public IHexaCell? CellOnWest { get; internal set; }
    public IHexaCell? CellOnEast { get; internal set; }
}