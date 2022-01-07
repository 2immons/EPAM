using System;
using StringAsArrayLibrary;

namespace Task
{
    class Program
    {
        static void PrintTask(StringAsArray str1, StringAsArray str2)
        {
            Console.WriteLine("String1 + string2 = {0}", str1 + str2);

            if (str1 < str2)
                Console.WriteLine("string1 < string2");
            else if (str1 > str2)
                Console.WriteLine("string1 > string2");
            else if (str1 == str2)
                Console.WriteLine("string1 = string2");

            Console.Write("Enter string to search in string1: ");
            string strForSearch = Console.ReadLine();
            int index1 = StringAsArray.IndexOf(str1, strForSearch);
            if (index1 < 0)
                Console.WriteLine("There is no '{0}' string in string1...", strForSearch);
            else
                Console.WriteLine("String '{0}' was found, it's first entry index = {1}", strForSearch, index1);

            Console.Write("Enter char to search in string1: ");
            char.TryParse(Console.ReadLine(), out char charForSearch);
            int index2 = StringAsArray.IndexOf(str1, charForSearch);
            if (index2 < 0)
                Console.WriteLine("There is no '{0}' char in string1...", charForSearch);
            else
                Console.WriteLine("Char '{0}' was found, it's first entry index = {1}", charForSearch, index2);

            // используя написанный ToString() конвертируем StringAsArray строку str2 в обычную string c#
            Console.WriteLine("Now we convert 'StringAsArray' object to normal 'C#-String' object, using str2 as an example:");
            string resultString = str2.ToString();
            Console.WriteLine(resultString);

            Console.Write("Enter new value for str1[0] element: ");
            char change = char.Parse(Console.ReadLine());
            str1.StringArray[0] = change;
            Console.WriteLine("str1: {0}", str1);
            Console.WriteLine("str1[0] element: {0}", str1.StringArray[0]);

            if (StringAsArray.IsPalindrome(str1))
                Console.WriteLine("str1 is palindrome");
            else
                Console.WriteLine("str1 is not palindrome");

            Console.WriteLine("str1 elements * 2: {0}", StringAsArray.Multiplication(str1, 2));
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