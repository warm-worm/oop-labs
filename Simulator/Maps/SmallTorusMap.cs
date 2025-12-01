namespace Simulator.Maps;

using Simulator;

public class SmallTorusMap : Map
{
    private readonly int _size;
    public int Size => _size; // wlasciwosc tylko do odczytu

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20) // rozmiar musi byc miedzy 5 a 20
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
        }
        _size = size;
    }

    public override bool Exist(Point p)
    {
        Rectangle bounds = new Rectangle(0, 0, Size - 1, Size - 1); // granice mapy
        return bounds.Contains(p); // dla torusa tez sprawdzamy czy bazowy punkt jest w srodku
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d); // obliczamy nastepny punkt

        // torus logic: zawijanie wspolrzednych po przekroczeniu granic
        // dodanie Size, zeby uniknac ujemnych wynikow modulo, potem modulo Size, inaczej nie dziala
        int x = (nextPoint.X + Size) % Size;
        int y = (nextPoint.Y + Size) % Size;

        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d); // obliczamy nastepny punkt po skosie

        // torus logic: to samo zawijanie co wyzej
        int x = (nextPoint.X + Size) % Size;
        int y = (nextPoint.Y + Size) % Size;

        return new Point(x, y);
    }
}