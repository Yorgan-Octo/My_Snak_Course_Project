using System;
using System.Collections.Generic;
using System.Text;

namespace Snak_Course_Project
{
    public static class SettingsGame
    {
        private const bool _cursorVisible = false;

        public const int speedGame = 150;

        public const ConsoleColor baseColor = ConsoleColor.Blue;
        public const ConsoleColor bgColor = ConsoleColor.Black;

        public const ConsoleColor snakeColor = ConsoleColor.DarkMagenta;
        public const ConsoleColor wallColor = ConsoleColor.DarkRed;

        public const char baseChar = '@';
        public const char baseCharWall = '@';

        public static int MapWidth { get; }
        public static int MapHeight { get; }


        static SettingsGame()
        {
            MapWidth = 50;
            MapHeight = 35;
        }

        public static void InitSetingsGame()
        {
            Console.SetWindowSize(MapWidth, MapHeight);
            Console.SetBufferSize(MapWidth, MapHeight);
            Console.ForegroundColor = baseColor;
            Console.BackgroundColor = bgColor;
            Console.CursorVisible = _cursorVisible;

        }


    }
}
