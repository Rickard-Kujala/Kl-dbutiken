using System;
using System.Collections.Generic;
using System.Threading;

namespace Klädbutiken
{
    class Store
    {
        static int TryCatch(int minvalue, int maxvalue)
        {
            bool succes = false;
            while (!succes)
            {
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    if (choice < minvalue || choice > maxvalue)
                    {
                        Console.WriteLine($"{choice} är inte tillgängligt, försök igen.");
                        succes = false;
                    }
                    else
                    {
                        Console.WriteLine("Sparat!");
                        Thread.Sleep(100);
                        succes = true;
                        return choice;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Ogiltigt val..");
                }

            }
            return -1;


        }
        static void AddCloth(List<Plagg> store)
        {
            Console.WriteLine("Lägg till ett plagg: ");

            Console.WriteLine("Tröja: [1]");
            Console.WriteLine("Byxor: [2]");
            Console.WriteLine("Skor:  [3]");
            int typ = TryCatch(1, 10);
            Plagg plagg = default;
            plagg.Type = Enum.GetName(typeof(Type), typ);
            Console.Clear();

            Console.WriteLine("Välj storlek: ");

            Console.WriteLine("XS: [1]");
            Console.WriteLine("S:  [2]");
            Console.WriteLine("M:  [3]");
            Console.WriteLine("L:  [4]");
            Console.WriteLine("XL: [5]");

            int size = TryCatch(1, 10);
            plagg.Size = Enum.GetName(typeof(Size), size);
            Console.Clear();

            

            Console.WriteLine("Välj färg: ");

            Console.WriteLine("Black:  [1]");
            Console.WriteLine("Yellow: [2]");
            Console.WriteLine("Green:  [3]");
            Console.WriteLine("Red:    [4]");
            Console.WriteLine("Gray:   [5]");

            int colour = TryCatch(1, 10);

            plagg.Colour = Enum.GetName(typeof(Colour), colour);
            Console.Clear();

            Console.WriteLine("Välj pris: ");

            int price = TryCatch(1, 1000000);
            plagg.Price = price;
            Console.Clear();
            store.Add(plagg);
        }

        public static void Admin(List<Plagg> store)
        {

            bool done = false;
            while (!done)
            {
                try
                {
                    List<String> menyChoice = new List<string>();
                    string s1 = "|Lägg till ett plagg|\n" +
                                "|-------------------|";
                    menyChoice.Add(s1);
                    string s2 = "|Visa sortiment     |\n" +
                                "|-------------------|";
                    menyChoice.Add(s2);
                    string s3 = "|Klar               |\n" +
                                "|-------------------|";
                    menyChoice.Add(s3);

                    int choice =NavigateMeny.NavigateStringList(menyChoice);

                    if (choice==0)
                    {
                        Console.Clear();
                        AddCloth(store);
                    }
                    if (choice==1)
                    {
                        Console.Clear();
                        foreach (var plagg in store)
                        {
                            Console.WriteLine($"Typ av plagg: {plagg.Type}\nFärg: {plagg.Colour}" +
                                $"\nStorlek: {plagg.Size}\nPris: {plagg.Price}");
                            Console.WriteLine("-------------------------------");
                        }
                        Console.ReadLine();
                    }
                    if (choice==2)
                    {
                        done = true;
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Ogiltig inmatning, försök igen...");
                    Console.ReadLine();
                }
                Console.Clear();
            }
        }
       
    }
}
