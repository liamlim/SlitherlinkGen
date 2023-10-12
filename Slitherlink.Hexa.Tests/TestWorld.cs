namespace Slitherlink.Hexa.Tests;

public class TestWorld :
    World<TestCell, TestEdge>
{
    public TestWorld(int worldSize) 
        : base(worldSize)
    {
    }
}
