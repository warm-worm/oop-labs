using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Theory]
    [InlineData(10, 10, Direction.Up, 10, 11)]
    [InlineData(10, 10, Direction.Right, 11, 10)]
    [InlineData(10, 10, Direction.Down, 10, 9)]
    [InlineData(10, 10, Direction.Left, 9, 10)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction dir, int expectX, int expectY)
    {
        var p = new Point(x, y);
        var next = p.Next(dir);
        Assert.Equal(new Point(expectX, expectY), next);
    }

    [Theory]
    [InlineData(10, 10, Direction.Up, 11, 11)]     // up -> up-right
    [InlineData(10, 10, Direction.Right, 11, 9)]   // right -> down-right
    [InlineData(10, 10, Direction.Down, 9, 9)]     // down -> down-left
    [InlineData(10, 10, Direction.Left, 9, 11)]    // left -> up-left
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction dir, int expectX, int expectY)
    {
        var p = new Point(x, y);
        var next = p.NextDiagonal(dir);
        Assert.Equal(new Point(expectX, expectY), next);
    }
}