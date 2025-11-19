namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown"; //wartosc domyslna name
    private int _level = 1; //wartosc domyslna level

    public string Name
    {
        get { return _name; }
        init //ustawiamy tylko przy inicjalizacji
        {
            string processedName = value;

            if (string.IsNullOrWhiteSpace(processedName)) //usuwanie spacji
            {
                processedName = "###"; //brakujace znaki
            }
            else
            {
                processedName = processedName.Trim();
            }

            if (processedName.Length > 25) //najwyzej 25 znakow
            {
                processedName = processedName.Substring(0, 25);
                processedName = processedName.TrimEnd(); //uwuwanie spacji na koncu
            }

            while (processedName.Length < 3) //3 znaki min
            {
                processedName += "#";
            }

            if (char.IsLower(processedName[0])) //pierwsza wielka litera
            {
                processedName = char.ToUpper(processedName[0]) + processedName.Substring(1);
            }

            _name = processedName;
        }
    }

    public int Level
    {
        get { return _level; }
        init //ustawiamy tylko przy inicjalizacji
        {
            int processedLevel = value;

            if (processedLevel < 1) //1-10
            {
                processedLevel = 1;
            }
            else if (processedLevel > 10)
            {
                processedLevel = 10;
            }

            _level = processedLevel;
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() //bezparametrowy
    {

    }

    public abstract void SayHi(); //metoda abstrakcyjna – implementacja w klasach pochodnych

    public void Upgrade() //awans o jeden poziom, max 10
    {
        if (_level < 10)
        {
            _level++;
        }
    }

    public abstract int Power { get; } //abstrakcyjna właściwość – implementacja w klasach pochodnych

    public abstract string Info { get; } //abstrakcyjna właściwość – implementacja w klasach pochodnych

    public void Go(Direction dir) //jeden kierunek
    {
        Console.WriteLine($"{Name} goes {dir.ToString().ToLower()}."); //zmiana np. "Up" na "up"
    }

    public void Go(Direction[] directions) //tablica kierunkow
    {
        foreach (Direction dir in directions)
        {
            Go(dir); //pierwsza metoda Go
        }
    }

    public void Go(string moves) //info o ruchu w stringu
    {
        Direction[] directions = DirectionParser.Parse(moves);
        Go(directions); //druga metoda Go
    }

    public override string ToString() //override ToString() zwracajacy typ i Info
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
