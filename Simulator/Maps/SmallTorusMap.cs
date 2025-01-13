using Simulator.Maps;
using Simulator;

public class SmallTorusMap : SmallMap
{

    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);

        int newX = ((nextPoint.X - 1 + SizeX) % SizeX) + 1;
        int newY = ((nextPoint.Y - 1 + SizeY) % SizeY) + 1;

        return new Point(newX, newY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);

        int newX = ((nextPoint.X - 1 + SizeX) % SizeX) + 1;
        int newY = ((nextPoint.Y - 1 + SizeY) % SizeY) + 1;

        return new Point(newX, newY);
    }
}