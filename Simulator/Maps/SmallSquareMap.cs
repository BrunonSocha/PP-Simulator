namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public readonly int Size;
    public SmallSquareMap(int size)
    {
        Size = size;
        if (Size < 5)
        {
            throw new ArgumentOutOfRangeException("The map is too small, the side length should be between 5 and 20");
        }
        if (Size > 20)
        {
            throw new ArgumentOutOfRangeException("The map is too big, the side length should be between 5 and 20.");
        }
    }

    public override bool Exist(Point p)
    {
        Rectangle smallMap = new(0, 0, Size, Size);
        return smallMap.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        if (nextPoint.X >= Size || nextPoint.Y >= Size || nextPoint.X < 0 || nextPoint.Y < 0 )
        {
            return p;
        }
        else
        {
            return nextPoint;
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        if (nextPoint.X >= Size || nextPoint.Y >= Size || nextPoint.X < 0 || nextPoint.Y < 0)
        {
            return p;
        }
        else
        {
            return nextPoint;
        }
    }

}
