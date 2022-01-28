namespace EPAM_Task_2._2._1
{
    abstract class GameElement
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
    }
    abstract class MapObject : GameElement { }
    abstract class Character : GameElement
    {
        abstract public void Move(GameField field);

    }

    class Obstacle : MapObject
    {
        public Obstacle(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Symbol = '|';
        }
    }
    class Bonus : MapObject
    {
        public Bonus(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Symbol = '$';
        }
    }

    class AdrenalinePoint : MapObject
    {
        public AdrenalinePoint(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Symbol = '+';
        }
    }

    class Player : Character
    {
        public int AdrenalinePoints { get; set; }
        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = 'P';
            this.AdrenalinePoints = 100;
        }

        public override void Move(GameField field)
        {
            ConsoleKey Key = Console.ReadKey().Key;
            switch (Key)
            {
                case ConsoleKey.A:
                    X += 0;
                    Y += -1;
                    break;
                case ConsoleKey.D:
                    X += 0;
                    Y += 1;
                    break;
                case ConsoleKey.W:
                    X += -1;
                    Y += 0;
                    break;
                case ConsoleKey.S:
                    X += 1;
                    Y += 0;
                    break;
                default:
                    break;
            }
        }
    }

    class Zombie : Character
    {
        public Zombie(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.Symbol = 'Z';
        }
        public override void Move(GameField field)
        {
            // алгоритм зомби
            if (this.X > 1 && this.Y > 1 && this.X < field.MapWidth - field.BorderSize && this.Y < field.MapHeigth - field.BorderSize)
            {
                this.X -= 1;
            }
        }
    }
    class Wolf : Character
    {
        public Wolf(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.Symbol = 'W';
        }
        public override void Move(GameField field)
        {
            // алгоритм волка
            if (this.X > 1 && this.Y > 1 && this.X < field.MapWidth - field.BorderSize && this.Y < field.MapHeigth - field.BorderSize)
            {
                this.X += 1;
            }
        }
    }
}
