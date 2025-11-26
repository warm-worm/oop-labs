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

    public abstract void SayHi();

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

    public void Go(Direction dir) => Console.WriteLine($"{Name} goes {dir.ToString().ToLower()}.");
    public void Go(Direction[] directions) => Array.ForEach(directions, Go);
    public void Go(string moves) => Go(DirectionParser.Parse(moves));
}
