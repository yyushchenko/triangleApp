
namespace TriangleApp
{
    internal class TriangleApp
    {
        public static void Main(string[] args)
        {


            Coordinate[] coords = new Coordinate[3];

            string[] points = {"A", "B", "C" };
            for (int i = 0; i < 3; i++)
            {
                coords[i] = ReadCoordinate(points[i]);
            }
            
            Triangle t = new Triangle(coords).WithPrecision(0.4);
            
            Run(t);
        }

        private static void Run(Triangle t)
        {
        
            Console.Write("Sides: ");
            foreach (var s in t.GetSides())
            {
                Console.Write(s + ", ");
            }

            Console.WriteLine();

            Console.WriteLine(t.IsEquilateral() == true ? "Triangle IS Equilateral" : "Triangle IS NOT Equilateral");
        
            Console.WriteLine(t.IsIsosceles() == true ? "Triangle IS Isosceles" : "Triangle IS NOT Isosceles");
        
            Console.WriteLine(t.IsRight() == true ? "Triangle IS Right" : "Triangle IS NOT Right");
        
            Console.WriteLine("Perimeter is " + t.CalcPerimeter());
        
            t.EvenNumbers();
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
 