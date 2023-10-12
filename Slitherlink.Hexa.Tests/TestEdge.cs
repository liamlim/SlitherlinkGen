namespace Slitherlink.Hexa.Tests;

public class TestEdge
{
    private readonly Guid _id;

    public TestEdge()
    {
        _id = Guid.NewGuid();
    }

    public override string ToString()
    {
        return _id.ToString();
    }
}
