namespace Simulator.Maps;

public abstract class Map
{
    public readonly int SizeX, SizeY;
    public Rectangle Surface { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "The map dimensions must be at least 5x5.");
        }

        SizeX = sizeX;
        SizeY = sizeY;
        Surface = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    public bool Exist(Point p) => Surface.Contains(p);

    public abstract Point Next(Point p, Direction d);

    public abstract Point NextDiagonal(Point p, Direction d);
}