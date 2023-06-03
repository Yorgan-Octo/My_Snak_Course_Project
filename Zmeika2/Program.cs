using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

namespace Snak_Course_Project
{
    class Program
    {
        static void Main()
        {
            SettingsGame.InitSetingsGame();
            GameSnake gameSnake = new GameSnake();
            Saving.Dowload();

            string[] menu = { "Start Game", "Table of Leaders", "Exit" };
            int menuNam = 0;


            while (true)
            {
                Console.Clear();

                for (int i = 0; i < menu.Length; i++)
                {
                    if (i == menuNam)
                    {
                        Console.SetCursorPosition(10, 20 + i);
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(menu[i]);
                        Console.ResetColor();
                        continue;
                    }

                    Console.SetCursorPosition(10, 20 + i);
                    Console.WriteLine(menu[i]);
                }

                ConsoleKeyInfo tap = Console.ReadKey();

                if (tap.Key == ConsoleKey.DownArrow)
                    ++menuNam;
                else if (tap.Key == ConsoleKey.UpArrow)
                    --menuNam;
                else if (tap.Key == ConsoleKey.Enter)
                {
                    switch (menuNam)
                    {
                        case 0:
                            {
                                gameSnake.StartGame();
                                Thread.Sleep(2000);
                                Console.ReadKey();
                                break;
                            }
                        case 1:
                            {
                                Saving.DrawRecords();
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                Saving.Save();
                                Environment.Exit(0);
                                break;
                            }
                    }
                }

                if (menuNam > menu.Length - 1)
                    menuNam = 0;
                else if (menuNam < 0)
                    menuNam = menu.Length - 1;

            }

        }
    }
}
