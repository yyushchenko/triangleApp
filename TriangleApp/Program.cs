// See https://aka.ms/new-console-template for more information
namespace TriangleApp
{
    internal class TriangleApp
    {

        static void Main(string[] args)
        {


            Coordinate[] coords = new Coordinate[3];

            string[] points = {"A", "B", "C" };
            for (int i = 0; i < 3; i++)
            {
                coords[i] = ReadCoordinate(points[i]);
            }
            
            Triangle t = new Triangle(coords);
            
            t.Run();
        }


        private static Coordinate ReadCoordinate (string pointName)
        {
            Console.WriteLine("Enter X coordinate of " + pointName + ":");
            string inputX = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(inputX))
            {
                throw new ArgumentException("Coordinates must be numeric");
            }
            double x = Convert.ToDouble(inputX);
            
            Console.WriteLine("Enter Y coordinate of " + pointName + ":");
            string inputY = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(inputY))
            {
                throw new ArgumentException("Coordinates must be numeric");
            }

            double y = Convert.ToDouble(inputY);

            return new Coordinate(x, y);
        }
        
    }
}
 