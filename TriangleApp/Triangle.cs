using System.Diagnostics;

namespace TriangleApp;

public class Triangle
{
    private Coordinate[] _points;
    private double[] _sides;
    private double _delta;

    public Triangle(Coordinate[] points)
    {
        this._points = points;
        this._sides = new double[3];
        this._delta = 0;

        CalcTriangleSides();
    }

    public double[] GetSides()
    {
        return _sides;
    }

    //Use precision in calculations 
    public Triangle WithPrecision(double v)
    {
        this._delta = v;
        return this;
    }

    //Find all triangle sides
    private void CalcTriangleSides()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            Coordinate p1 = _points[i];
            Coordinate p2;

            if (i < _points.Length - 1)
            {
                p2 = _points[i + 1];
            }
            else
            {
                p2 = _points[0];
            }

            _sides[i] = CalcSide(p1, p2);
        }
    }

    //calculate triangle side 
    private static double CalcSide(Coordinate p1, Coordinate p2)
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
        for (int i = 0; i < _sides.Length; i++)
        {
            if (_sides[i] > max)
            {
                max = _sides[i];
                longestIdx = i;
            }
        }

        return longestIdx;
    }

    //find the index of the triangle first leg 
    private int Leg1Idx()
    {
        double min = _sides[0];
        int leg1Idx = 0;
        for (int i = 0; i < _sides.Length; i++)
        {
            if (_sides[i] < min)
            {
                min = _sides[i];
                leg1Idx = i;
            }
        }

        return leg1Idx;
    }

    //find the index of the triangle second leg 
    private int Leg2Idx(int firstIdx, int secondIdx)
    {
        int leg2Idx = 0;
        for (int i = 0; i < _sides.Length; i++)
        {
            if (!i.Equals(firstIdx) && !i.Equals(secondIdx))
            {
                leg2Idx = i;
            }
        }

        return leg2Idx;
    }

    public bool IsEquilateral()
    {
        double max = 0;
        for (int i = 0; i < _sides.Length; i++)
        {
            if (_sides[i] > max)
            {
                max = _sides[i];
            }
        }

        return ((max - _sides[0]) <= _delta && (max - _sides[1]) <= _delta && (max - _sides[2]) <= _delta);
    }

    public bool IsIsosceles()
    {
        int longestIdx = LongestSideIdx();
        int leg1Idx = Leg1Idx();
        int leg2Idx = Leg2Idx(longestIdx, leg1Idx);


        if (_sides[longestIdx] - _sides[leg2Idx] <= _delta || _sides[leg2Idx] - _sides[leg1Idx] <= _delta)
        {
            return true;
        }

        return false;
    }

    public bool IsRight()
    {
        int hypotenuseIdx = LongestSideIdx();
        int leg1Idx = Leg1Idx();
        int leg2Idx = Leg2Idx(LongestSideIdx(), leg1Idx);

        double hypotenuse = Math.Pow(_sides[hypotenuseIdx], 2);
        double legs = Math.Pow(_sides[leg1Idx], 2) + Math.Pow(_sides[leg2Idx], 2);

        if ((hypotenuse - legs) <= _delta && (hypotenuse - legs) > 0)
        {
            return true;
        }


        return false;
    }

    public double CalcPerimeter()
    {
        double perimeter = 0;
        for (int i = 0; i < _sides.Length; i++)
        {
            perimeter += _sides[i];
        }

        return perimeter;
    }

    public void EvenNumbers()
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