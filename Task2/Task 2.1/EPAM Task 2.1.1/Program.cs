using System;

namespace StringAsArray
{
    class StringAsArray
    {
        /*

        Напишите собственный класс, описывающий строку как массив символов. 
        Реализуйте для этого класса типовые операции (сравнение, конкатенация, поиск символов, конвертация из/в массив символов). 
        Подумайте, какие функции вы бы добавили к имеющемуся в .NET функционалу строк (достаточно 1-2 функций).

        Вариант со * - подумайте над использованием в своем классе функционала индексатора (indexer). 
            Реализуйте его для своей строки.

        Вариант с ** - попробуйте создать из своей сборки переносимую библиотеку (DLL). 
            Осмысленно назовите её, а также namespace и сам класс. Попробуйте использовать написанный вами класс в другом проекте.

        */

        public char[] StringArray { get; set; }

        public StringAsArray(string str) // конвертация в массив символов
        {
            StringArray = str.ToCharArray();

        }

        public static string ToString (StringAsArray str) // конвертация из массива символов в строку
        {
            return str.StringArray.ToString();
        }

        public static int Length(StringAsArray str) // поиск длинны массива символов
        {
            return str.StringArray.Length;
        }

        public static StringAsArray operator +(StringAsArray str1, StringAsArray str2) // перегрузка оператора +
        {
            char[] temp = new char[Length(str1) + Length(str2)];

            int k;
            for (k = 0; k < Length(str1); k++)
            {
                temp[k] = str1.StringArray[k];
            }
            for (int j = k; j < k + Length(str2); j++)
            {
                temp[j] = str2.StringArray[j - Length(str1)];
            }
            string vs = new string(temp);
            return new StringAsArray(vs);
        }

        public static bool operator <(StringAsArray str1, StringAsArray str2) // перегрузка оператора <
        {
            if (Length(str1) < Length(str2))
            {
                return true;
            }
            else
                return false;
        }

        public static bool operator >(StringAsArray str1, StringAsArray str2) // перегрузка оператора <
        {
            if (Length(str1) > Length(str2))
            {
                return true;
            }
            else
                return false;
        }

        public override string ToString() // перегрузка для вывода
        {
            string str = string.Empty;
            for (int i = 0; i < StringArray.Length; i++)
            {
                str += StringArray[i];
            }
            return str;
        }

        public static int IndexOf(StringAsArray str, string sStr) // поиск первого вхождения в массив символов строки
        {
            return str.ToString().IndexOf(sStr);

        }

        public static int IndexOf(StringAsArray str, char sChar) // поиск первого вхождения в массив символов символа (char)
        {
            return str.ToString().IndexOf(sChar);
        }

        // 2-3 функции, которые я бы добавил к существующему функционалу строк C#?????
        // в мой класс или в String??

        // * функционал индексатора indexer

        // ** создать из своей сборки переносимую библиотеку (DLL). 
        // осмысленно назвать её, а также namespace и сам класс.
        // создать другой проект, где будем использовать созданный StringAsArray класс

    }
    class Program {

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