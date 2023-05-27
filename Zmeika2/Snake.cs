using System;
using System.Collections.Generic;

namespace Snak_Course_Project
{
    public class Snake : IDrawEndClearcs
    {
        public Point Head { get; private set; }

        public Queue<Point> Body { get; } = new Queue<Point>();

        public Snake(int initialX, int initialY, int bodyLength = 3)
        {

            Head = new Point(initialX, initialY);

            for (int i = bodyLength; i >= 0; i--)
            {
                Body.Enqueue(new Point(Head.X - i - 1, initialY));
            }

            Draw();
        }

        public void Move(ConsoleKey direction, bool eat = false)
        {
            Clear();

            Body.Enqueue(new Point(Head.X, Head.Y));
            if (!eat)
                Body.Dequeue();

            Head = direction switch
            {
                ConsoleKey.RightArrow => new Point(Head.X + 1, Head.Y),
                ConsoleKey.LeftArrow => new Point(Head.X - 1, Head.Y),
                ConsoleKey.UpArrow => new Point(Head.X, Head.Y - 1),
                ConsoleKey.DownArrow => new Point(Head.X, Head.Y + 1),
                _ => Head
            };

            Draw();
        }

        public void Draw()
        {
            Head.Draw();

            foreach (Point pixel in Body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();

            foreach (Point pixel in Body)
            {
                pixel.Clear();
            }
        }
    }
}
