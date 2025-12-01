namespace Simulator;

public readonly struct Point // struktura, bo prosty kontener danych
{
    public readonly int X, Y; // pola tylko do odczytu

    public Point(int x, int y) => (X, Y) = (x, y); // szybkie przypisanie pola

    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction) // zwraca nowy punkt przesuniety w danym kierunku
    {
        switch (direction)
        {
            case Direction.Up: return new Point(X, Y + 1);
            case Direction.Right: return new Point(X + 1, Y);
            case Direction.Down: return new Point(X, Y - 1);
            case Direction.Left: return new Point(X - 1, Y);
            default: return default;
        }
    }

    // rotate given direction 45 degrees clockwise
    public Point NextDiagonal(Direction direction) // ruch po skosie (obrot o 45 stopni zgodnie z zegarem)
    {
        switch (direction)
        {
            case Direction.Up: return new Point(X + 1, Y + 1); // gora -> prawy gorny rog
            case Direction.Right: return new Point(X + 1, Y - 1); // prawo -> prawy dolny rog
            case Direction.Down: return new Point(X - 1, Y - 1); // dol -> lewy dolny rog
            case Direction.Left: return new Point(X - 1, Y + 1); // lewo -> lewy gorny rog
            default: return default;
        }
    }
}