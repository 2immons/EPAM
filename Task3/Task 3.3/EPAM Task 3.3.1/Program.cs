namespace EPAM_3_3_1
{
    public static class SuperArray
    {
        // Расширьте массивы чисел методом, производящим действия с каждым конкретным элементом.
        // Действие должно передаваться в метод с помощью делегата.
        // Кроме указанного функционала выше, добавьте методы расширения для поиска:
        //  - суммы всех элементов;
        //  - среднего значения в массиве;
        //  - самого часто повторяемого элемента;

        // На данном этапе LINQ использовать разрешается.
        // Консольный интерфейс-демонстрация для данного задания не обязателен,
        // но постарайтесь сделать интерфейсы ваших сущностей максимально понятными и готовыми к тестам.

        public static void Foreach<T>(this T[] array, Func<T, T> func)
        {
            if (func == null) return;
            
            for (int i = 0; i < array.Length; i++)
                array[i] = func.Invoke(array[i]);
        }

        public static int GetSum(this int[] arr)
        {
            return arr.Sum();
        }

        public static float GetSum(this float[] arr)
        {
            return arr.Sum();
        }

        public static double GetSum(this double[] arr)
        {
            return arr.Sum();
        }

        public static double GetAverageValue(this int[] arr)
        {
            return arr.Average();
        }
        public static double GetAverageValue(this float[] arr)
        {
            return arr.Average();
        }

        public static double GetAverageValue(this double[] arr)
        {
            return arr.Average();
        }

        // и так далее с другими типами...

        public static T TheMostFrequentElem<T>(this T[] arr)
        {
            return arr.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault().Key;
        }
    }
}
