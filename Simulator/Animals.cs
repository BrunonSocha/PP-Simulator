using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
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

    public Point Position { get; set; }

    public SmallMap CurrentMap { get; set; }

    public virtual char Symbol => 'A';

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
