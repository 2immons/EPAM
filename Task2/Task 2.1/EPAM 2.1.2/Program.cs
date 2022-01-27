namespace EPAM_2._1._2
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


    public class Program
    {
        static int GetConsoleIntValue()
        {
            string value = Console.ReadLine();
            if (Int32.TryParse(value, out int result))
                return result;
            return 0;
        }

        static int PrintMenu(string name)
        {
            Console.WriteLine("{0}, enter:", name);
            Console.WriteLine("1) Create figure\n2) Print all figures\n3) Delete all figures\n4) Change user\n5) Turn off");
            int index = GetConsoleIntValue();
            return index;
        }

        static void CreateFigure(int figureType, List<Figure> listOfFigures)
        {
            switch (figureType)
            {
                case 1:
                    Console.WriteLine("Square - Enter: x, y, side1:");
                    int x = GetConsoleIntValue();
                    int y = GetConsoleIntValue();
                    int side1 = GetConsoleIntValue();
                    listOfFigures.Add(new Square(x, y, side1));
                    break;
                case 2:
                    Console.WriteLine("Rectangle - Enter: x, y, side1, side2:");
                    x = GetConsoleIntValue();
                    y = GetConsoleIntValue();
                    side1 = GetConsoleIntValue();
                    int side2 = GetConsoleIntValue();
                    listOfFigures.Add(new Rectangle(x, y, side1, side2));
                    break;
                case 3:
                    Console.WriteLine("Line - Enter: x1, y1; x2, y2:");
                    x = GetConsoleIntValue();
                    y = GetConsoleIntValue();
                    int x2 = GetConsoleIntValue();
                    int y2 = GetConsoleIntValue();
                    listOfFigures.Add(new Line(x, y, x2, y2));
                    break;
                case 4:
                    Console.WriteLine("Circle - Enter: x, y, outer radius:");
                    x = GetConsoleIntValue();
                    y = GetConsoleIntValue();
                    int outerRadius = GetConsoleIntValue();
                    listOfFigures.Add(new Circle(x, y, outerRadius));
                    break;
                case 5:
                    Console.WriteLine("Ring - Enter: x, y, inner radius, outer radius:");
                    x = GetConsoleIntValue();
                    y = GetConsoleIntValue();
                    int innerRadius = GetConsoleIntValue();
                    outerRadius = GetConsoleIntValue();
                    listOfFigures.Add(new Ring(x, y, innerRadius, outerRadius));
                    break;
                case 6:
                    Console.WriteLine("Triangle - Enter: x, y, side1, side2, side3:");
                    x = GetConsoleIntValue();
                    y = GetConsoleIntValue();
                    side1 = GetConsoleIntValue();
                    side2 = GetConsoleIntValue();
                    int side3 = GetConsoleIntValue();
                    listOfFigures.Add(new Triangle(x, y, side1, side2, side3));
                    break;
                default:
                    Console.WriteLine("Wrong input...");
                    break;
            }
        }

        static void PrintAllFigures(List<Figure> listOfFigures)
        {
            if (listOfFigures.Count > 0)
                foreach (var item in listOfFigures)
                {
                    item.GetInfo();
                    Console.WriteLine();
                }
            else Console.WriteLine("No figures added...");
        }

        static string GetAccountName()
        {
            Console.Write("Etner account name: ");
            string value = Console.ReadLine();
            if (!String.IsNullOrEmpty(value)) 
                return value;
            return "Standart Username";
        }

        static void Main()
        {
            List<Figure> listOfFigures = new();

            string name = GetAccountName();

            int index;
            while (true)
            {
                index = PrintMenu(name);
                if (index == 1)
                {
                    Console.WriteLine("Choose:");
                    Console.Write("1) Square, \n2) Rectangle, \n3) Line, \n4) Circle, \n5) Ring, \n6) Triangle\n");
                    int figureType = GetConsoleIntValue();
                    CreateFigure(figureType, listOfFigures);
                }

                else if (index == 2) PrintAllFigures(listOfFigures);

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

                else if (index == 4) name = GetAccountName();
                else if (index == 5) return;
                else Console.WriteLine($"Wrong input... Try again, {name}...");
            }
        }
    }
}
