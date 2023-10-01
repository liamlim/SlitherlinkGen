namespace Slitherlink.Hexa;

public sealed record WorldDimentions
{
    public required int TopWidth { get; init; }
    public required int MiddleWidth { get; init; }
    public required int BottomWidth { get; init; }
}
