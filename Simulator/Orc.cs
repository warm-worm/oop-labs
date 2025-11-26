namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    private int _huntCount = 0;

    public int Rage
    {
        get => _rage;
        init => _rage = Validator.Limiter(value, 0, 10);
    }

    public Orc() : base() { }
    public Orc(string name, int level = 1, int rage = 1) : base(name, level) => Rage = rage;

    public void Hunt()
    {
        _huntCount++;
        if (_huntCount % 2 == 0)
            _rage = Validator.Limiter(Rage + 1, 0, 10);

        Console.WriteLine($"{Name} is hunting.");
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

    public override int Power => Level * 7 + Rage * 3;
    public override string Info => $"{Name} [{Level}][{Rage}]";
}
