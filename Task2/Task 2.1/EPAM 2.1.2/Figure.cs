using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_2._1._2
{
    public class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int inRadius { get; set; }
        public int outRadius { get; set; }
        public int side1 { get; set; }
        public int side2 { get; set; }

    }

    public class Line : Figure
    {
        public Line(int X, int Y, int side1, int side2)
        {
            this.X = X;
            this.Y = Y;
            this.side1 = side1;
            this.side2 = side2;
        }
    }

    public class Circle : Figure
    {
        public Circle(int X, int Y, int outRadius)
        {
            this.X = X;
            this.Y = Y;
            this.outRadius = outRadius;
        }

        public double CircleSquare()
        {
            return Math.PI * outRadius * outRadius;
        }
        public double CircleLength()
        {
            return 2 * Math.PI * outRadius + 2 * Math.PI * inRadius;
        }
    }
    public class Ring : Circle
    {
        public Ring(int X, int Y, int outRadius, int inRadius) : base(X, Y, outRadius)
        {
            this.X = X;
            this.Y = Y;
            this.outRadius = outRadius;
            this.inRadius = inRadius;
        }

        public double CircleFullLength()
        {
            return 2 * Math.PI * outRadius + 2 * Math.PI * inRadius;
        }
    }

    public class Сircumference : Circle
    {
        public Сircumference(int X, int Y, int outRadius) : base(X, Y, outRadius)
        {
            this.X = X;
            this.Y = Y;
            this.outRadius = outRadius;
        }
    }

    public class Square : Figure
    {
        public Square(int X, int Y, int side1)
        {
            this.X = X;
            this.Y = Y;
            this.side1 = side1;
        }

        public double RectSquare()
        {
            return side1 * side1;
        }
    }

    public class Rectangle : Square
    {
        public Rectangle(int X, int Y, int side1, int side2) : base(X, Y, side1)
        {
            this.X = X;
            this.Y = Y;
            this.side1 = side1;
            this.side2 = side2;
        }

        public double SSquare()
        {
            return side1 * side2;
        }
    }
}
