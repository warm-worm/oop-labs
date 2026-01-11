using Simulator;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
       List<Creature> creatures =
       [
            new Elf("Elrond", 5, 7),
            new Orc("Gorgul", 4, 6),
            new Elf("Legolas", 6, 8),
            new Orc("Thrall", 5, 7),
            new Elf("Tauriel", 4, 5),
            new Orc("Azog", 6, 9)
        ];
        creatures.ForEach(c => Console.WriteLine($"{c,-20} power: {c.Power}"));

        Console.WriteLine("\nPosortowane wg mocy:\n");

        creatures.Sort((x, y) => y.Power - x.Power);
        creatures.ForEach(c => Console.WriteLine($"{c,-20} power: {c.Power}"));

        Console.WriteLine("\nPosortowane wg imion:\n");
        creatures.Sort((x, y) => x.Name.CompareTo(y.Name));
        creatures.ForEach(c => Console.WriteLine($"{c,-20} name: {c.Power}"));
    }   
}
