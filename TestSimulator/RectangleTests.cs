using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldThrowException_ForThinRectangle()
    {
        // X1 == X2 -> ArgumentException
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 0, 5));
    }

    [Fact]
    public void Constructor_ShouldSwapCoordinates()
    {
        // odwrotnie: 10, 10 (start) i 0, 0 (koniec)
        var rect = new Rectangle(10, 10, 0, 0);

        // ma zamienic na (0,0):(10,10)
        Assert.Equal(0, rect.X1);
        Assert.Equal(0, rect.Y1);
        Assert.Equal(10, rect.X2);
        Assert.Equal(10, rect.Y2);
    }

    [Theory]
    [InlineData(5, 5, true)]   // srodek
    [InlineData(0, 0, true)]   // krawedz
    [InlineData(10, 10, true)] // krawedz
    [InlineData(-1, 5, false)] // poza
    [InlineData(5, 11, false)] // poza
    public void Contains_ShouldReturnCorrectResult(int x, int y, bool expected)
    {
        var rect = new Rectangle(0, 0, 10, 10);
        var p = new Point(x, y);
        var result = rect.Contains(p);
        Assert.Equal(expected, result);
    }
}