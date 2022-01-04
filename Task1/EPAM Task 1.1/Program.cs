using System;
using System.Collections.Generic;

namespace EPAM_Task1
{
    class Program
    {
        // Podoprigora Pavel
        // Tasks 1.1.1 - 1.1.10

        static void Main()
        {
            /*
            1.1.1 Rectangle
            Написать программу, которая определяет площадь прямоугольника со сторонами a и b. 
            Если пользователь вводит некорректные значения (отрицательные или ноль), должно выдаваться
            сообщение об ошибке. 
            Возможность ввода пользователем строки вида «абвгд» или нецелых чисел игнорировать.
            */
            Rectangle();
            static void Rectangle()
            {
                try
                {
                    Console.Write("Input a: ");
                    double a = double.Parse(Console.ReadLine());
                    if (a <= 0)
                        throw new Exception("Error");

                    Console.Write("Input b: ");
                    double b = double.Parse(Console.ReadLine());
                    if (b <= 0)
                        throw new Exception("Error");

                    double result = a * b;
                    Console.WriteLine("Square: {0}", result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            /*
            1.1.2 TRIANGLE
            Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее
            «изображение», состоящее из N строк:
            *
            **
            ***
            */
            Console.WriteLine("\n");
            Triangle();
            static void Triangle()
            {
                Console.Write("Enter N: ");
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }

            /*
            1.1.3 ANOTHER TRIANGLE
            Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее
            «изображение», состоящее из N строк:
              *
             ***
            *****
            */
            Console.WriteLine("\n");
            AnotherTriangle();
            static void AnotherTriangle()
            {
                Console.Write("Enter N: ");
                int lines = int.Parse(Console.ReadLine());

                for (int linesCount = 0; linesCount < lines; linesCount++)
                {
                    for (int i = 0; i < lines - linesCount - 1; i++)
                    {
                        Console.Write(" ");
                    }
                    for (int i = 0; i < linesCount * 2 + 1; i++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }

            /*
            1.1.4 X-MAS TREE
            Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», 
            состоящее из N треугольников:
              *
              *
             ***
              *
             ***
            *****
            */
            Console.WriteLine("\n");
            XMasTree();
            static void XMasTree()
            {
                Console.Write("Enter N: ");
                int triangles = int.Parse(Console.ReadLine());
                for (int tringCount = 1; tringCount <= triangles; tringCount++)
                {
                    int starsCount = 1;
                    for (int j = 0; j < tringCount; j++)
                    {
                        string space = new(' ', triangles - j - 1);
                        string stars = new('*', starsCount);
                        starsCount += 2;
                        Console.WriteLine(space + stars);
                    }
                }
            }

            /*
            1.1.5 SUM OF NUMBERS
            Если выписать все натуральные числа меньше 10, кратные 3 или 5, то получим 3, 5, 6 и 9. Сумма этих чисел будет равна 23. 
            Напишите программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3 или 5.
           */
            Console.WriteLine("\n");
            SumOfNumbers();
            static void SumOfNumbers()
            {
                int sum = 0;
                for (int i = 3; i < 1000; i++)
                {
                    if (i % 3 == 0 || i % 5 == 0)
                        sum += i;
                }
                Console.WriteLine("Sum of numbers divisible by 3 or 5, but < 1000 = {0}", sum);
            }

            /*
            1.1.6 FONT ADJUSTMENT
            Для форматирования текста надписи можно использовать различные начертания: полужирное, курсивное и подчёркнутое, а также их сочетания. 
            Предложите способ хранения информации о форматировании текста надписи и напишите программу, которая позволяет устанавливать и изменять начертание:

           */
            Console.WriteLine("\n");
            FontAdjustment();
            static void FontAdjustment()
            {
                List<string> settingsString = new List<string>();
                settingsString.Add("None");
                Print(settingsString);
                Console.WriteLine("Введите число:");
                int checking = int.Parse(Console.ReadLine());
                while (checking != 0)
                {
                    if (checking == 1)
                    {
                        if (settingsString.Contains("Bold"))
                        {
                            settingsString.Remove("Bold");
                            if (settingsString.Count == 0)
                                settingsString.Add("None");
                        }
                        else if (settingsString.Contains("Italic") || settingsString.Contains("Underline"))
                            settingsString.Add("Bold");
                        else if (settingsString.Contains("None"))
                        {
                            settingsString.Remove("None");
                            settingsString.Add("Bold");
                        }
                        Print(settingsString);
                    }
                    else if (checking == 2)
                    {
                        if (settingsString.Contains("Italic"))
                        {
                            settingsString.Remove("Italic");
                            if (settingsString.Count == 0)
                                settingsString.Add("None");
                        }
                        else if (settingsString.Contains("Bold") || settingsString.Contains("Underline"))
                            settingsString.Add("Italic");
                        else if (settingsString.Contains("None"))
                        {
                            settingsString.Remove("None");
                            settingsString.Add("Italic");
                        }
                        Print(settingsString);
                    }
                    else if (checking == 3)
                    {
                        if (settingsString.Contains("Underline"))
                        {
                            settingsString.Remove("Underline");
                            if (settingsString.Count == 0)
                                settingsString.Add("None");
                        }
                        else if (settingsString.Contains("Bold") || settingsString.Contains("Italic"))
                            settingsString.Add("Underline");
                        else if (settingsString.Contains("None"))
                        {
                            settingsString.Remove("None");
                            settingsString.Add("Underline");
                        }
                        Print(settingsString);
                    }
                    else if (checking == 0)
                        break;
                    else
                        Console.WriteLine("Incorrect input.");
                    checking = int.Parse(Console.ReadLine());
                }
                
            }

            static void Print(List<string> settingsString)
            {
                Console.Write("Параметры надписи: ");
                int itemСount = 0; // счетчик для запятых
                foreach (string item in settingsString)
                {
                    if (itemСount != 0)
                    {
                        Console.Write(", {0}", item);
                    }
                    else
                    {
                        Console.Write("{0}", item);
                        itemСount++;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Введите:");
                Console.WriteLine("\t1. Bold");
                Console.WriteLine("\t2. Italic");
                Console.WriteLine("\t3. Underline");
            }


            /*
            1.1.7 ARRAY PROCESSING
            Написать программу, которая генерирует случайным образом элементы массива (число элементов в массиве и их тип определяются разработчиком), 
            определяет для него максимальное и минимальное значения, сортирует массив и выводит полученный результат на экран.
            */
            Console.WriteLine("\n");
            ArrayProcessing();
            static void ArrayProcessing()
            {
                static int[] Sort(int[] array)
                {
                    int dist = array.Length / 2;
                    while (dist >= 1)
                    {
                        for (int i = dist; i < array.Length; i++)
                        {
                            int k = i;
                            while (k >= dist && array[k - dist] > array[k])
                            {
                                int temp = array[k];
                                array[k] = array[k - dist];
                                array[k - dist] = temp;
                                k -= dist;
                            }
                        }
                        dist /= 2;
                    }
                    return array;
                }

                int[] array = new int[10];
                Random rnd = new();
                int max = int.MinValue;
                int min = int.MaxValue;
                Console.Write("Array: ");
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(1, 99);
                    if (array[i] > max)
                        max = array[i];
                    if (array[i] < min)
                        min = array[i];
                    Console.Write("{0} ", array[i]);
                }
                Console.WriteLine();
                Sort(array);
                Console.Write("Sorted array: ");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write("{0} ", array[i]);
                }
                Console.Write("\nMin = {0} and Max = {1}", min, max);
            }

            /*
            1.1.8 NO POSITIVE
            Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на нули. 
            Число элементов в массиве и их тип определяются разработчиком.
            */
            Console.WriteLine("\n");
            NoPositive();
            static void NoPositive()
            {
                Console.WriteLine("\n\n");
                float[,,] array = new float[3, 3, 3];
                Random rnd = new();
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int k = 0; k < array.GetLength(1); k++)
                    {
                        for (int j = 0; j < array.GetLength(2); j++)
                        {
                            array[i, k, j] = rnd.Next(-10, 10);
                            Console.Write("{0} ", array[i, k, j]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Answer:\n");
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int k = 0; k < array.GetLength(1); k++)
                    {
                        for (int j = 0; j < array.GetLength(2); j++)
                        {
                            if (array[i, k, j] > 0)
                            {
                                array[i, k, j] = 0;
                                Console.Write("{0} ", array[i, k, j]);
                            }
                            else
                                Console.Write("{0} ", array[i, k, j]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }

            /*
            1.1.8 NON-NEGATIVE SUM
            Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве.
            Число элементов в массиве и их тип определяются разработчиком.
            */
            Console.WriteLine("\n");
            NonNegativeSum();
            static void NonNegativeSum()
            {
                Console.WriteLine();
                int[] array = new int[10];
                Random rnd = new();
                int sum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(-10, 10);
                    if (array[i] > 0) // не берем 0, т.к. он на сумму все равно не повлияет
                        sum += array[i];
                    Console.Write("{0} ", array[i]);
                }
                Console.WriteLine("\nSum of non-negative elements = {0}", sum);
            }

            /*
            1.1.10 2D ARRAY
            Элемент двумерного массива считается стоящим на чётной позиции, если сумма номеров его позиций по обеим размерностям является чётным числом
            (например, [1,1] — чётная позиция, а [1,2] — нет). Определить сумму элементов массива, стоящих на чётных позициях.
            */
            Console.WriteLine("\n");
            t2DArray();
            static void t2DArray()
            {
                Console.WriteLine();
                int[,] array = new int[3, 3];
                Random rnd = new();
                int sum = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int k = 0; k < array.GetLength(1); k++)
                    {
                        array[i, k] = rnd.Next(1, 5);
                        Console.Write("{0} ", array[i, k]);
                    }
                }
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int k = 0; k < array.GetLength(1); k++)
                    {
                        if ((i + k) % 2 == 0)
                            sum += array[i, k];
                    }
                }
                Console.WriteLine("\nSum = {0}", sum);
            }
        }
    }
}
