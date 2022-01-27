using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_2._1._2
{
    class Square : Figure
    {
        public int Side1 { get; set; }
        public Square(int x, int y, int side1)
        {
            this.X = x;
            this.Y = y;
            this.Side1 = side1;
        }

        public override double GetSquare() => Side1 * Side1;
        public override void GetInfo()
        {
            Console.Write($"[SQUARE] Center coordinates: {X}, {Y} / Side = {Side1} / Square = {GetSquare()}\n");
        }

    }
}
