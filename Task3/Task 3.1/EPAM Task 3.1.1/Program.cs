namespace EPAM_Task_3._1._1
{
    class Program
    {
        /*
        В кругу стоят N человек, пронумерованных от 1 до N. 
        При ведении счета по кругу (каждый «раунд») вычёркивается каждый второй человек, пока не останется один. 
        Составить программу, моделирующую процесс.

        Добавить возможность пользователю задавать N, а также простой консольный вывод, поэтапно указывающий результат.

        Вариант со * - добавить пользователю возможность указывать, какой по номеру человек будет
        вычеркиваться в каждом «раунде». В примере выше – каждый второй. Пользователь может задать,
        что вычеркиваться будет каждый: третий, пятый, шестнадцатый и так далее. Предусмотреть
        варианты, когда «вычеркивание» невозможно, оповестить пользователя об этом.
        Невозможно вычеркнуть человека с номером больше, чем есть в кругу.
        */

        private static bool ForDelete(String s)
        {
            return s == "delete";
        }
        static void Main()
        {
            Console.WriteLine("Введите N:");
            int n = int.Parse(Console.ReadLine());
            List<string> list = new();
            Console.WriteLine("Введите имена людей:");
            for (int i = 0; i < n; i++)
                list.Add(Console.ReadLine());

            Console.WriteLine("\nСгенерирован круг людей. Начинаем вычеркивать каждого второго.");

            int roundCount = 1;
            while (true)
            {
                Console.Write($"Раунд {roundCount}. Вычеркнули: ");
                for (int i = 0; i < list.Count; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.Write($"{list[i]} ");
                        list[i] = "delete";
                    }
                }
                Console.WriteLine();
                list.RemoveAll(ForDelete);
                Console.Write($"После раунда {roundCount} круг выглядит так:\n\t");
                if (list.Count == 1)
                {
                    Console.WriteLine($"Больше некого вычеркивать. {list[0]} - победитель!");
                    break;
                }
                foreach (var item in list)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
                roundCount++;
            }
        }
    }
}
