using System;
using System.Collections.Generic;
using System.Threading;

namespace Klädbutiken
{
    class Shop
    {
        public static void Customer(List<Plagg> store, List<Plagg> purchase)
        {
            List<string> menyChoice = new List<string>();
            string s1 = "|  Visa varukorg.  |\n" +
                        "|------------------|";
            menyChoice.Add(s1);
            string s2 = "|  Handla.         |\n" +
                        "|------------------|";
            menyChoice.Add(s2);
            string s3 = "";

           int Choice= NavigateMeny.NavigateStringList(menyChoice);
            if (Choice==0)
            {
                Console.Clear();
                if (purchase.Count !=0)
                {
                    foreach (var plagg in purchase)
                    {
                        Console.WriteLine($"Typ av plagg: {plagg.Type}\nFärg: {plagg.Colour}" +
                               $"\nStorlek: {plagg.Size}\nPris: {plagg.Price}");
                        Console.WriteLine("-------------------------------");
                    }
                    Console.WriteLine($"Det finns {purchase.Count} varor i din varukorg.");
                    Console.ReadLine();
                    Payment(purchase);
                    //.ReadLine();

                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Din varukorg är tom.");
                    Console.ReadLine();
                }
            }
            if (Choice==1)
            {
                Console.Clear();
                if (store.Count !=0)
                {
                    Purchase(store, purchase);

                }
                else
                {
                    Console.WriteLine("Butiken är tom.");
                    Console.ReadLine();
                }

            }
           
        }
        public static void Purchase(List<Plagg> store, List<Plagg> purchase)
        {
            int scroll = 1;
            bool done = false;
            while (!done)
            {
                int counter = 1;
                Console.Clear();
                foreach (var plagg in store)
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
                if (key == ConsoleKey.A && scroll == store.Count)
                {
                    scroll = store.Count;
                }
                else if (key == ConsoleKey.Z && scroll == 1)
                {
                    scroll = 1;
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
                    Console.Clear();
                    var plagg = store[scroll - 1];
                    purchase.Add(plagg);
                    Console.WriteLine("Varan ligger nu i din varukorg!");
                    List<string> menyChoice = new List<string>();
                    string s1 = "|       Fortsätt handla.        |\n" +
                               "|-------------------------------|";
                    menyChoice.Add(s1);
                    string s2 = "|       Klar.                   |\n" +
                               "|-------------------------------|";
                    menyChoice.Add(s2);
                    int choice = NavigateMeny.NavigateStringList(menyChoice);

                    if (choice == 0)
                    {
                        done = false;
                    }
                    else if (choice == 1)
                    {
                        done = true;
                    }
                }
            }
        }
        public static void Payment(List<Plagg>purchase)
        {
            List<string> menyChoice = new List<string>();
            string s1 = "Gå till Betalning.";
            string s2 = "Ta bort en vara.";
            string s3 = "Bakåt.";
            menyChoice.Add(s1);
            menyChoice.Add(s2);
            menyChoice.Add(s3);

            int choice =NavigateMeny.NavigateStringList(menyChoice);
            if (choice==0)
            {
                Console.Clear();
                int sum = 0;
                foreach (var item in purchase)
                {
                    sum += item.Price;
                }
                Console.WriteLine($"Summa: {sum}");
                Console.ReadKey();
            }
            if (choice==1)
            {
                int remove=NavigateMeny.NavigatePlaggList(purchase);
                int count = 0;
                foreach (var item in purchase)
                {
                    count++;

                    if (remove == count)
                    {
                        purchase.RemoveAt(count-1);
                        break;
                    }
                }
            }
            if (choice==2)
            {

            }

        }

    }
}
