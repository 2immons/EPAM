namespace EPAM_2._1._2
{
    abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract double GetSquare(); // площадь есть у каждого, кроме Line, у Line я его сделал = 0
        public abstract void GetInfo();
    }
}
