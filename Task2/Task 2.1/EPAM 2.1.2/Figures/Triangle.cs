namespace EPAM_2._1._2
{
    class Triangle : Figure
    {
        public int Side1 { get; set; }
        public int Side2 { get; set; }
        public int Side3 { get; set; }
        public Triangle(int x, int y, int side1, int side2, int side3)
        {
            this.X = x;
            this.Y = y;
            this.Side1 = side1;
            this.Side2 = side2;
            this.Side3 = side3;
        }
        public override double GetSquare()
        {
            double perimetr = Side1 + Side2 + Side3;
            // используем формулу Герона:
            return Math.Sqrt(perimetr * perimetr - Side1 * perimetr - Side2 * perimetr - Side3);
        }
        public override void GetInfo()
        {
            Console.Write($"[TRIANGLE] Center coordinates: {X}, {Y} / Sides = {Side1} ; {Side2} ; {Side3} / Square = {GetSquare()}");
        }
    }
}
