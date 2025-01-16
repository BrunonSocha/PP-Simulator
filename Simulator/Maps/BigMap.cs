namespace Simulator.Maps;

internal class BigMap : Map
{
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000 || sizeY > 1000)
        {
            throw new ArgumentOutOfRangeException("The map is too big for a small map - the limit is 20.");
        }
    }
}
