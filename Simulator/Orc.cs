namespace Simulator;
using Simulator.Maps;

public class Orc : Creature
{

    private int rage;
    public int Rage
    {
        get => rage;
        set => rage = Validator.Limiter(value, 0, 10);
    }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public Orc() : base()
    {
        
    }

    private int huntCounter = 0;
    public void Hunt()
    {
        huntCounter++;
        if (huntCounter % 2 == 0)
        {
            Rage++;
        }
    }

    public override int Power => (7 * Level) + (3 * Rage);

    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}";

    public override string Info => $"{Name} [{Level}][{Rage}]";

}
