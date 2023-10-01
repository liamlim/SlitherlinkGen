namespace Slitherlink.Gen;

public sealed record CellInfo
{
    public int LoopEdgesCount { get; internal set; } = 0;

    public CellColor Color { get; internal set; } = CellColor.Out;
}
