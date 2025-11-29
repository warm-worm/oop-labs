using Simulator;

namespace TestSimulator;

public class DirectionParserTests
{
    [Fact] //sprawdzanie pojedynczego faktu
    public void Parse_ShouldParseDirectionsCorrectly() // czy w ogole dziala
    {
        // Arrange
        string input = "URDL";
        // Act
        var result = DirectionParser.Parse(input);
        // Assert
        Assert.Equal([Direction.Up, Direction.Right,
            Direction.Down, Direction.Left],
            result
        );
    }

    [Fact]
    public void Parse_ShouldHandleLowercaseLetters() //czy lowercase
    {
        // Arrange
        string input = "urdl";
        // Act
        var result = DirectionParser.Parse(input);
        // Assert
        Assert.Equal([Direction.Up, Direction.Right,
            Direction.Down, Direction.Left],
            result
        );
    }

    [Fact]
    public void Parse_ShouldReturnEmptyArrayForEmptyString() //czy pusty string
    {
        // Arrange
        string input = "";
        // Act
        var result = DirectionParser.Parse(input);
        // Assert
        Assert.Empty(result);
    }

    [Theory] //od razu kilka zestawow danych
    [InlineData("urdlx", new[] { Direction.Up, Direction.Right,
        Direction.Down, Direction.Left })]
    [InlineData("xxxdR lyyLTyu", new[] { Direction.Down,
         Direction.Right, Direction.Left, Direction.Left,
         Direction.Up })]

    public void Parse_ShouldIgnoreInvalidCharacters(string s,
        Direction[] expected) //metoda ktora ma teorie bierze argumenty w przeciwienstwie do faktu
    {
        // Arrange
        // use [Theory] [InlineData] to check multiple sets of data
        // Act
        var result = DirectionParser.Parse(s);
        // Assert
        Assert.Equal(expected, result);
    }
}
