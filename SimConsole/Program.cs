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
                new Orc("Orkoid", level: 7, rage: 2),
            };

        Point dpoint = new(7, 5);
        Point rpoint = new(8, 4);
        List<Point> points = new List<Point> { dpoint, rpoint };
        var simulation = new Simulation(Mapka, elves, points, "ruulrdulxx");
        MapVisualizer startprog = new(simulation);
        startprog.VisualizeSimulation();
    }
}
