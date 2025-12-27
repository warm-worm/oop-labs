namespace SimConsole;

using Simulator;
using Simulator.Maps;
using System.Text;

internal class LogVisualizer
{
    SimulationLog Log { get; }

    public LogVisualizer(SimulationLog log)
    {
        Log = log;
    }

    public void Draw(int turnIndex)
    {
        // sprawdzamy czy tura miesci sie w zakresie
        if (turnIndex < 0 || turnIndex >= Log.TurnLogs.Count)
        {
            Console.WriteLine($"Turn {turnIndex} is out of range.");
            return;
        }

        var turn = Log.TurnLogs[turnIndex]; // pobieramy log dla danej tury

        // naglowek tury (kto sie ruszyl i gdzie)
        Console.WriteLine($"Turn {turnIndex}: {turn.Mappable} goes {turn.Move}");

        // rysowanie mapy - gora ramki
        Console.Write(Box.TopLeft);
        for (int x = 0; x < Log.SizeX - 1; x++) Console.Write($"{Box.Horizontal}{Box.TopMid}");
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

        // srodek
        for (int y = Log.SizeY - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < Log.SizeX; x++)
            {
                var p = new Point(x, y);
                char symbol = ' ';

                // sprawdzamy czy w slowniku symboli dla tej tury jest ten punkt
                if (turn.Symbols.ContainsKey(p))
                {
                    symbol = turn.Symbols[p]; // pobieramy symbol
                }

                Console.Write($"{symbol}{Box.Vertical}");
            }
            Console.WriteLine();

            // linia oddzielajaca
            if (y > 0)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < Log.SizeX - 1; x++) Console.Write($"{Box.Horizontal}{Box.Cross}");
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
        }

        // dol ramki
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < Log.SizeX - 1; x++) Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");
    }
}
