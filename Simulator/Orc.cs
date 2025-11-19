namespace Simulator;

public class Orc : Creature
{
    private int _rage; //wartosc prywatna
    private int _huntCount = 0; //licznik polowan

    public int Rage
    {
        get { return _rage; }
        init //ustawiana tylko przy inicjalizacji
        {
            int processed = value;
            if (processed < 0) processed = 0;
            if (processed > 10) processed = 10;
            _rage = processed;
        }
    }

    public Orc() : base() { }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public void Hunt()
    {
        _huntCount++;
        Console.WriteLine($"{Name} is hunting.");

        if (_huntCount % 2 == 0) //co 2 polowanie
        {
            if (_rage < 10) _rage++;
        }
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    }

    public override int Power => Level * 7 + Rage * 3;

    public override string Info => $"{Name} [{Level}][{Rage}]";
}
