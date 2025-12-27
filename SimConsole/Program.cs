namespace SimConsole;

using Simulator;
using Simulator.Maps;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Select simulation:"); //mam nadzieje ze po angielsku jest ok..
        Console.WriteLine("1. Creatures");
        Console.WriteLine("2. Birds & Animals");

        var key = Console.ReadKey();
        Console.WriteLine();

        if (key.KeyChar == '1') Sim1();
        else if (key.KeyChar == '2') Sim2();
        else Console.WriteLine("Invalid choice.");
    }

    static void Sim1()
    {
        SmallSquareMap map = new(5);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer visualizer = new(simulation.Map);
        Run(simulation, visualizer);
    }

    static void Sim2()
    {
        SmallTorusMap map = new(8, 6);
        List<IMappable> mappables = [
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 10 },
            new Birds { Description = "Eagles", CanFly = true },
            new Birds { Description = "Ostriches", CanFly = false }
        ];
        List<Point> points = [new(0, 0), new(7, 5), new(2, 2), new(4, 4), new(6, 1)];
        string moves = "urdluuuuurrrddlldd";

        Simulation simulation = new(map, mappables, points, moves);
        MapVisualizer visualizer = new(simulation.Map);
        Run(simulation, visualizer);
    }

    static void Run(Simulation simulation, MapVisualizer visualizer)
    {
        visualizer.Draw();
        while (!simulation.Finished)
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Console.WriteLine($"\nTurn: {simulation.CurrentMappable.ToString()} goes {simulation.CurrentMoveName}");
            simulation.Turn();
            visualizer.Draw();
        }
        Console.WriteLine("Finished!");
    }
}