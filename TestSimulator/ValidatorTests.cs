using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    // limiter bez zmian
    [Theory]
    [InlineData(5, 0, 10, 5)]   // w zakresie
    [InlineData(-5, 0, 10, 0)]  // za mala -> min
    [InlineData(15, 0, 10, 10)] // za duza -> max
    public void Limiter_ShouldClampValues(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }

    // --- rozbite testy dla shortenera ---

    [Theory]
    [InlineData("shrek", "Shrek")]    // mala litera -> duza
    [InlineData("Shrek", "Shrek")]    // duza zostaje duza
    public void Shortener_ShouldCorrectCase(string value, string expected)
    {
        var result = Validator.Shortener(value, 3, 5, '#');
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("   shrek   ", "Shrek")] // spacje z bokow
    [InlineData("\tshrek\n", "Shrek")]   // inne biale znaki
    public void Shortener_ShouldTrimSpaces(string value, string expected)
    {
        var result = Validator.Shortener(value, 3, 10, '#');
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("a", "A##")]      // 1 znak -> 3 znaki
    [InlineData("ab", "Ab#")]     // 2 znaki -> 3 znaki
    public void Shortener_ShouldPadToMinLength(string value, string expected)
    {
        var result = Validator.Shortener(value, 3, 5, '#');
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Shortener_ShouldCapToMaxLength() // przycinanie dlugich
    {
        string input = "VeryLongStringThatNeedsCutting";
        // oczekujemy VeryL (5 znakow)
        var result = Validator.Shortener(input, 3, 5, '#');
        Assert.Equal("VeryL", result);
    }

    [Fact]
    public void Shortener_ShouldHandleComplexCase_TrollName() // ten dziwny przypadek z troll name
    {
        string input = "a                            troll name";
        string expected = "A##";

        var result = Validator.Shortener(input, 3, 25, '#');

        Assert.Equal(expected, result);
    }
}