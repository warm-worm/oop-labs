namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _singCount = 0;

    public int Agility
    {
        get => _agility;
        init => _agility = Validator.Limiter(value, 0, 10);
    }

    public Elf() : base() { }
    public Elf(string name, int level = 1, int agility = 1) : base(name, level) => Agility = agility;

    public void Sing()
    {
        _singCount++;
        if (_singCount % 3 == 0)
            _agility = Validator.Limiter(Agility + 1, 0, 10);

        //Console.WriteLine($"{Name} is singing.");
    }

    //public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
    public override int Power => Level * 8 + Agility * 2;
    public override char MapSymbol => 'E'; // symbol elfa
    public override string Info => $"{Name} [{Level}][{Agility}]";
    public override char Symbol => MapSymbol;
}
