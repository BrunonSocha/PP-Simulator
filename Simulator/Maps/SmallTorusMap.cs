namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;
    public SmallTorusMap(int size)
    {
        Size = size;
        if (Size < 5)
        {
            throw new ArgumentOutOfRangeException("The map is too small, the side length should be between 5 and 20.");
        }
        if (Size > 20)
        {
            throw new ArgumentOutOfRangeException("The map is too big, the side length should be between 5 and 20.");
        }
    }

    public override bool Exist(Point p)
    {
        Rectangle smallTorusMap = new(0, 0, Size, Size);
        return smallTorusMap.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);

        int newX = ((nextPoint.X % Size) + Size) % Size;
        int newY = ((nextPoint.Y % Size) + Size) % Size;

        return new Point(newX, newY);
    }


    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);

        int newX = ((nextPoint.X % Size) + Size) % Size;
        int newY = ((nextPoint.Y % Size) + Size) % Size;

        return new Point(newX, newY);
    }


}
