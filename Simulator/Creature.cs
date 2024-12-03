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

    public abstract void SayHi();

    public void Upgrade()
    {
        Level++;
    }

    public override string ToString() 
    {
        return $"{this.GetType().Name.ToUpper()}: {Info}";
    }

    public void Go(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                Console.WriteLine($"{Name} goes up.");
                break;
            case Direction.Right:
                Console.WriteLine($"{Name} goes right.");
                break;
            case Direction.Down:
                Console.WriteLine($"{Name} goes down.");
                break;
            case Direction.Left:
                Console.WriteLine($"{Name} goes left.");
                break;
        }
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            switch (direction)
            {
                case Direction.Up:
                    Console.WriteLine($"{Name} goes up.");
                    break;
                case Direction.Right:
                    Console.WriteLine($"{Name} goes right.");
                    break;
                case Direction.Down:
                    Console.WriteLine($"{Name} goes down.");
                    break;
                case Direction.Left:
                    Console.WriteLine($"{Name} goes left.");
                    break;
            }
        }
    }

    public void Go(string directions)
    {
        Direction[] parsedDirections = DirectionParser.Parse(directions);

        foreach (var direction in parsedDirections)
        {
            switch (direction)
            {
                case Direction.Up:
                    Console.WriteLine($"{Name} goes up.");
                    break;
                case Direction.Right:
                    Console.WriteLine($"{Name} goes right.");
                    break;
                case Direction.Down:
                    Console.WriteLine($"{Name} goes down.");
                    break;
                case Direction.Left:
                    Console.WriteLine($"{Name} goes left.");
                    break;
            }
        }
    }

}
