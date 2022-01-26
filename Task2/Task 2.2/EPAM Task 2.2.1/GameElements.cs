namespace Game
{
    abstract class GameElements
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
    }
    abstract class Object : GameElements { }
    abstract class Character : GameElements
    {
        abstract public void Move();

    }

    class Obstacle : Object
    {
        public Obstacle(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Symbol = '|';
        }
    }
    class Bonus : Object
    {
        public Bonus(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Symbol = '$';
        }
    }

    class AdrenalinePoint : Object
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
        public Player()
        {
            this.X = 15;
            this.Y = 15;
            this.Symbol = 'P';
            this.AdrenalinePoints = 100;
        }

        public static int[] KeyPressCheck()
        {
            int[] coordinates = new int[2];
            ConsoleKey Key = Console.ReadKey().Key;
            switch (Key)
            {
                case ConsoleKey.A:
                    coordinates[0] = 0;
                    coordinates[1] = -1;
                    break;
                case ConsoleKey.D:
                    coordinates[0] = 0;
                    coordinates[1] = 1;
                    break;
                case ConsoleKey.W:
                    coordinates[0] = -1;
                    coordinates[1] = 0;
                    break;
                case ConsoleKey.S:
                    coordinates[0] = 1;
                    coordinates[1] = 0;
                    break;
                default:
                    break;
            }
            return coordinates;
        }

        override public void Move()
        {
            int[] coordinates = KeyPressCheck();
            this.X += coordinates[0];
            this.Y += coordinates[1];
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
        override public void Move()
        {
            // алгоритм зомби
            if (this.X > 1 && this.Y > 1 && this.X < 28 && this.Y < 28)
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
        override public void Move()
        {
            // алгоритм волка
            if (this.X > 1 && this.Y > 1 && this.X < 28 && this.Y < 28)
            {
                this.X += 1;
            }
        }
    }
}
