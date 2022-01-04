using System;
using System.Diagnostics;
namespace Program
{
    /*
    
    Напишите класс, задающий круг с указанными координатами центра, радиусом, а также свойствами,
    позволяющими узнать длину описанной окружности и площадь круга.
    
    Кроме этого, создайте класс, описывающий кольцо, заданное координатами центра, внешним и внутренним радиусами, 
    а также свойствами, позволяющими узнать площадь кольца и суммарную длину внешней и внутренней окружностей.
    
    Подумайте над взаимосвязью этих сущностей, возможной иерархией. Задача – максимально сократить повтор кода в рамках задания.
    
    По аналогии опишите классы других фигур. На их основе реализуйте собственный графический редактор,
    который взаимодействует с кольцами, окружностями, кругами, прямоугольниками, квадратами, треугольниками и линиями.
    
    Пользователю доступны следующие действия:
    - добавить фигуру (предварительно введя её характеристики)
    - вывести все фигуры на экран (вывести список фигур и их характеристик)
    - очистить холст (удалить все фигуры)
    
    Требование корректности характеристик фигур на каждом этапе неизменно, помните об этом!

    Вариант со * - добавьте к приложению пользователей. 
    Например, пользователь может вначале вводить имя, приложение, запрашивая действие, обращается по этому имени. Кроме опции
    «ВЫХОД» появляется опция «СМЕНИТЬ ПОЛЬЗОВАТЕЛЯ», требующая заново ввести имя.
    
    */
    public class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int inRadius { get; set; }
        public int outRadius { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        // для треугольника еще

    }

    public class Line : Figure
    {
        public Line(int X, int Y, int Width, int Heigth)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Heigth;
        }
    }

    public class Ring : Figure
    {
        public Ring(int X, int Y, int outRadius, int inRadius)
        {
            this.X = X;
            this.Y = Y;
            this.outRadius = outRadius;
            this.inRadius = inRadius;
        }
    }

    public class Сircumference : Figure
    {
        public Сircumference(int X, int Y, int outRadius)
        {
            this.X = X;
            this.Y = Y;
            this.outRadius = outRadius;
        }
    }

    public class Circle : Figure
    {
        public Circle(int X, int Y, int outRadius)
        {
            this.X = X;
            this.Y = Y;
            this.outRadius = outRadius;
        }
    }

    public class Rectangle : Figure
    {
        public Rectangle(int X, int Y, int Width, int Heigth)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Heigth;
        }
    }

    public class Square : Figure
    {
        public Square(int X, int Y, int Width)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
        }
    }


    public class Program
    {
        static void Info(List<Figure> listOfFigures)
        {
            if (listOfFigures.Count > 0)
                foreach (var item in listOfFigures)
                {
                    if (item.GetType() == typeof(Ring))
                        Console.WriteLine("{0} : Center: {1}, {2} ; OutR = {3}, InRadius = {4}\n", typeof(Ring), item.X, item.Y, item.outRadius, item.inRadius);
                    else if (item.GetType() == typeof(Circle))
                        Console.WriteLine("{0} : Center: {1}, {2} ; OutR = {3}\n", typeof(Circle), item.X, item.Y, item.outRadius);
                    else if (item.GetType() == typeof(Rectangle))
                        Console.WriteLine("{0} : Center: {1}, {2} ; Height = {3}, Width = {4}\n", typeof(Rectangle), item.X, item.Y, item.Height, item.Width);
                    else if (item.GetType() == typeof(Square))
                        Console.WriteLine("{0} : Center: {1}, {2} ; Height = {3}, Width = {4}\n", typeof(Square), item.X, item.Y, item.Height);
                    else if (item.GetType() == typeof(Line))
                        Console.WriteLine("{0} : First point: {1}, {2} ; Second point = {3}, {4}\n", typeof(Line), item.X, item.Y, item.X + item.Width, item.Y + item.Height);
                    else if (item.GetType() == typeof(Сircumference))
                        Console.WriteLine("{0} : Center: {1}, {2} ; OutR = {3}\n", typeof(Circle), item.X, item.Y, item.outRadius);
                }
            else Console.WriteLine("No figures added...");
        }

        static void Paint(int index)
        {
            // через что рисовать? WPF долго, плюс не "свой"
            Console.WriteLine("Cancel image - enter");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {

            }
        }

        static void Main()
        {
            List<Figure> listOfFigures = new List<Figure>();
            // можно переделать на кнопки 1-2-3 типа

            Console.WriteLine("Enter Ring (RI), Circle (C), Сircumference (CF), Rectangle (RT), Square (S), INFO, DELETE, PAINT:");
            while (true)
            {
                string function = Console.ReadLine().ToLower();
                switch (function)
                {
                    case "ri":
                        Console.WriteLine("Enter: center, radius - 'x, y, in radius, out radius'");
                        int x = int.Parse(Console.ReadLine());
                        int y = int.Parse(Console.ReadLine());
                        int outRadius = int.Parse(Console.ReadLine());
                        int inRadius = int.Parse(Console.ReadLine());
                        listOfFigures.Add(new Ring(x, y, outRadius, inRadius));
                        break;

                    case "c":
                        Console.WriteLine("Enter: center, radius - 'x, y, radius'");
                        x = int.Parse(Console.ReadLine());
                        y = int.Parse(Console.ReadLine());
                        outRadius = int.Parse(Console.ReadLine());
                        listOfFigures.Add(new Circle(x, y, outRadius));
                        break;

                    case "cf":
                        Console.WriteLine("Enter: center, radius - 'x, y, radius'");
                        x = int.Parse(Console.ReadLine());
                        y = int.Parse(Console.ReadLine());
                        outRadius = int.Parse(Console.ReadLine());
                        listOfFigures.Add(new Сircumference(x, y, outRadius));
                        break;

                    case "rt":
                        Console.WriteLine("Enter: center, sides - 'x, y, width, heigth'");
                        x = int.Parse(Console.ReadLine());
                        y = int.Parse(Console.ReadLine());
                        int width = int.Parse(Console.ReadLine());
                        int height = int.Parse(Console.ReadLine());
                        listOfFigures.Add(new Rectangle(x, y, width, height));
                        break;

                    case "s":
                        Console.WriteLine("Enter: center, radius - 'x, y, radius'");
                        x = int.Parse(Console.ReadLine());
                        y = int.Parse(Console.ReadLine());
                        width = int.Parse(Console.ReadLine());
                        listOfFigures.Add(new Square(x, y, width));
                        break;
                    case "l": // исправить снизу ввод корректнее сделать
                        Console.WriteLine("Enter: center, radius - 'x, y, radius'");
                        x = int.Parse(Console.ReadLine());
                        y = int.Parse(Console.ReadLine());
                        width = int.Parse(Console.ReadLine());
                        listOfFigures.Add(new Square(x, y, width));
                        break;

                    case "info":
                        Info(listOfFigures);
                        break;

                    case "paint":
                        if (listOfFigures.Count > 0)
                        {
                            Console.Write("Enter the index, the picture corresponding to which will be drawn: \n");
                            Info(listOfFigures);
                            int index = int.Parse(Console.ReadLine());
                            Paint(index);
                        }
                        else
                            Console.WriteLine("Nothing to paint...");
                        break;

                    case "delete":
                        if (listOfFigures.Count > 0)
                        {
                            listOfFigures.Clear();
                            Console.WriteLine("All figures were deleted");
                        }
                        else
                            Console.WriteLine("Nothing to delete...");
                        break;

                    default:
                        Console.WriteLine("Wrong input...");
                        break;
                }
                Console.WriteLine("\nEnter Ring (RI), Circle (C), Сircumference (CF), Line (L), Rectangle (RT), Square (S), INFO, DELETE, PAINT:");
            }
        }
    }
}