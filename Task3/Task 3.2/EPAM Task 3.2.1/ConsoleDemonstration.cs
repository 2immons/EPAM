namespace EPAM_3_2_1
{
    class ConsoleDemonstration
    {
        static void Main()
        {
            // some tests
            var arr = new DynamicArray<int>();
            Console.WriteLine(arr.Capacity);
            Console.WriteLine(arr.Length);
            arr.Add(12);
            arr.Add(12);
            Console.WriteLine(arr[1]);
            arr.Insert(1, 10);
            Console.WriteLine(arr[1]);
            arr.Remove(1);
            Console.WriteLine(arr[1]);
            Console.WriteLine(arr.Capacity);
            Console.WriteLine(arr.Length);
        }

    }
}
