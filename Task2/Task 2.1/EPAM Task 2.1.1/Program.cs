using System;
using StringAsArrayLibrary;

namespace Task
{
    class Program
    {
        // метод демонстрации функционала - PrintTask
        static void PrintTask(StringAsArray str1, StringAsArray str2)
        {
            Console.WriteLine("String1 + string2 = {0}", str1 + str2);

            if (str1 < str2)
                Console.WriteLine("String1 < string2");
            else if (str1 > str2)
                Console.WriteLine("String1 > string2");
            else if (str1 == str2)
                Console.WriteLine("String1 = string2");

            // тут нужно как-то исправить ввод, чтобы проверять не нулевые:

            Console.Write("Enter string to search in string1: ");
            string strForSearch = Console.ReadLine();
            int index1 = StringAsArray.IndexOf(str1, strForSearch); // вот тут
            if (index1 < 0)
                Console.WriteLine("There is no '{0}' string in string1...", strForSearch);
            else
                Console.WriteLine("String '{0}' was found, it's first entry index = {1}", strForSearch, index1);

            Console.Write("Enter char to search in string1: ");
            char.TryParse(Console.ReadLine(), out char charForSearch); // и тут и чутьпониже тоэе
            int index2 = StringAsArray.IndexOf(str1, charForSearch);
            if (index2 < 0)
                Console.WriteLine("There is no '{0}' char in string1...", charForSearch);
            else
                Console.WriteLine("Char '{0}' was found, it's first entry index = {1}", charForSearch, index2);

            // используя написанный ToString() конвертируем StringAsArray строку str2 в обычную string c#
            Console.WriteLine("Now we convert 'StringAsArray' object to normal 'C#-String' object, using str2 as an example:");
            string resultString = str2.ToString();
            Console.WriteLine(resultString);
        }

        static void Main()
        {
            Console.Write("Enter string1 = ");
            string inputStr1 = Console.ReadLine();
            StringAsArray str1 = new StringAsArray(inputStr1);
            Console.Write("Enter string2 = ");
            string inputStr2 = Console.ReadLine();
            StringAsArray str2 = new StringAsArray(inputStr2);

            PrintTask(str1, str2);
        }
    }
}