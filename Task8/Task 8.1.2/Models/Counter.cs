namespace Task_8._1._2.Models
{
    public class Counter
    {
        public static int Value { get; private set; }
        public static void Increase() => Value++;
    }
}