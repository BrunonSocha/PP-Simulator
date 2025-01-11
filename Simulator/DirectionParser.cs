namespace Simulator;

internal static class DirectionParser
{
    public static List<Direction> Parse(string directions)
    {
        var newDirections = new List<Direction>();

        foreach (var direction in directions)
        {
            char upperDirection = char.ToUpper(direction);

            switch (upperDirection)
            {
                case 'U':
                    newDirections.Add(Direction.Up);
                    break;

                case 'R':
                    newDirections.Add(Direction.Right);
                    break;

                case 'D':
                    newDirections.Add(Direction.Down);
                    break;

                case 'L':
                    newDirections.Add(Direction.Left);
                    break;
            }
        }

        return newDirections;

    }
}
