namespace EPAM_2._1._2
{
    class Rectangle : Square
    {
        public int Side2 { get; set; }
        public Rectangle(int x, int y, int side1, int side2) : base(x, y, side1)
        {
            this.X = x;
            this.Y = y;
            this.Side1 = side1;
            this.Side2 = side2;
        }
        public override double GetSquare() => Side1 * Side2;
        public override void GetInfo()
        {
            Console.Write($"[RECTANGLE] Center coordinates: {X}, {Y} / Sides = {Side1}, {Side2} / Square = {GetSquare()}\n");
        }
    }
}
