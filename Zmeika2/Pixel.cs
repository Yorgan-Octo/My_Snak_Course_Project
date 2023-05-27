using System;
using System.Drawing;
using static System.Console;

namespace Snak_Course_Project
{
    public struct Point : IDrawEndClearcs
    {
        private readonly char PointChar;
        private ConsoleColor color;

        public Point(int x, int y, char poitcahr = SettingsGame.baseChar, ConsoleColor color = SettingsGame.snakeColor)
        {
            X = x;
            Y = y;
            PointChar = poitcahr;
            this.color = color;
        }

        public int X { get; }

        public int Y { get; }

        public void Draw()
        {

            ConsoleColor oldForegColor = ForegroundColor;

            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = color;
            Console.Write(PointChar);
            Console.ForegroundColor = oldForegColor;
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
