namespace Slitherlink.Gen;

public sealed record EdgeInfo
{
    public bool IsOnLoop { get; internal set; } = false;
}
