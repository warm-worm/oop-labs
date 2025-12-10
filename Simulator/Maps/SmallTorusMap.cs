namespace Simulator.Maps;

using Simulator;

public class SmallTorusMap : Map
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) // rozmiar musi byc miedzy 5 a 20
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Size must be below 20.");
        if (sizeY > 20) // rozmiar musi byc miedzy 5 a 20
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Size must be below 20.");
    }

    public override Point Next(Point p, Direction d)
    {
        Point next = p.Next(d); // obliczamy nastepny punkt
        int x = (next.X + SizeX) % SizeX; // torus logic: jesli wychodzi poza mape, zawijamy na druga strone
        int y = (next.Y + SizeY) % SizeY;

        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d); // obliczamy nastepny punkt po skosie

        // torus logic: to samo zawijanie co wyzej
        int x = (nextPoint.X + SizeX) % SizeX;
        int y = (nextPoint.Y + SizeY) % SizeY;

        return new Point(x, y);
    }
}