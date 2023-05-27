using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Snak_Course_Project
{
    class Program
    {
        static void Main()
        {
            SettingsGame.InitSetingsGame();
            GameSnake gameSnake = new GameSnake();

            while (true)
            {
                gameSnake.StartGame();
                Thread.Sleep(2000);

                Console.ReadKey();
            }
        }
    }
}
