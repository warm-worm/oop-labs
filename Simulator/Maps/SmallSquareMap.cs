namespace Simulator.Maps;

using Simulator; // zeby dzialalo Point i Direction i dziedziczylo po Map

public class SmallSquareMap : Map
{
    private readonly int _size;
    private readonly Rectangle _bounds; // pole prywatne na granice mapy
    public int Size => _size; // wlasciwosc tylko do odczytu

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20) // rozmiar musi byc miedzy 5 a 20
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20."); // wyjatek jak zly rozmiar
        }
        _size = size;
        _bounds = new Rectangle(0, 0, _size - 1, _size - 1); // tworzymy granice mapy raz w konstruktorze
    }

    public override bool Exist(Point p) // czy punkt nalezy do mapy
    {
        return _bounds.Contains(p); // czy punkt jest w srodku
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d); // obliczamy gdzie by poszedl
        if (Exist(nextPoint)) // jesli miesci sie w mapie
        {
            return nextPoint; // to idzie
        }
        return p; // jak sciana to zostaje w miejscu
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d); // obliczamy gdzie by poszedl po skosie
        if (Exist(nextPoint)) // jesli miesci sie w mapie
        {
            return nextPoint; // to idzie
        }
        return p; // jak sciana to zostaje
    }
}