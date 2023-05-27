using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Snak_Course_Project
{
    public class GameSnake
    {
        private int score = 0;

        public void StartGame()
        {

            Console.Clear();
            DrawBoard();


            FabricFood fabricFood = new FabricFood(SettingsGame.MapWidth, SettingsGame.MapHeight);
            Snake snake = new Snake(new Random().Next(4, SettingsGame.MapWidth - 4), new Random().Next(4, SettingsGame.MapHeight - 8));


            Point food = fabricFood.GenFood(snake);
            food.Draw();

            ConsoleKey currentMovement = ConsoleKey.RightArrow;

            var sw = new Stopwatch(); //для измерения прошедшего времени

            while (true)
            {

                DrawScore();

                sw.Restart();

                ConsoleKey oldMovement = currentMovement;

                while (sw.ElapsedMilliseconds <= (SettingsGame.speedGame - score))
                {
                    if (currentMovement == oldMovement)
                        currentMovement = ReadMovement(currentMovement);
                }

                sw.Restart();

                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Move(currentMovement, true);

                    food = fabricFood.GenFood(snake);
                    food.Draw();

                    score++;

                    Console.Beep(2000, 300);
                }
                else
                    snake.Move(currentMovement);

                if (snake.Head.X == SettingsGame.MapWidth - 1 || snake.Head.X == 0 || snake.Head.Y == SettingsGame.MapHeight - 4 || snake.Head.Y == 0
                    || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                    break;

            }

            snake.Clear();
            food.Clear();

            DrawWinInfo();

            Console.Beep(350, 500);
        }
        private ConsoleKey ReadMovement(ConsoleKey currentDirection)
        {
            if (!Console.KeyAvailable)
                return currentDirection;

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.RightArrow && currentDirection != ConsoleKey.LeftArrow)
                currentDirection = ConsoleKey.RightArrow;
            else if (key == ConsoleKey.LeftArrow && currentDirection != ConsoleKey.RightArrow)
                currentDirection = ConsoleKey.LeftArrow;
            else if (key == ConsoleKey.UpArrow && currentDirection != ConsoleKey.DownArrow)
                currentDirection = ConsoleKey.UpArrow;
            else if (key == ConsoleKey.DownArrow && currentDirection != ConsoleKey.UpArrow)
                currentDirection = ConsoleKey.DownArrow;

            return currentDirection;
        }
        private void DrawScore()
        {
            Console.SetCursorPosition(2, SettingsGame.MapHeight - 2);
            Console.WriteLine("Очки: " + score);
        }

        private void DrawWinInfo()
        {
            Console.SetCursorPosition(SettingsGame.MapWidth / 3, SettingsGame.MapHeight / 2);
            Console.WriteLine($"Ти труп! Очки: {score}");
        }

        private void DrawBoard()
        {
            for (int i = 0; i < SettingsGame.MapWidth; i++)
            {
                new Point(i, 0, SettingsGame.baseCharWall, SettingsGame.wallColor).Draw();
                new Point(i, SettingsGame.MapHeight - 4, SettingsGame.baseCharWall, SettingsGame.wallColor).Draw();
            }

            for (int i = 0; i < SettingsGame.MapHeight; i++)
            {
                new Point(0, i, SettingsGame.baseCharWall, SettingsGame.wallColor).Draw();
                new Point(SettingsGame.MapWidth - 1, i, SettingsGame.baseCharWall, SettingsGame.wallColor).Draw();
            }
        }

    }
}
