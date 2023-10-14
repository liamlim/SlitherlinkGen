namespace Slitherlink.Hexa.Tests;

public class WorldCoreTests
{
    [Theory()]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Can_Create_World(int worldSize)
    {
        var world = new TestWorld(worldSize);

        Assert.Equal(worldSize, world.WorldSize);
        Assert.Equal(2 * worldSize - 1, world.TotalRowsCount);
    }

    [Theory()]
    [InlineData(0)]
    [InlineData(-1)]
    public void Fail_Create_World_With_Negative_Size(int worldSize)
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            return new TestWorld(worldSize);
        });
    }
}