using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
namespace Klädbutiken
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            List<Plagg> store = new List<Plagg>();
            List<Plagg> purchase = new List<Plagg>();
            Console.WriteLine("Välkommen! ");
            Thread.Sleep(1000);

            while (isRunning)
            {

                Console.Clear();
                int choice = Meny();
                
                if (choice==0)
                {
                    Console.Clear();
                    Store.Admin(store);

                }
                if (choice==1)
                {
                    Console.Clear();
                    Shop.Customer(store, purchase);
                }
                if (choice==2)
                {
                    isRunning = false;
                }

            }
        }
        public static int Meny()
        {
            List<string> menyCoice = new List<string>();

            string s1 = "|  Logga in som Admin       |\n" +
                        "|---------------------------|";
            menyCoice.Add(s1);
            string s2 = "|  Logga in som kund        |\n" +
                        "|---------------------------|";
            menyCoice.Add(s2);
            string s3 = "|   Avsluta                 |\n" +
                        "|---------------------------|";
            menyCoice.Add(s3);

            int choice = NavigateMeny.NavigateStringList(menyCoice);

            return choice;
        }
    }
    
        
    struct Plagg
    {
        public string Type { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public int Price { get; set; }
        public Plagg(string type, string size, string colour, int prize)
        {
            Type = type;
            Size = size;
            Colour = colour;
            Price = prize;
        }
    }
    enum Type
    { 
        Shirt=1,
        Pants,
        Shoes

    }
    enum Size
    {
        XS=1,
        S,
        M,
        L,
        XL
    }
   
    enum Colour
    {
        Black=1,
        Yellow,
        Green,
        Red,
        Gray,
    }
}
