using System.Diagnostics;

namespace TriangleApp;

public class Triangle
{
    private Coordinate[] points;
    private double[] sides;

    public Triangle(Coordinate[] points)
    {
        this.points = points;
        this.sides = new double[3];

        CalcTriangleSides();
    }

    public void Run()
    {
        
        Console.Write("Sides: ");
        foreach (var s in sides)
        {
            Console.Write(s + ", ");
        }

        Console.WriteLine();

        Console.WriteLine(IsEquilateral() == true ? "Triangle IS Equilateral" : "Triangle IS NOT Equilateral");
        
        Console.WriteLine(IsIsosceles() == true ? "Triangle IS Isosceles" : "Triangle IS NOT Isosceles");
        
        Console.WriteLine(IsRight() == true ? "Triangle IS Right" : "Triangle IS NOT Right");
        
        Console.WriteLine("Perimeter is " + CalcPerimeter());
        
        EvenNumbers();
    }

    //Find all triangle sides
    private void CalcTriangleSides()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Coordinate p1 = points[i];
            Coordinate p2;

            if (i < points.Length - 1)
            {
                p2 = points[i + 1];
            }
            else
            {
                p2 = points[0];
            }

            sides[i] = calcSide(p1, p2);
        }
    }

    //calculate triangle side 
    private static double calcSide(Coordinate p1, Coordinate p2)
    {
        double side = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        if (side == 0)
        {
            throw new ArgumentException("Coordinates are not correct, side can't be 0");

        }
        
        return side;
    }

    //Find index of the longest side 
    private int LongestSideIdx()
    {
        int longestIdx = 0;
        double max = 0;
        for (int i = 0; i < sides.Length; i++)
        {
            if (sides[i] > max)
            {
                max = sides[i];
                longestIdx = i; 
                
            }
            
        }

        return longestIdx;
    }

    //find the index of the triangle first leg 
    private int Leg1Idx()
    {
        double min = sides[0];
        int leg1Idx = 0; 
        for (int i = 0; i < sides.Length; i++)
        {
            if (sides[i] < min)
            {
                min = sides[i];
                leg1Idx = i;
            }

        }

        return leg1Idx;
    }

    //find the index of the triangle second leg 
    private int Leg2Idx(int firstIdx, int secondIdx)
    {
        int leg2Idx = 0;
        for (int i = 0; i < sides.Length; i++)
        {
            if (!i.Equals(firstIdx) && !i.Equals(secondIdx))
            {
                leg2Idx = i;
            }
        }

        return leg2Idx;
    }

    private bool IsEquilateral()
    {
        double delta = 0.4;
        double max = 0;
        for (int i = 0; i < sides.Length; i++)
        {
            if (sides[i] > max)
            {
                max = sides[i];
            }
        }

        return ((max - sides[0]) <= delta && (max - sides[1]) <= delta && (max - sides[2]) <= delta);
    }

    private bool IsIsosceles()
    {
        double delta = 0.2;
        int longestIdx = LongestSideIdx();
        int  leg1Idx = Leg1Idx();
        int leg2Idx = Leg2Idx(longestIdx, leg1Idx);


        if (sides[longestIdx] - sides[leg2Idx] <= delta || sides[leg2Idx]-sides[leg1Idx] <= delta)
        {
            return true; 
        }
    
        return false; 
    }

    private bool IsRight()
    {
        double delta = 0.4; 
        int hypotenuseIdx = LongestSideIdx();
        int leg1Idx = Leg1Idx();
        int leg2Idx = Leg2Idx(LongestSideIdx(),leg1Idx); 
        
        double hypotenuse = Math.Pow(sides[hypotenuseIdx], 2);
        double legs = Math.Pow(sides[leg1Idx], 2) + Math.Pow(sides[leg2Idx], 2);
        
        if((hypotenuse - legs) <= delta && (hypotenuse - legs) > 0){

            return true;
        }


        return false;
    }

    private double CalcPerimeter()
    {
        double perimeter = 0;
        for (int i = 0; i < sides.Length; i++)
        {
            perimeter += sides[i];
        }

        return perimeter;
    }

    private void EvenNumbers()
    {
        int perimeter = Convert.ToInt32(CalcPerimeter());
        int[] numbers = new int[perimeter];
        
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i;
        }

        foreach (var t in numbers)
        {
            if (t % 2 == 0)
            {
                Console.WriteLine(t);
            }
        }

    }
}
