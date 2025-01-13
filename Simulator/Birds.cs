namespace Simulator;

public class Birds : Animals
{
    public override char Symbol => CanFly ? 'B' : 'b';
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

    public void Go(Direction direction)
    {
        if (CanFly)
        {
            Point NewPosition = new();
            switch (direction)
            {
                case Direction.Up:
                    NewPosition = CurrentMap.Next(Position, Direction.Up);
                    Position = CurrentMap.Next(NewPosition, Direction.Up);
                    break;
                case Direction.Right:
                    NewPosition = CurrentMap.Next(Position, Direction.Right);
                    Position = CurrentMap.Next(NewPosition, Direction.Right);
                    break;
                case Direction.Down:
                    NewPosition = CurrentMap.Next(Position, Direction.Down);
                    Position = CurrentMap.Next(NewPosition, Direction.Down);
                    break;
                case Direction.Left:
                    NewPosition = CurrentMap.Next(Position, Direction.Left);
                    Position = CurrentMap.Next(NewPosition, Direction.Left);
                    break;
            }

            CurrentMap.CreaturesPositions[this] = Position;
        }
        else
        {
            switch (direction)
            {
                case Direction.Up:
                    Position = CurrentMap.NextDiagonal(Position, Direction.Up);
                    break;
                case Direction.Right:
                    Position = CurrentMap.NextDiagonal(Position, Direction.Right);
                    break;
                case Direction.Down:
                    Position = CurrentMap.NextDiagonal(Position, Direction.Down);
                    break;
                case Direction.Left:
                    Position = CurrentMap.NextDiagonal(Position, Direction.Left);
                    break;
            }

            CurrentMap.CreaturesPositions[this] = Position;
        }


    }

}
