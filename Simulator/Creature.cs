namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown"; //wartosc domyslna name
    private int _level = 1;           //wartosc domyslna level

    public string Name
    {
        get => _name;
        init => _name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => _level;
        init => _level = Validator.Limiter(value, 1, 10);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract string Greeting();

    public void Upgrade()
    {
        if (_level < 10) _level++;
    }

    public abstract int Power { get; }
    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    //public void Go(Direction dir) => Console.WriteLine($"{Name} goes {dir.ToString().ToLower()}.");
    string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        var result = new string[directions.Length];
        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }
    public string[] Go(string moves)
    {
        return Go(DirectionParser.Parse(moves));
    }
}
