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

        int newX = ((nextPoint.X % SizeX) + SizeX) % SizeX;
        int newY = ((nextPoint.Y % SizeY) + SizeY) % SizeY;

        return new Point(newX, newY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);

        int newX = ((nextPoint.X % SizeX) + SizeX) % SizeX;
        int newY = ((nextPoint.Y % SizeY) + SizeY) % SizeY;

        return new Point(newX, newY);
    }
}