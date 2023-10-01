namespace Slitherlink.Gen;

public static class CellColorExt
{
    public static CellColor Inverse(this CellColor color)
    {
        return color switch
        {
            CellColor.In => CellColor.Out,
            CellColor.Out => CellColor.In,

            _ => throw new NotSupportedException()
        };
    }
}
