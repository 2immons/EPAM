using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_2._1._2
{
    class Circle : Figure
    {
        public int OuterRadius { get; set; }

        public Circle(int x, int y, int outerRadius)
        {
            this.X = x;
            this.Y = y;
            this.OuterRadius = outerRadius;
        }
        public override double GetSquare() => Math.PI * OuterRadius * OuterRadius;
        public double GetLength() => 2 * Math.PI * OuterRadius;
        public override void GetInfo()
        {
            Console.Write($"[CIRCLE] Center coordinates: {X}, {Y} / Outer radius = {OuterRadius} / Square = {GetSquare()}" +
                $"\n/ Length = {GetLength()}\n");
        }
    }
}
