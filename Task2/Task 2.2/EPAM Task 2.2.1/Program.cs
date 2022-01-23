using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Game
    {
        private const int mapWidth = 40;
        private const int mapHeigth = 20;
        private const ConsoleColor BorderColor = ConsoleColor.Gray;
        
        static void Main()
        {
            SetWindowSize(mapWidth,
                          mapHeigth);
            SetBufferSize(mapWidth,
                          mapHeigth);
            CursorVisible = false;

            DrawBorder();

            Character Person = new Character(3,4);

            DrawCharacter();

            ReadKey();
        }

        static void DrawCharacter()
        {
            int x = Character.Move()[0];
            int y = Character.Move()[1];    



            for (int i = 0; i < mapWidth; i++)
            {
                new Pixel(i, 0, BorderColor).Draw();
                new Pixel(i, mapHeigth - 1, BorderColor).Draw();
            }
            for (int i = 0; i < mapHeigth; i++)
            {
                new Pixel(0, i, BorderColor).Draw();
                new Pixel(mapWidth - 1, i, BorderColor).Draw();
            }
        }
        static void DrawBorder()
        {
            for (int i = 0; i < mapWidth; i++)
            {
                new Pixel(i, 0, BorderColor).Draw();
                new Pixel(i, mapHeigth - 1, BorderColor).Draw();
            }
            for (int i = 0; i < mapHeigth; i++)
            {
                new Pixel(0, i, BorderColor).Draw();
                new Pixel(mapWidth - 1,i, BorderColor).Draw();
            }
        }

        // игрок - P
        // зомби - Z
        // препятствие - #
        // бонус - $
    }

    public struct Pixel
    {
        public Pixel(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;

        }
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; }
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('@');

        }
        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
            }
        }

    class Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char symbol = 'P';

        public Character(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public static int[] Move()
        {
            int[] coordinates = new int[2];
            ConsoleKey Key = Console.ReadKey().Key;
            switch (Key)
            {
                case ConsoleKey.A:
                    coordinates[0] = -1;
                    coordinates[1] = 0;
                    break;
                case ConsoleKey.D:
                    coordinates[0] = 1;
                    coordinates[1] = 0;
                    break;
                case ConsoleKey.W:
                    coordinates[0] = 0;
                    coordinates[1] = 1;
                    break;
                case ConsoleKey.S:
                    coordinates[0] = 0;
                    coordinates[1] = -1;
                    break;
                default:
                    break;
            }
            return coordinates;
        }
    }
}

//class Zombie : Character
//{
//    public int X { get; set; }
//    public int Y { get; set; }
//    public char Symbol { get; set; }
//}

//class Player : Character
//{
//    public int X { get; set; }
//    public int Y { get; set; }
//    public char Symbol { get; set; }
//}
