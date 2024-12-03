namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";

    public string Name
    {
        get => name;
        init
        {
            string newName = value.Trim();

            if (string.IsNullOrEmpty(newName))
            {
                newName = "Unknown";
            }

            if (newName.Length > 25)
            {
                newName = newName.Substring(0, 25).Trim();
            }

            if (newName.Length < 3)
            {
                newName = newName.PadRight(3, '#');
            }

            if (char.IsLower(newName[0]))
            {
                newName = char.ToUpper(newName[0]) + newName.Substring(1);
            }

            name = newName;

        }
    }

    private int level;
    public int Level
    {
        get => level;
        set => level = Math.Clamp(value, 1, 10);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() : this("Unknown", 1)
    {

    }

    public string Info => $"{Name} [{Level}]";

    public abstract int Power { get; }

    public abstract void SayHi();

    public void Upgrade()
    {
        Level++;
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
