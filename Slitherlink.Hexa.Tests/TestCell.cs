namespace Slitherlink.Hexa.Tests;

public class TestCell
{
    private static int _ctorCount = 0;

    public TestCell()
    {
        Id = _ctorCount++;
    }

    public int Id { get; }

    public override string ToString()
    {
        return $"C{Id}";
    }
}
