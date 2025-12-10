namespace SimConsole;

using Simulator;
using Simulator.Maps;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; // zeby dzialaly znaki ramek

        SmallSquareMap map = new(5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)]; // dziala na spokojnie z innymi danymi wejsciowymi
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        Console.WriteLine("SIMULATION!");
        Console.WriteLine();
        mapVisualizer.Draw();

        while (!simulation.Finished)
        {
            Console.WriteLine("Press any key to make a move...");
            Console.ReadKey();

            Console.WriteLine($"\nTurn: {simulation.CurrentCreature.Name} goes {simulation.CurrentMoveName}");

            simulation.Turn();
            mapVisualizer.Draw();
        }

        Console.WriteLine("\nSimulation finished!");
    }
}