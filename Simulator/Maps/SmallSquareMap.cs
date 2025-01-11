using Simulator.Maps;
using Simulator;

public class SmallSquareMap : SmallMap
{
   
    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (SizeY != SizeX)
        {
            throw new Exception("The map is supposed to be a square!");
        }
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return Exist(nextPoint) ? nextPoint : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return Exist(nextPoint) ? nextPoint : p;
    }
}
