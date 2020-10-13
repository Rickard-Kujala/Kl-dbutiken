using System;
using System.Collections.Generic;
using System.Text;

namespace Klädbutiken
{
    class NavigateMeny
    {
        
        public static int NavigateStringList(List<string> meyChoices)
        {
            int scroll = 0;
            bool done = false;
            while (!done)
            {
                int counter = 0;
                Console.Clear();
                foreach (var item in meyChoices)
                {
                    if (counter == scroll)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(item);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else
                    {
                        Console.WriteLine(item);

                    }
                    counter++;

                }
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.A && scroll == meyChoices.Count-1)
                {
                    scroll = meyChoices.Count-1;

                }
                else if (key == ConsoleKey.Z && scroll == 0)
                {
                    scroll = 0;

                }

                else if (key == ConsoleKey.A)
                {
                    scroll++;

                }
                else if (key == ConsoleKey.Z)
                {
                    scroll--;

                }
                else if (key == ConsoleKey.Enter)
                {
                    done = true;
                }

            }
            return scroll;
        }
        public static int NavigatePlaggList(List<Plagg> plaggList)
        {
            int scroll = 0;
            bool done = false;
            while (!done)
            {
                int counter = 1;
                Console.Clear();
                foreach (var plagg in plaggList)
                {
                    if (counter == scroll)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Typ av plagg: {plagg.Type}\nFärg: {plagg.Colour}" +
                       $"\nStorlek: {plagg.Size}\nPris: {plagg.Price}");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("-------------------------------");
                    }
                    else
                    {
                        Console.WriteLine($"Typ av plagg: {plagg.Type}\nFärg: {plagg.Colour}" +
                       $"\nStorlek: {plagg.Size}\nPris: {plagg.Price}");
                        Console.WriteLine("-------------------------------");
                    }


                    counter++;
                }

                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.A && scroll ==plaggList.Count)
                {
                    scroll = plaggList.Count;
                }
                else if (key == ConsoleKey.Z && scroll == 0)
                {
                    scroll = 0;
                }

                else if (key == ConsoleKey.A)
                {
                    scroll++;
                }
                else if (key == ConsoleKey.Z)
                {
                    scroll--;
                }
                else if (key == ConsoleKey.Enter)
                {
                    done = true;
                }
            }
            return scroll;
        }
    }
    
}
