using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(15, 1, 10, 10)]
    public void Limiter_ReturnCorrectValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", 3, 10, '-', "Hello")]
    [InlineData("short", 10, 20, '*', "Short*****")]
    [InlineData("ABABABABABABABABABABABABABAB", 5, 10, ' ', "ABABABABAB")]
    [InlineData("", 5, 10, '.', "Unknown")]
    [InlineData("   tooShort   ", 10, 15, 'x', "TooShortxx")]
    public void Shortener_ReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Shortener_EmptyString()
    {
        var result = Validator.Shortener("", 5, 10, ' ');
        Assert.Equal("Unknown", result);
    }

    [Fact]
    public void Shortener_Whitespace()
    {
        var result = Validator.Shortener("     ", 5, 10, '-');
        Assert.Equal("Unknown", result);
    }
}
