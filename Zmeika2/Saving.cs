using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Snak_Course_Project
{
    public static class Saving
    {

        public static Stack<int> rocerds = new Stack<int>();

        public static void Save()
        {
            using (StreamWriter writer = new StreamWriter("stack.txt"))
            {
                foreach (int element in rocerds)
                {
                    writer.WriteLine(element);
                }
            }
        }

        public static void Dowload()
        {
            using (StreamReader reader = new StreamReader("stack.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    rocerds.Push((Convert.ToInt32(line)));
                }

                Sort();
            }
        }

        public static void DrawRecords()
        {
            Console.Clear();
            foreach (var item in rocerds)
            {
                Console.WriteLine($".........................................{item} points");
            }

        }

        private static void Sort()
        {
            List<int> tempList = rocerds.ToList();
            tempList.Sort();
            rocerds = new Stack<int>(tempList);
        }




    }
}
