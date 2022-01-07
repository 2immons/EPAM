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

    }

    public class Line : Figure
    {
        public Line(int X, int Y, int Width, int Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
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

        public double CircleSquare()
        {
            return Math.PI * outRadius * outRadius;
        }
    }
    public class Ring : Circle
    {
        public Ring(int X, int Y, int outRadius, int inRadius) : base (X, Y, outRadius)
        {
            this.X = X;
            this.Y = Y;
            this.outRadius = outRadius;
            this.inRadius = inRadius;
        }

        public double CircleLength()
        {
            return 2 * Math.PI * outRadius + 2 * Math.PI * inRadius;
        }
    }

    public class Сircumference : Circle
    {
        public Сircumference(int X, int Y, int outRadius) : base(X, Y, outRadius)
        {
            this.X = X;
            this.Y = Y;
            this.outRadius = outRadius;
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

        public double RectangleSquare()
        {
            return Width*Width;
        }
    }

    public class Rectangle : Square
    {
        public Rectangle(int X, int Y, int Width, int Height) : base(X, Y, Width)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }

        public double RectangleSquare()
        {
            return Width * Height;
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
                        Console.WriteLine("{0} : Center: {1}, {2} ; OutR = {3}, InRadius = {4}", typeof(Ring), item.X, item.Y, item.outRadius, item.inRadius);
                    else if (item.GetType() == typeof(Circle))
                        Console.WriteLine("{0} : Center: {1}, {2} ; OutR = {3}", typeof(Circle), item.X, item.Y, item.outRadius);
                    else if (item.GetType() == typeof(Rectangle))
                        Console.WriteLine("{0} : Center: {1}, {2} ; Height = {3}, Width = {4}", typeof(Rectangle), item.X, item.Y, item.Height, item.Width);
                    else if (item.GetType() == typeof(Square))
                        Console.WriteLine("{0} : Center: {1}, {2} ; Side = {3}", typeof(Square), item.X, item.Y, item.Height);
                    else if (item.GetType() == typeof(Line))
                        Console.WriteLine("{0} : First point: {1}, {2} ; Second point = {3}, {4}", typeof(Line), item.X, item.Y, item.Width, item.Height);
                    else if (item.GetType() == typeof(Сircumference))
                        Console.WriteLine("{0} : Center: {1}, {2} ; OutR = {3}", typeof(Circle), item.X, item.Y, item.outRadius);
                }
            else Console.WriteLine("No figures added...");
        }

        static int PrintWindow(string name)
        {
            Console.WriteLine("{0}, enter:", name);
            Console.WriteLine("1) Add\n2) Print a list of figures\n3) Delete all figures\n4) Exit");
            int index = GetConsoleIntValue();
            return index;
        }

        static int GetConsoleIntValue() // ввод int с консоли с провркой
        {
            string value = Console.ReadLine();

            if (Int32.TryParse(value, out int result))
                return result;
            return 0;
        }

        static void Main()
        {
            List<Figure> listOfFigures = new List<Figure>();

            Console.Write("Etner name: ");
            string name = Console.ReadLine();
            if (name == "0" || name.ToLower() == "turn off")
            {
                Console.WriteLine("Turning off...");
                return;
            }
            else
            {
                int index = PrintWindow(name);
                while (true)
                {
                    if (index == 1)
                    {
                        Console.Write("Enter Ring (RI), Circle (C), Сircumference (CF), Rectangle (RT), Square (S), Line (L): ");
                        string function = Console.ReadLine().ToLower();
                        switch (function)
                        {
                            case "ri":
                                Console.WriteLine("Enter: center, radius - 'x, y, in radius, out radius'");
                                int x = GetConsoleIntValue();
                                int y = GetConsoleIntValue();
                                int outRadius = GetConsoleIntValue();
                                int inRadius = GetConsoleIntValue();
                                listOfFigures.Add(new Ring(x, y, outRadius, inRadius));
                                break;

                            case "c":
                                Console.WriteLine("Enter: center, radius - 'x, y, radius'");
                                x = GetConsoleIntValue();
                                y = GetConsoleIntValue();
                                outRadius = GetConsoleIntValue();
                                listOfFigures.Add(new Circle(x, y, outRadius));
                                break;

                            case "cf":
                                Console.WriteLine("Enter: center, radius - 'x, y, radius'");
                                x = GetConsoleIntValue();
                                y = GetConsoleIntValue();
                                outRadius = GetConsoleIntValue();
                                listOfFigures.Add(new Сircumference(x, y, outRadius));
                                break;

                            case "rt":
                                Console.WriteLine("Enter: center, sides - 'x, y, width, heigth'");
                                x = GetConsoleIntValue();
                                y = GetConsoleIntValue();
                                int width = GetConsoleIntValue();
                                int height = GetConsoleIntValue();
                                listOfFigures.Add(new Rectangle(x, y, width, height));
                                break;

                            case "s":
                                Console.WriteLine("Enter: center, side - 'x, y, side'");
                                x = GetConsoleIntValue();
                                y = GetConsoleIntValue();
                                width = GetConsoleIntValue();
                                listOfFigures.Add(new Square(x, y, width));
                                break;
                            case "l":
                                Console.WriteLine("Enter 2 points: (x,y), (x,y)");
                                x = GetConsoleIntValue();
                                y = GetConsoleIntValue();
                                width = GetConsoleIntValue();
                                height = GetConsoleIntValue();
                                listOfFigures.Add(new Line(x, y, width, height));
                                break;

                            default:
                                Console.WriteLine("Wrong input...");
                                break;
                        }
                    }

                    else if (index == 2)
                    {
                        Info(listOfFigures);
                    }

                    else if (index == 3)
                    {
                        if (listOfFigures.Count > 0)
                        {
                            listOfFigures.Clear();
                            Console.WriteLine("All figures were deleted");
                        }
                        else
                            Console.WriteLine("Nothing to delete...");
                    }

                    else if (index == 4)
                    {
                        Console.WriteLine("Enter your name:");
                        name = Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("Wrong input...");
                    }

                    index = PrintWindow(name);
                }
            }
        }
    }
}