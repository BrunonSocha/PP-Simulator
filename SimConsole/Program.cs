namespace SimConsole;
using Simulator;
using Simulator.Maps;

internal class SimConsole
{
    static void Main(string[] args)
    {
        SmallMap Mapka = new SmallSquareMap(10, 10);
        List<Creature> elves = new List<Creature>
            {
                new Elf("Legolas", level: 5, agility: 8),
                new Orc("Dzbanoid", level: 7, rage: 2),
                new Elf("Galadriel", level: 10, agility: 9),
                new Elf("Elrond", level: 8, agility: 7),
            };

        Point spoint = new(5, 2);
        Point dpoint = new(5, 5);
        Point rpoint = new(8, 4);
        Point wpoint = new(3, 3);
        List<Point> points = new List<Point> { spoint, dpoint, rpoint, wpoint };
        var simulation = new Simulation(Mapka, elves, points, "rdulrdul");

        
    }
}
