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

        private static bool MarkedForRemoval(String s) => s == "delete";

        private static void PrintList(List<string> someList)
        {
            foreach (string item in someList)
                Console.Write($"{item} ");
        }

        static void Main()
        {
            List<string> rangeOfPlayers = new();

            Console.WriteLine("Введите N (количество людей):");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите имена людей:");
            for (int i = 1; i <= n; i++)
                rangeOfPlayers.Add(Console.ReadLine());

            Console.WriteLine("Введите как будут вычеркиваться люди (число), например, '2' - каждый второй, '3' - каждый третий:");
            int ruleNum = int.Parse(Console.ReadLine());

            Console.Write("\nСгенерирован круг людей: ");
            PrintList(rangeOfPlayers);
            Console.WriteLine($"\nНачинаем вычеркивать каждого {ruleNum}-го.\n");

            int roundCount = 1;

            while (rangeOfPlayers.Count >= ruleNum)
            {
                Console.Write($"Раунд №{roundCount}. Вычеркнули: ");
                for (int i = ruleNum; i <= rangeOfPlayers.Count; i += ruleNum)
                {
                    Console.Write($"{rangeOfPlayers[i - 1]} ");
                    rangeOfPlayers[i - 1] = "delete";
                }
                rangeOfPlayers.RemoveAll(MarkedForRemoval);
                
                Console.Write("\n\tОстались: ");
                PrintList(rangeOfPlayers);
                Console.WriteLine();
                roundCount++;
            }

            Console.Write($"В раунде №{roundCount} некого вычеркивать! Победители(-ль):\n\t");
            PrintList(rangeOfPlayers);
        }
    }
}
