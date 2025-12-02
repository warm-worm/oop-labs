using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 0, 10, 5)]   // w zakresie
    [InlineData(-5, 0, 10, 0)]  // za mala -> min
    [InlineData(15, 0, 10, 10)] // za duza -> max
    public void Limiter_ShouldClampValues(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("shrek", 3, 5, '#', "Shrek")]             // poprawne, zmiana pierwszej litery
    [InlineData("   shrek   ", 3, 5, '#', "Shrek")]       // trim
    [InlineData("shrek is love", 3, 5, '#', "Shrek")]     // przycinanie (max 5)
    [InlineData("a", 3, 5, '#', "A##")]                   // uzupelnianie (min 3)
    [InlineData("", 3, 5, '#', "###")]                    // pusty string
    [InlineData(null, 3, 5, '#', "###")]                  // null
    public void Shortener_ShouldNormalizeString(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }
}
