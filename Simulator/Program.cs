using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        static void lab5a()
        {
            // creates two points and uses them to create a rectangle. this way we check if the ctor that accepts points calls on the other constructor
            Point pointTest1 = new(10, 25);
            Point pointTest2 = new(8, 12);
            Rectangle rectangleTest1 = new(pointTest1, pointTest2);
            Console.WriteLine(rectangleTest1);

            // we check if it will catch an exception if passed a rectangle with the surface of 0
            try
            {
                Rectangle rectangleTest2 = new(5, 10, 5, 20);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // we check the Contains() function
            Point pointTest3 = new(9, 22);
            Console.WriteLine(rectangleTest1.Contains(pointTest3));

        }

        lab5a();

        static void lab5b()
        {

            // tries to create a map too big. the error message from the exception caught tells the user it's too big.
            try
            {
                SmallSquareMap mapTest1 = new(25);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // tries to create a map too small. the error message from the exception caught tells the user it's too big.
            try
            {
                SmallSquareMap mapTest2 = new(3);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // creates a map of size 19 and a point. The point is on the top of the map and can't go further.
            SmallSquareMap mapTest3 = new(19);
            Point pointMapTest = new(1, 19);
            Console.WriteLine(mapTest3.Size);
            Console.WriteLine(mapTest3.Exist(pointMapTest));
            Console.WriteLine(mapTest3.Next(pointMapTest, Direction.Up));
            Console.WriteLine(mapTest3.NextDiagonal(pointMapTest, Direction.Up));
            Console.WriteLine(mapTest3.Next(pointMapTest, Direction.Down));
        }

        lab5b();
    }
}
