namespace Simulator;
using Simulator.Maps;

public abstract class Creature : IMappable
{
    private string name = "Unknown";

    public virtual char Symbol { get; }


    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }


    private int level = 1;
    public int Level
    {
        get => level;
        set => level = Validator.Limiter(value, 1, 10);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {

    }

    public abstract string Info { get; }

    public abstract int Power { get; }

    public abstract string Greeting();

    public void Upgrade()
    {
        Level++;
    }

    public override string ToString() => $"{this.GetType().Name.ToUpper()}: {Info}";


    // WARNING: I've decided to make it so that the creature doesn't move if the direction provided is wrong.
    // If the Professor would like, I can change it to work like the Point does - to throw an exception instead.

    public Point Position { get; set; }

    public SmallMap CurrentMap { get; set; }

    public void Go(Direction direction)
    {

        switch (direction)
            {
            case Direction.Up:
                Position = CurrentMap.Next(Position, Direction.Up);
                break;
            case Direction.Right:
                Position = CurrentMap.Next(Position, Direction.Right);
                break;
            case Direction.Down:
                Position = CurrentMap.Next(Position, Direction.Down);
                break;
            case Direction.Left:
                Position = CurrentMap.Next(Position, Direction.Left);
                break;
            }
        CurrentMap.CreaturesPositions[this] = Position;


        
    }
    public void AssignMap(SmallMap map, Point startingposition)
    {
        CurrentMap = map;
        Position = startingposition;
        CurrentMap.Add(this, startingposition);
    }
}