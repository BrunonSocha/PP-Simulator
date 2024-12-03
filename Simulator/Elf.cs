namespace Simulator;

public class Elf : Creature
{

    private int agility;
    public int Agility
    {
        get => agility;
        set => agility = Validator.Limiter(value, 0, 10);
    }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public Elf() : base()
    {
        
    }

    private int singCounter = 0;
    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        singCounter++;
        if ( singCounter % 3 == 0)
        {
            Agility++;
        }
    }

    public override int Power => (8 * Level) + (2 * Agility);
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    public override string Info => $"{Name} [{Level}][{Agility}]";

}
