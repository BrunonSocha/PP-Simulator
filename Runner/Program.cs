using Simulator.Maps;
using Simulator;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Orc testorc = new("dzban", 4, 5);
        SmallSquareMap testmap = new(10, 10);
        Point startpos = new(10, 10);
        testorc.AssignMap(testmap, startpos);
        Console.WriteLine(testorc.Position);
        testorc.Go(Direction.Right);
        Console.WriteLine(testorc.Position);
        Point endpos = new(5, 5);
        testmap.Move(testorc, endpos);
        Console.WriteLine(testorc.Position);
        Console.WriteLine(testmap.At(endpos));
    }
}
