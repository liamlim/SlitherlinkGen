namespace Slitherlink.Core;

public interface IHexaEdge
{
    /// <summary>
    /// The bordering cell which is more western. It can be null if the edge lays on the westernmost side of the world.
    /// </summary>
    public IHexaCell? CellOnWest { get; }

    /// <summary>
    /// The bordering cell which is more eastern. It can be null if the edge lays on the eaternmost side of the world.
    /// </summary>
    public IHexaCell? CellOnEast { get; }
}
