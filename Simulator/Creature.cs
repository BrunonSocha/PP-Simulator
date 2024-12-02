namespace Simulator;

internal class Creature
{
    private string name;

    public string Name { get; init; } = "NoName";

    private int level;

    public int Level
    {
        get => level;
        set => level = value > 0 ? value : 1;
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {
        
    }

    public string Info => $"{Name} [{Level}]";

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}");

}
