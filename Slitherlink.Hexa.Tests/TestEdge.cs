namespace Slitherlink.Hexa.Tests;

public class TestEdge
{
    private static int _ctorCount = 0;

    public TestEdge()
    {
        Id = _ctorCount++;
    }

    public int Id { get; }

    public override string ToString()
    {
        return $"E{Id}";
    }
}
