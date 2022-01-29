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

        public int Length => this.StringArray.Length;

        private char[] StringArray = new char[30];
        public char this[int i]
        {
            get => StringArray[i]; 
            set 
            {
                StringArray[i] = value; 
            }
        }

        public StringAsArray(string str)
        {
            StringArray = str.ToCharArray();
        }

        public StringAsArray()
        {
            StringArray = string.Empty.ToCharArray();
        }

        public static string ToString(StringAsArray str)
        {
            return str.ToString();
        }

        public static StringAsArray operator +(StringAsArray str1, StringAsArray str2) // перегрузка оператора +
        {
            char[] temp = new char[str1.Length + str2.Length];

            int k;
            for (k = 0; k < str1.Length; k++)
            {
                temp[k] = str1[k];
            }
            for (int j = k; j < k + str2.Length; j++)
            {
                temp[j] = str2[j - str1.Length];
            }
            string vs = new(temp);
            return new StringAsArray(vs);
        }

        public static StringAsArray operator +(StringAsArray str1, char str2) // перегрузка оператора +
        {
            char[] temp = new char[str1.Length + 1];

            int k;
            for (k = 0; k < str1.Length; k++)
            {
                temp[k] = str1[k];
            }
            temp[k] = str2;
            string vs = new(temp);
            return new StringAsArray(vs);
        }

        public static bool operator <(StringAsArray str1, StringAsArray str2) // перегрузка оператора <
        {
            if (str1.Length < str2.Length)
            {
                return true;
            }
            else
                return false;
        }

        public static bool operator >(StringAsArray str1, StringAsArray str2) // перегрузка оператора >
        {
            if (str1.Length > str2.Length)
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

        public int IndexOf(string sStr) => this.ToString().IndexOf(sStr);

        public int IndexOf(char sChar) => this.ToString().IndexOf(sChar);


        // добавочные к функционалу функции:
        public bool IsPalindrome()
        {
            for (int i = 0; i < this.Length / 2; i++)

                if (this[i] != this[this.Length - i - 1])
                    return false;
            return true;
        }

        public StringAsArray Multiplication(int index)
        {
            StringAsArray resultStr = new();
            for (int i = 0; i < this.Length; i++)
            {
                for (int j = 0; j < index; j++)
                {
                    resultStr += this[i];
                }
            }
            return resultStr;
        }

    }
}