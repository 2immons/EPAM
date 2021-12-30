using System;

namespace EPAM_Task_1._2
{
    class Program
    {
        static void Main()
        {
            /* 
            1.2.1. AVERAGES
            Напишите программу, которая определяет среднюю длину слова во введённой текстовой строке.
            Учтите, что символы пунктуации на длину слов влиять не должны.
            */
            Averages();
            static void Averages()
            {
                Console.WriteLine("Enter string: ");
                string inputString = Console.ReadLine();
                char[] separators = { ' ', ',', '.', '!', '?', ':', '-' };
                string[] words = inputString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                int sum = 0;
                foreach (var item in words)
                {
                    sum += item.Length;
                }
                Console.WriteLine((float)sum / words.Length);
            }

            /*
            1.2.2. DOUBLER
            Напишите программу, которая удваивает в первой введённой строке все символы, 
            принадлежащие второй введённой строке.
            */
            Console.WriteLine();
            Doubler();
            static void Doubler()
            {
                Console.WriteLine("Enter string 1:");
                string inputString1 = Console.ReadLine();
                Console.WriteLine("Enter string 2:");
                string inputString2 = Console.ReadLine();
                string resultString = string.Empty;
                foreach (char elem in inputString1)
                {
                    if (inputString2.Contains(elem))
                    {
                        resultString += elem;
                        resultString += elem;
                    }
                    else
                    {
                        resultString += elem;
                    }
                }
                inputString2 = resultString;
                Console.WriteLine("Answer: {0}", inputString2);
            }

            /*
            1.2.3. LOWERCASE
            Напишите программу, которая считает количество слов, начинающихся с маленькой буквы. 
            Предлоги, союзы и междометия считаются словами. 
            Финальную точку в предложении (как и любой другой знак) можно не учитывать.
            */
            Console.WriteLine();
            Lowercase();
            static void Lowercase()
            {
                Console.WriteLine("Enter string: ");
                string inputString = Console.ReadLine();
                char[] separators = { ' ', ',', '.', '!', '?', ':', '-' };
                string[] words = inputString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                int count = 0;
                foreach (var item in words)
                {
                    if (item == item.ToLower())
                        count += 1;
                }
                Console.WriteLine(count);
            }

            /*
            1.2.4. VALIDATOR
            Напишите программу, которая заменяет первую букву первого слова в предложении на заглавную. 
            В качестве окончания предложения можете считать только «.|?|!». Многоточие и «?!» можете опустить.

            */
            Console.WriteLine();
            Validator();
            static void Validator()

            {
                Console.WriteLine("Enter string: ");
                string inputString = Console.ReadLine();

                // если строка не оканчивается знаком препиняния, т.е. вводится, например, вот так: "привет. как дела", 
                // то добавим "." в конце, чтобы получилось: "привет, как дела."
                if (!inputString.EndsWith(".") && !inputString.EndsWith("!") && !inputString.EndsWith("?"))
                {
                    inputString += ".";
                }

                string resultString = string.Empty;
                char[] separators = { '!', '?', '.' };
                char[] charsFromSentence;
                string[] sentences = inputString.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < sentences.Length; i++)
                {
                    sentences[i] = sentences[i].Trim();
                    charsFromSentence = sentences[i].ToCharArray();
                    charsFromSentence[0] = Char.ToUpper(charsFromSentence[0]);
                    foreach (char elem in charsFromSentence)
                    {
                        resultString += elem;
                    }
                    resultString += " ";
                }

                int start = 0;
                int index;
                string separator;
                while (inputString.Length > start)
                {
                    index = inputString.IndexOfAny(separators, start);
                    separator = inputString.Substring(index, 1);
                    switch (separator)
                    {
                        case ".":
                            resultString = resultString.Insert(index, ".");
                            break;
                        case "!":
                            resultString = resultString.Insert(index, "!");
                            break;
                        case "?":
                            resultString = resultString.Insert(index, "?");
                            break;
                        default:
                            break;
                    }
                    start = index + 1;
                }
                Console.WriteLine(resultString);
            }
        }
    }
}

