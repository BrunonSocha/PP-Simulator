using Simulator.Maps;


namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public SmallMap CurrentMap { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Parsed moves kept as a list of directions.
    /// </summary>
    public List<Direction> ParsedMoves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature { get; private set; }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get; private set; }

    public Direction CurrentMove { get; private set; }

    public void SetCurrentCreature(Creature creature)
    {
        CurrentCreature = creature;
    }
    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(SmallMap map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        Creatures = creatures ?? throw new ArgumentNullException("Creature list can't be empty.");
        Positions = positions;
        if (Creatures.Count != Positions.Count)
        {
            throw new Exception("The creature count isn't the same as the positions count.");
        }
        CurrentMap = map;
        Creatures = creatures;
        ParsedMoves = DirectionParser.Parse(moves);
        for (int i = 0; i < Creatures.Count; i++)
        {
            Creatures[i].AssignMap(CurrentMap, Positions[i]);
        }


    }


    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    /// 

    private int TurnCount = 0;
    public void Turn() 
    {
        if (Finished)
        {
            throw new Exception("The simulation has finished.");
        }

        Creature CurrentCreature = Creatures[TurnCount % Creatures.Count];
        CurrentMove = ParsedMoves[TurnCount];
        CurrentMoveName = CurrentMove.ToString().ToLower();
        CurrentCreature.Go(CurrentMove);
        Console.WriteLine($"{CurrentCreature} moves {CurrentMoveName}. Now the current position is {CurrentCreature.Position}");
        TurnCount++;
        if (TurnCount == ParsedMoves.Count)
        {
            Finished = true;
        }
    }
}