namespace Simulator;

public class Elf : Creature
{
    private int _agility; //wartosc prywatna
    private int _singCount = 0; //licznik spiewow

    public int Agility
    {
        get { return _agility; }
        init //ustawiana tylko przy inicjalizacji
        {
            int processed = value;
            if (processed < 0) processed = 0;
            if (processed > 10) processed = 10;
            _agility = processed;
        }
    }

    public Elf() : base() { }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public void Sing()
    {
        _singCount++;
        Console.WriteLine($"{Name} is singing.");

        if (_singCount % 3 == 0) //co 3 spiew
        {
            if (_agility < 10) _agility++;
        }
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    }

    public override int Power => Level * 8 + Agility * 2;

    public override string Info => $"{Name} [{Level}][{Agility}]";
}
