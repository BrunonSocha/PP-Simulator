using System.Reflection.Metadata.Ecma335;

namespace Simulator;

public class Birds : Animals
{

    public bool CanFly { get; set; } = true;

    public Birds(string description, uint size, bool canFly = true) : base(description, size)
    {
        CanFly = canFly;
    }

    public Birds()
    {
        
    }

    public override string Info
    {
        get 
        {
            string flyingAbility = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyingAbility}) <{Size}>";
        }

    }
    

}
