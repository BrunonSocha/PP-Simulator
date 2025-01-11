using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Theory]
    [InlineData(0, 0, 5, 5, 0, 0, 5, 5)]
    [InlineData(5, 5, 0, 0, 0, 0, 5, 5)]
    [InlineData(3, 1, 1, 3, 1, 1, 3, 3)]
    public void Constructor_CorrectCoordinates(int x1, int y1, int x2, int y2, int expectedX1, int expectedY1, int expectedX2, int expectedY2)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(expectedX1, rectangle.X1);
        Assert.Equal(expectedY1, rectangle.Y1);
        Assert.Equal(expectedX2, rectangle.X2);
        Assert.Equal(expectedY2, rectangle.Y2);
    }

    [Theory]
    [InlineData(0, 0, 0, 5)]
    [InlineData(5, 5, 5, 5)]
    [InlineData(3, 3, 3, 3)]
    public void Constructor_InvalidRectangle(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Theory]
    [InlineData(0, 0, 5, 5, 3, 3, true)]
    [InlineData(0, 0, 5, 5, 5, 5, true)]   
    [InlineData(0, 0, 5, 5, 0, 0, true)] 
    [InlineData(1, 1, 4, 4, 0, 0, false)]
    public void Contains_ReturnCorrectValue(int x1, int y1, int x2, int y2, int px, int py, bool expected)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);
        Assert.Equal(expected, rectangle.Contains(point));
    }


    [Fact]
    public void ToString_ReturnCorrectString()
    {
        var rectangle = new Rectangle(0, 0, 5, 5);
        Assert.Equal("(0, 0):(5, 5)", rectangle.ToString());
    }
}
