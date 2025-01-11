using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize()
    {
        // Arrange
        int sizeX = 10;
        int sizeY = 10;

        // Act
        var map = new SmallSquareMap(sizeX, sizeY);

        // Assert
        Assert.Equal(sizeX, map.SizeX);
        Assert.Equal(sizeY, map.SizeY);
    }

    [Theory]
    [InlineData(10, 15)]
    [InlineData(15, 10)]
    public void Constructor_NonSquareSize_ShouldThrowException(int sizeX, int sizeY)
    {
        // Act & Assert
        Assert.Throws<Exception>(() => new SmallSquareMap(sizeX, sizeY));
    }

    [Theory]
    [InlineData(4, 4)]
    [InlineData(21, 21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int sizeX, int sizeY)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(sizeX, sizeY));
    }

    [Theory]
    [InlineData(3, 4, 5, 5, true)]
    [InlineData(6, 1, 5, 5, false)]
    [InlineData(19, 19, 20, 20, true)]
    [InlineData(20, 20, 20, 20, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int sizeX, int sizeY, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(sizeX, sizeY);
        var point = new Point(x, y);

        // Act
        var result = map.Exist(point);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(0, 8, Direction.Right, 1, 8)]
    [InlineData(19, 19, Direction.Down, 19, 18)]
    [InlineData(19, 19, Direction.Right, 19, 19)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20, 20);
        var point = new Point(x, y);

        // Act
        var nextPoint = map.Next(point, direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 8, Direction.Left, 0, 8)]
    [InlineData(18, 18, Direction.Up, 19, 19)]
    [InlineData(19, 19, Direction.Right, 19, 19)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20, 20);
        var point = new Point(x, y);

        // Act
        var nextPoint = map.NextDiagonal(point, direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
