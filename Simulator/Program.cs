namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        static void lab5a()
        {
            Point pointTest1 = new(10, 25);
            Point pointTest2 = new(8, 12);
            Rectangle rectangleTest1 = new(pointTest1, pointTest2);
            Console.WriteLine(rectangleTest1);
            try
            {
                Rectangle rectangleTest2 = new(5, 10, 5, 20);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Point pointTest3 = new(9, 22);
            Console.WriteLine(rectangleTest1.Contains(pointTest3));

        }

        lab5a();
    }
}
