namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";

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

    public string Go(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up: return $"{Name} goes up.";
            case Direction.Right: return $"{Name} goes right.";
            case Direction.Down: return $"{Name} goes down.";
            case Direction.Left: return $"{Name} goes left.";
            default: return $"{Name} doesn't move.";
        }
    }

    public string Go(List<Direction> directions)
    {
        foreach (var direction in directions)
        {
            switch (direction)
            {
                case Direction.Up: return $"{Name} goes up.";
                case Direction.Right: return $"{Name} goes right.";
                case Direction.Down: return $"{Name} goes down.";
                case Direction.Left: return $"{Name} goes left.";
                default: return $"{Name} doesn't move.";
            }
        }
        return $"{Name} doesn't move.";
    }

    public string Go(string directions)
    {
        List<Direction> parsedDirections = DirectionParser.Parse(directions);

        foreach (var direction in parsedDirections)
        {
            switch (direction)
            {
                case Direction.Up: return $"{Name} goes up.";
                case Direction.Right: return $"{Name} goes right.";
                case Direction.Down: return $"{Name} goes down.";
                case Direction.Left: return $"{Name} goes left.";
                default: return $"{Name} doesn't move.";
            }
        }
        return $"{Name} doesn't move.";
    }

}
