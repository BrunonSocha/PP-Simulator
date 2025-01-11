using System.Security.Cryptography.X509Certificates;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{

    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
        {
            throw new ArgumentOutOfRangeException("The map is too big for a small map - the limit is 20.");
        }
    }

    public Dictionary<Creature, Point> CreaturesPositions { get; set; }


    public void Add(Creature creature, Point position)
    {
        if (CreaturesPositions == null)
        {
            CreaturesPositions = new Dictionary<Creature, Point>();
        }
        if (CreaturesPositions.ContainsKey(creature))
        {
            throw new Exception($"This creature is already on the map, with the position {CreaturesPositions[creature]}.");
        }
        if (Exist(position))
        {
            throw new Exception("This point is outside of the map.");
        }
        CreaturesPositions.Add(creature, position);
    }

    public void Remove(Creature creature)
    {
        if (CreaturesPositions.ContainsKey(creature))
        {
            CreaturesPositions.Remove(creature);
            creature.CurrentMap = null;
            creature.Position = new Point (0, 0);
        }
        else
        {
            throw new Exception("This creature doesn't exist on this map.");
        }
    }

    public void Move(Creature creature, Point position)
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
        var creaturesAtPosition = new List<Creature>();

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
        var creaturesAtPosition = new List<Creature>();

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
