namespace EPAM_Task_2._2._1
{

    // Цель игры - собрать бонусы ($ на карте), постоянно пополняя свои Adrenaline Points (+ на карте)
    // и поддерживая Adrenaline Points > 0, иначе проигрыш.
    // Проиграть также можно, если выйти за карту/умереть от рук монстра (Z/W на карте) или же удариться о препятствие (| на карте)

    class Game
    {
        private static readonly List<Character> characters = new();
        private static readonly List<MapObject> objects = new();
        static void DrawField(GameField field, Player player)
        {
            for (int i = 0; i < field.MapWidth; i++)
            {
                for (int k = 0; k < field.MapHeigth; k++)
                {
                    Console.Write(field.gameMap[i,k]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Adrenaline points = {player.AdrenalinePoints}");
        }

        static bool CheckForGameContinuation(Player player, GameField field)
        {
            if (player.AdrenalinePoints < 0)
            {
                Console.Clear();
                Console.WriteLine("Adrenaline is < 0\nGame over!");
                return false;
            }

            if (player.X == 0 || player.X == field.MapWidth - 1 || player.Y == 0 || player.Y == field.MapHeigth - 1)
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
                    Console.WriteLine("You were eaten by a monster!\nGame over!");
                    return false;
                }
            }

            foreach (var item in objects)
            {
                if (item.X == player.X && item.Y == player.Y)
                {
                    if (item is Obstacle)
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
                Console.WriteLine("You have collected all the bonuses!\nYou won!");
                return false;
            }
        }

        static GameField MapInit(Player player, GameField field)
        {
            for (int i = 0; i < field.MapWidth; i++)
            {
                for (int k = 0; k < field.MapHeigth; k++)
                {
                    if (i == 0 || i == field.MapWidth - 1 || k == 0 || k == field.MapHeigth - 1)
                        field.gameMap[i, k] = field.BorderSign;
                    else field.gameMap[i, k] = ' ';
                }
            }

            field.gameMap[player.X, player.Y] = player.Symbol;
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
                    field.gameMap[objects[i].X, objects[i].Y] = objects[i].Symbol;

                }
            }

            foreach (var item in characters)
                field.gameMap[item.X, item.Y] = item.Symbol;

            return field;
        }

        static void CharacterMovements(Player player, GameField field)
        {
            player.Move(field);
            foreach (var item in characters)
                item.Move(field);
        }

        static void CreateCharacters(GameField field)
        {
            Random rnd = new();
            int MapMaxWidthPoint = field.MapWidth - field.BorderSize;
            int MapMaxHeigthPoint = field.MapHeigth - field.BorderSize;

            // добавление бонусов
            int bonusesCount = 3;
            for (int i = 0; i < bonusesCount; i++)
                objects.Add(new Bonus(rnd.Next(field.BorderSize, MapMaxWidthPoint), rnd.Next(field.BorderSize, MapMaxHeigthPoint)));

            // добавление Adrenaline Points на карту
            int adrenalinePointsCount = 3;
            for (int i = 0; i < adrenalinePointsCount; i++)
                objects.Add(new AdrenalinePoint(rnd.Next(field.BorderSize, MapMaxWidthPoint), rnd.Next(field.BorderSize, MapMaxHeigthPoint)));

            // добавление препятствий на карту
            int obstacleCount = 3;
            for (int i = 0; i < obstacleCount; i++)
                objects.Add(new Obstacle(rnd.Next(field.BorderSize, MapMaxWidthPoint), rnd.Next(field.BorderSize, MapMaxHeigthPoint)));

            // добавление враждебных персонажей на карту
            int charactersCount = 2;
            for (int i = 0; i < charactersCount; i++)
            {
                characters.Add(new Zombie(rnd.Next(field.BorderSize, MapMaxWidthPoint), rnd.Next(field.BorderSize, MapMaxHeigthPoint)));
                characters.Add(new Wolf(rnd.Next(field.BorderSize, MapMaxWidthPoint), rnd.Next(field.BorderSize, MapMaxHeigthPoint)));
            }
        }

        static void Main()
        {
            const int mapHeigth = 30;
            const int mapWidth = 30;
            const char borderSign = '|';
            const int borderSize = 2;

            GameField field = new(mapHeigth, mapWidth, borderSign, borderSize);

            Player player = new(field.MapWidth / 2, field.MapHeigth/2); // задаем положение игрока примерно в центре карты

            CreateCharacters(field);

            DrawField(MapInit(player, field), player);
            while (CheckForGameContinuation(player, field))
            {
                CharacterMovements(player, field);
                Console.Clear();
                DrawField(MapInit(player, field), player);
            }
        }
    }
}
