namespace Simulator.Maps;

public interface IMappable
{
    Point Position { get; set; }
    char Symbol { get; }

    public string ToString();

    SmallMap CurrentMap { get; set; }

    void AssignMap(SmallMap CurrentMap, Point Position);

    void Go(Direction direction);
    
}
