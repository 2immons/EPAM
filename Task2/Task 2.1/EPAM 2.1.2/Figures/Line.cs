namespace EPAM_2._1._2
{
    class Line : Figure
    {
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public Line(int x1, int y1, int x2, int y2)
        {
            this.X = x1;
            this.Y = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }
        public override double GetSquare() => 0;
        public override void GetInfo()
        {
            Console.Write($"[LINE] First point: {X}, {Y} / Second point: {X2}, {Y2}");
        }

    }
}
