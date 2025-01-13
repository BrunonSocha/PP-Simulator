namespace SimConsole;
using Simulator;
using Simulator.Maps;

internal class SimConsole
{
    static void Main(string[] args)
    {
        SmallMap Mapka = new SmallTorusMap(8, 6);
        List<IMappable> beings = new List<IMappable>
            {
                new Elf("Legolas", level: 5, agility: 8),
                new Orc("Orkoid", level: 7, rage: 2),
                new Animals(){Description = "Rabbits", Size = 5},
                new Birds(){Description = "Eagles", Size = 6, CanFly = true},
                new Birds(){Description = "Ostriches", Size = 3, CanFly = false}
            };

        Point apoint = new(7, 5);
        Point bpoint = new(8, 4);
        Point cpoint = new(5, 5);
        Point dpoint = new(1, 1);
        Point epoint = new(3, 3);
        List<Point> points = new List<Point> { apoint, bpoint, cpoint, dpoint, epoint };
        var simulation = new Simulation(Mapka, beings, points, "ruulrdulxx");
        MapVisualizer startprog = new(simulation);
        startprog.VisualizeSimulation();
    }
}
