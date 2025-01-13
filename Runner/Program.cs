using Simulator.Maps;
using Simulator;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Orc testorc = new("dzban", 4, 5);
        SmallSquareMap testmap = new(10, 10);
        Point startpos = new(9, 9);
        testorc.AssignMap(testmap, startpos);
        Console.WriteLine(testorc.Position);
        testorc.Go(Direction.Right);
        Console.WriteLine(testorc.Position);
        Point endpos = new(5, 5);
        testmap.Move(testorc, endpos);
        Console.WriteLine(testorc.Position);
        Console.WriteLine(testmap.At(endpos));
        List<Creature> elves = new List<Creature>
            {
                new Elf("Legolas", level: 5, agility: 8),
                new Elf("Thranduil", level: 7, agility: 6),
                new Elf("Galadriel", level: 10, agility: 9),
                new Elf("Elrond", level: 8, agility: 7),
            };

        Point spoint = new(5, 5);
        Point dpoint = new(5, 5);
        Point rpoint = new(5, 5);
        Point wpoint = new(5, 5);
        List<Point> points = new List<Point> { spoint, dpoint, rpoint, wpoint };


        Simulation simulationtest = new(testmap, elves, points, "rdlurdur");
        simulationtest.Turn();
        simulationtest.Turn();
        simulationtest.Turn();
        simulationtest.Turn();

        foreach (var creature in testmap.CreaturesPositions)
        {
            Console.WriteLine($"{creature.Key.Name} is at {creature.Value}");
        }

    }
}
