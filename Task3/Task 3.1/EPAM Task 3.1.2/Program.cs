namespace EPAM_3_1_2
{
    /*
    Задан английский текст. 
    Ваша задача понять, какие слова автор «любит» больше всего и подловить его на однообразности речи. 
    Или, наоборот, похвалить за разнообразие. Для каждого слова в тексте указать, сколько раз оно встречается.

    Подумайте, имеет ли значение регистр, какие разделители могут использоваться в тексте.

    Попробуйте использовать свои наработки из Task 1.2. «String, not Sting».

    Ввод и вывод также придумайте сами. В рамках консоли постарайтесь создать приятный и
    понятный интерфейс – вашей программой будет пользоваться профессионал журналистики.
    */

    class WordCounter
    {
        private readonly Dictionary<string, int> wordsDict;

        public WordCounter()
        {
            wordsDict = new Dictionary<string, int>();
        }

        public void Add(string keyWord)
        {
            if (wordsDict.ContainsKey(keyWord))
                wordsDict[keyWord] += 1;
            else
                wordsDict.Add(keyWord, 1);
        }

        private bool CheckForPoorVocabulary()
        {
            // если в тексте больше 5 повторений одного и того же слова - текст однообразный,
            // иначе - текст нормальный
            foreach (var item in wordsDict)
                if (item.Value > 5)
                    return false;
            return true;
        }

        public void PrintResult()
        {
            Console.WriteLine();
            if (!CheckForPoorVocabulary())
                Console.WriteLine("Poor word variety. More than 5 repetitions of the same word.");
            else
                Console.WriteLine("Good job! Good word variety!");

            Console.WriteLine();
            
            foreach (var i in wordsDict)
                Console.WriteLine($"\t'{i.Key}' : {i.Value} times.");
        }
    }

    class Program
    {
        static void Main()
        {
            char[] separators = { '.', '?', '!', ' ', ';', ':', ',', '-', '(', ')' };

            Console.WriteLine("Hello!\nEnter your text to check it for vocabulary diversity:");
            string text = Console.ReadLine();

            // тестовый текст, чтобы не придумывать свой: 

            //string text = "A reindeer is a northern animal. In the summertime, reindeer are hot in the taiga, " +
            //    "but in the mountains it is cold even in July. Reindeer are as if made for the northern expanses, " +
            //    "stiff winds, long frosty nights. A deer easily runs forward through the taiga, pushes bushes under it, " +
            //    "swims across fast rivers. The reindeer does not sink, because each of its hair is a long tube, which is " +
            //    "filled with air inside. The deer's nose is covered with silvery fur. If there were no fur on the nose, the " +
            //    "reindeer would freeze it off.";

            if (text == string.Empty)
            {
                Console.WriteLine("You didn't write anything\nTry again...");
                Main();
            }
            else
            {
                string[] words = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                WordCounter counter = new();

                foreach (var word in words)
                    counter.Add(word);

                counter.PrintResult();
            }
        }
    }
}
