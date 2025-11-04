namespace Simulator;

public class Creature
{
    private string _name = "Unknown"; //wartosc domyslna name
    private int _level = 1; //wartosc domyslna level

    private bool _nameInitialized = false; //czy wartosc byla juz ustawiona
    private bool _levelInitialized = false;

    public string Name
    {
        get { return _name; }
        set
        {
            if (_nameInitialized) return;

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
            _nameInitialized = true; //ustawienie flagi
        }
    }

    public int Level
    {
        get { return _level; }
        set
        {
            if (_levelInitialized) return; //nadajemy tylko raz

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
            _levelInitialized = true; //flaga
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {

    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I am {Name}!");
    }

    public void Upgrade() //awans o jeden poziom, max 10
    {
        if (_level < 10)
        {
            _level++;
        }
    }

    public string Info
    {
        get { return $"{Name} ({Level})"; }
    }
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
}