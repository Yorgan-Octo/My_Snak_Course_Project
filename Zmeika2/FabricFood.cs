using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snak_Course_Project
{
    public class FabricFood
    {
        Random rand = new Random();

        int genX;
        int genY;
        char[] characters = new char[]{
                'ð', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'ø', '@', 'õ', '$', '%', '&', '*', '?'
            };

        Point food;

        public FabricFood(int genX, int genY)
        {
            this.genX = genX;
            this.genY = genY;
        }

        public Point GenFood(Snake snake)
        {

            do
            {
                food = new Point(rand.Next(1, genX - 2), rand.Next(1, genY - 5), characters[rand.Next(characters.Length)], (ConsoleColor)rand.Next(1,7));
            } while (snake.Head.X == food.X && snake.Head.Y == food.Y ||
                     snake.Body.Any(b => b.X == food.X && b.Y == food.Y));

            return food;
        }
    }
}