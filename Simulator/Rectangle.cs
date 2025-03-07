﻿namespace Simulator;

public class Rectangle
{
    public readonly int X1, Y1, X2, Y2;

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        (X1, Y1, X2, Y2) = (Math.Min(x1, x2), Math.Min(y1, y2), Math.Max(x1, x2), Math.Max(y1, y2));
        if (X1 == X2 || Y1 == Y2) 
        {
            throw new ArgumentException("Invalid coordinates - the rectangle doesn't have a surface.");
        }
    }

    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y)
    {
    }


    public bool Contains(Point point) => (X1 <= point.X && point.X <= X2 && Y1 <= point.Y && point.Y <= Y2);

    public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";

}
