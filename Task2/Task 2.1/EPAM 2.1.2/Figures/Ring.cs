namespace EPAM_2._1._2
{
    class Ring : Circle
    {
        public int InnerRadius { get; set; }

        public Ring(int x, int y, int innerRadius, int outerRadius) : base(x, y, outerRadius)
        {
            this.X = x;
            this.Y = y;
            this.OuterRadius = outerRadius;
            this.InnerRadius = innerRadius;
        }
        public override double GetSquare() => Math.PI * OuterRadius * OuterRadius;
        public double GetTotalLength()
        {
            if (InnerRadius != OuterRadius)
                return 2 * Math.PI * OuterRadius + 2 * Math.PI * InnerRadius;
            else return GetLength();
        }
        public override void GetInfo()
        {
            Console.Write($"[RING] Center coordinates: {X}, {Y} / Outer radius = {OuterRadius}, Inner radius = {InnerRadius}" +
                $"\n/ Square = {GetSquare()} / Length = {GetLength()} / Total length = {GetTotalLength()}\n");
        }
    }
}
