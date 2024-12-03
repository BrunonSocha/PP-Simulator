namespace Simulator;

public class Animals
{
    private string description;
    public required string Description 
    { 
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');  
    }

    public Animals(string description, uint size = 3)
    {
        Description = description;
        Size = size;
    }

    public Animals()
    {
        
    }

    public uint Size { get; set; } = 3;
    
    public virtual string Info { get => $"{Description} <{Size}>"; }

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {Info}";
    }
}
