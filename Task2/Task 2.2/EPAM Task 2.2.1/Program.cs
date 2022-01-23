namespace Game
{

    // Цель игры - собрать бонусы ($ на карте), постоянно пополняя свое HP (+ на карте)
    // и поддерживая HP > 0, иначе проигрыш.
    // Проиграть также можно, если выйти за карту/умереть от рук монстра (Z/W на карте) или же удариться о препятствие (| на карте)

    class Game
    {
        private const int mapWidth = 30;
        private const int mapHeigth = 30;

        static void DrawField(char[,] field, Player player)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int k = 0; k < mapHeigth; k++)
                {
                    Console.Write(field[i, k]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Adrenaline points = {player.AdrenalinePoints}");
        }

        static bool CheckForLoseOrVictory(List<Character> characters, List<Object> objects, Player player)
        {
            if (player.AdrenalinePoints < 0)
            {
                Console.Clear();
                Console.WriteLine("Adrenaline is < 0\nGame over!");
                return false;
            }

            if (player.X == 0 || player.X == mapWidth - 1 || player.Y == 0 || player.Y == mapHeigth - 1)
            {
                Console.Clear();
                Console.WriteLine("You left the field\nGame over!");
                return false;
            }

            foreach (var item in characters)
            {
                if (item.X == player.X && item.Y == player.Y)
                {
                    Console.Clear();
                    Console.WriteLine("You was eaten by monster\nGame over!");
                    return false;
                }
            }

            foreach (var item in objects)
            {
                if (item.X == player.X && item.Y == player.Y)
                {
                    Type itemType = item.GetType();
                    if (itemType.Equals(typeof(Obstacle)))
                    {
                        Console.Clear();
                        Console.WriteLine("You hit an obstacle!\nGame over!");
                        return false;
                    }
                }
            }

            int count = 0;
            foreach (var item in objects)
            {
                if (item.GetType() == typeof(Bonus))
                    count++;
            }
            if (count > 0)
                return true;
            else
            {
                Console.Clear();
                Console.WriteLine("You collected all bonuses!\nYou won!");
                return false;
            }
        }

        static char[,] MapInit(char[,] field, List<Character> characters, List<Object> objects, Player player)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int k = 0; k < mapHeigth; k++)
                {
                    if (i == 0 || i == mapWidth - 1 || k == 0 || k == mapHeigth - 1)
                        field[i, k] = '|';
                    else field[i, k] = ' ';
                }
            }

            field[player.X, player.Y] = player.Symbol;
            player.AdrenalinePoints -= 2;

            for (int i = objects.Count - 1; i >= 0; i--)
            {
                if (objects[i].X == player.X && objects[i].Y == player.Y)
                {
                    Type itemType = objects[i].GetType();
                    if (itemType.Equals(typeof(AdrenalinePoint)))
                    {
                        player.AdrenalinePoints += 10;
                        objects.Remove(objects[i]);
                    }
                    else if (itemType.Equals(typeof(Bonus)))
                    {
                        objects.Remove(objects[i]);
                    }
                }
                else
                {
                    field[objects[i].X, objects[i].Y] = objects[i].Symbol;

                }
            }

            objects.RemoveAll(item => item.X == 35);

            foreach (var item in characters)
                field[item.X, item.Y] = item.Symbol;

            return field;
        }

        static void CharacterMovements(List<Character> characters, Player player)
        {
            player.Move();
            foreach (var item in characters)
                item.Move();
        }

        static void Main()
        {
            Player player = new();

            Random rnd = new();

            List<Character> characters = new()
            {
                new Zombie(rnd.Next(1, 28), rnd.Next(1, 28)),
                new Wolf(rnd.Next(1, 28), rnd.Next(1, 28)),
                new Zombie(rnd.Next(1, 28), rnd.Next(1, 28)),
                new Wolf(rnd.Next(1, 28), rnd.Next(1, 28))
            };

            List<Object> objects = new()
            {
                new Bonus(rnd.Next(1, 28), rnd.Next(1, 28)),
                new Bonus(rnd.Next(1, 28), rnd.Next(1, 28)),
                new Bonus(rnd.Next(1, 28), rnd.Next(1, 28)),

                new AdrenalinePoint(rnd.Next(1, 28), rnd.Next(1, 28)),
                new AdrenalinePoint(rnd.Next(1, 28), rnd.Next(1, 28)),
                new AdrenalinePoint(rnd.Next(1, 28), rnd.Next(1, 28)),

                new Obstacle(rnd.Next(1, 28), rnd.Next(1, 28)),
                new Obstacle(rnd.Next(1, 28), rnd.Next(1, 28)),
                new Obstacle(rnd.Next(1, 28), rnd.Next(1, 28)),
                new Obstacle(rnd.Next(1, 28), rnd.Next(1, 28)),
                new Obstacle(rnd.Next(1, 28), rnd.Next(1, 28))
            };

            char[,] field = new char[mapWidth, mapHeigth];

            DrawField(MapInit(field, characters, objects, player), player);
            while (CheckForLoseOrVictory(characters, objects, player))
            {
                CharacterMovements(characters, player);
                Console.Clear();
                DrawField(MapInit(field, characters, objects, player), player);
            }
        }
    }
}
