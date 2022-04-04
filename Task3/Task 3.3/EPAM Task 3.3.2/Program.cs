using System.Text.RegularExpressions;

namespace EPAM_3_3_2
{
    public static class SuperString
    {
        // Расширьте строку следующим методом:
        //  - проверка, на каком языке написано слово в строке.Ограничимся четырьмя вариантами – Russian,
        //    English, Number and Mixed.Совокупность нескольких слов, микс символов или букв(из разных
        //    языков) относить к последней категории.Если в строке имеются пробелы, знаки препинания и
        //    прочие символы – можете также откидывать к последней категории. Словом на русском языке
        //    считайте любую последовательность русских символов (АаАа - подходит). На английском –
        //    аналогично, но с англоязычными символами.

        static Regex Russian = new(@"([А-Яа-я])");
        static Regex English = new(@"([A-Za-z])");
        static Regex Number = new(@"([0-9])");

        public static string GetLanguage(string text)
        {
            string language = String.Empty;
            if (Russian.IsMatch(text) && English.IsMatch(text) ||
                Russian.IsMatch(text) && Number.IsMatch(text) ||
                English.IsMatch(text) && Number.IsMatch(text)) 
                language = "Mixed";
            else if (English.IsMatch(text)) language = "English";
            else if (Russian.IsMatch(text)) language = "Russian";
            else if (Number.IsMatch(text)) language = "Numbers";
            return language;
        }
    }

    class ConsoleDemonstration
    {
        static void Main()
        {
            string rusText = "Привет";
            Console.WriteLine($"{rusText} - {SuperString.GetLanguage(rusText)}");
            string engText = "Hello";
            Console.WriteLine($"{engText} - {SuperString.GetLanguage(engText)}");
            string numText = "123454321";
            Console.WriteLine($"{numText} - {SuperString.GetLanguage(numText)}");
            string mixedText = "HelloПривет12345";
            Console.WriteLine($"{mixedText} - {SuperString.GetLanguage(mixedText)}");
        }
        
        
    }

}