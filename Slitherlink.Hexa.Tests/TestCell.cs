namespace Slitherlink.Hexa.Tests;

public class TestCell
{
    private readonly Guid _id;

    public TestCell()
    {
        _id = Guid.NewGuid();
    }

    public override string ToString()
    {
        return _id.ToString();
    }
}
