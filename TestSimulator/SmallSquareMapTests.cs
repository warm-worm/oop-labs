using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        int size = 10;
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(0, 0, 10, true)]
    [InlineData(9, 9, 10, true)]
    [InlineData(10, 10, 10, false)] // poza zakresem (0-9)
    [InlineData(-1, 0, 10, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var p = new Point(x, y);
        Assert.Equal(expected, map.Exist(p));
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 5, 6)]     // srodek - ruch
    [InlineData(0, 9, Direction.Up, 0, 9)]     // sciana gora - stoi
    [InlineData(9, 5, Direction.Right, 9, 5)]  // sciana prawo - stoi
    public void Next_ShouldHandleWallsCheck(int x, int y, Direction dir, int expectX, int expectY)
    {
        var map = new SmallSquareMap(10);
        var p = new Point(x, y);
        var next = map.Next(p, dir);
        Assert.Equal(new Point(expectX, expectY), next);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 6, 6)]     // srodek - ruch po skosie
    [InlineData(9, 9, Direction.Up, 9, 9)]     // rog - stoi
    public void NextDiagonal_ShouldHandleWallsCheck(int x, int y, Direction dir, int expectX, int expectY)
    {
        var map = new SmallSquareMap(10);
        var p = new Point(x, y);
        var next = map.NextDiagonal(p, dir);
        Assert.Equal(new Point(expectX, expectY), next);
    }
}