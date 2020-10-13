using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Klädbutiken
{
    class Store
    {
        const string fileName = "store.txt";

        static int UserInput(int minvalue, int maxvalue)
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
            int typ = UserInput(1, 10);
            Plagg plagg = default;
            plagg.Type = Enum.GetName(typeof(Type), typ);
            Console.Clear();

            Console.WriteLine("Välj storlek: ");

            Console.WriteLine("XS: [1]");
            Console.WriteLine("S:  [2]");
            Console.WriteLine("M:  [3]");
            Console.WriteLine("L:  [4]");
            Console.WriteLine("XL: [5]");

            int size = UserInput(1, 10);
            plagg.Size = Enum.GetName(typeof(Size), size);
            Console.Clear();

            

            Console.WriteLine("Välj färg: ");

            Console.WriteLine("Black:  [1]");
            Console.WriteLine("Yellow: [2]");
            Console.WriteLine("Green:  [3]");
            Console.WriteLine("Red:    [4]");
            Console.WriteLine("Gray:   [5]");

            int colour = UserInput(1, 10);

            plagg.Colour = Enum.GetName(typeof(Colour), colour);
            Console.Clear();

            Console.WriteLine("Välj pris: ");

            int price = UserInput(1, 1000000);
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
                        List<string> menyChoice2 = new List<string>();
                        string s4 = "Rensa sortiment.";
                        string s5 = "Ta bort ett plagg.";
                        string s6 = "Klar";
                        menyChoice2.Add(s4);
                        menyChoice2.Add(s5);
                        menyChoice2.Add(s6);
                        int choice2=NavigateMeny.NavigateStringList(menyChoice2);
                        if (choice2==0)
                        {
                            store.Clear();
                        }
                        if (choice2==1)
                        {

                        }
                        if (choice2==2)
                        {

                        }
                            
                    }
                    if (choice==2)
                    {
                        done = true;
                        SaveStore(store);
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

        private static void SaveStore(List<Plagg> store)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false)) 
            {
                foreach (var item in store)
                {
                    sw.WriteLine($"{item.Type};{item.Size};{item.Colour};{item.Price}");
                }
            }
        }
       

    }
}
