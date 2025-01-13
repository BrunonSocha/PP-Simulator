namespace Simulator.Maps;
using Simulator;

public abstract class Map
{
    public readonly int SizeX, SizeY;
    public Rectangle Surface { get; }

    public Point Position { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "The map dimensions must be at least 5x5.");
        }

        SizeX = sizeX;
        SizeY = sizeY;
        Position = Position;
        Surface = new Rectangle(1, 1, SizeX, SizeY);
    }

    public bool Exist(Point p) => Surface.Contains(p);

    public abstract Point Next(Point p, Direction d);

    public abstract Point NextDiagonal(Point p, Direction d);

    public Dictionary<IMappable, Point> CreaturesPositions { get; set; }


    public void Add(IMappable creature, Point position)
    {
        CreaturesPositions ??= new Dictionary<IMappable, Point>();

        if (CreaturesPositions.ContainsKey(creature))
        {
            throw new Exception($"This creature is already on the map, with the position {CreaturesPositions[creature]}.");
        }
        if (!Exist(position))
        {
            throw new Exception("This point is outside of the map.");
        }
        CreaturesPositions.Add(creature, position);
    }

    public void Remove(IMappable creature)
    {
        if (CreaturesPositions.ContainsKey(creature))
        {
            CreaturesPositions.Remove(creature);
            creature.CurrentMap = null;
            creature.Position = new Point(1, 1);
        }
        else
        {
            throw new Exception("This creature doesn't exist on this map.");
        }
    }

    public void Move(IMappable creature, Point position)
    {
        if (CreaturesPositions == null)
        {
            throw new Exception("There are no creatures on the map.");
        }
        if (CreaturesPositions.ContainsKey(creature) && Exist(position))
        {
            CreaturesPositions[creature] = position;
            creature.Position = position;
        }
    }

    public string At(Point position)
    {
        if (!Exist(position))
        {
            throw new Exception("This point doesn't exist on the map.");
        }
        var creaturesAtPosition = new List<IMappable>();

        foreach (var keyvalue in CreaturesPositions)
        {
            if (keyvalue.Value.Equals(position))
            {
                creaturesAtPosition.Add(keyvalue.Key);
            }
        }
        return string.Join(", ", creaturesAtPosition);
    }

    public string At(int x, int y)
    {
        Point position = new Point(x, y);

        if (!Exist(position))
        {
            throw new Exception("This point doesn't exist on the map.");
        }
        var creaturesAtPosition = new List<IMappable>();

        foreach (var keyvalue in CreaturesPositions)
        {
            if (keyvalue.Value.Equals(position))
            {
                creaturesAtPosition.Add(keyvalue.Key);
            }
        }
        return string.Join(", ", creaturesAtPosition);
    }

}