namespace Simulator;

using System.Collections.Generic; //musi byc zeby uzyc List<Direction>

public static class DirectionParser
{
    public static List<Direction> Parse(string input) //metoda statyczna zwracajaca tablice Direction
    {
        var directions = new List<Direction>();
        if (input == null)
        {
            return directions; //pusta tablica jesli input null
        }

        foreach (char c in input.ToUpper()) //ignorujemy wielkosc liter
        {
            switch (c)
            {
                case 'U':
                    directions.Add(Direction.Up);
                    break;
                case 'R':
                    directions.Add(Direction.Right);
                    break;
                case 'D':
                    directions.Add(Direction.Down);
                    break;
                case 'L':
                    directions.Add(Direction.Left);
                    break;
                default: //ignorujemy niepoprawne znaki
                    break;
            }
        }
        return directions;
    }
}