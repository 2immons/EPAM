namespace StringAsArrayLibrary
{
    public class StringAsArray
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
        
        private char[] arr = new char[30];
        public char this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        public StringAsArray(string str) //конвертация в массив символов
        {
            StringArray = str.ToCharArray();
        }

        public static string ToString(StringAsArray str) // конвертация из массива символов в строку
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

        public static int IndexOf(StringAsArray str, string sStr) => str.ToString().IndexOf(sStr);

        public static int IndexOf(StringAsArray str, char sChar) => str.ToString().IndexOf(sChar);


        // добавочные к функционалу функции:
        public static bool IsPalindrome(StringAsArray str)
        {
            for (int i = 0; i < Length(str) / 2; i++)

                if (str.StringArray[i] != str.StringArray[Length(str) - i - 1])
                    return false;
            return true;
        }

        public static StringAsArray Multiplication(StringAsArray str, int index)
        {
            string resultStr = string.Empty;
            for (int i = 0; i < Length(str); i++)
            {
                for (int j = 0; j < index; j++)
                {
                    resultStr += str.StringArray[i];
                }
            }
            StringAsArray result = new StringAsArray(resultStr);
            return result;
        }

    }
}