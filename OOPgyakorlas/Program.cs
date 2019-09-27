using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AukcioProjekt
{
    class Program
    {
        public static List<Festmeny> festmenyLista= new List<Festmeny>();
        static void Main(string[] args)
        {
            festmenyLista.Add(new Festmeny("Monalisa", "Leonardo DaVincsi", "Barokk"));
            festmenyLista.Add(new Festmeny("Kacsák", "Papp László", "Futurizmus"));
            ketob();
            beolvas("festmenyek.csv");
            randomLicit();
            felhasznaloLicit();
            for (int i = 0; i < festmenyLista.Count; i++)
            {
                Console.WriteLine(festmenyLista[i]);
            }
        }
        public static void ketob()
        {
            Console.Write("Kérem adja meg menyi új festményt szeretne: ");
            int db = int.Parse(Console.ReadLine());
            for (int i = 0; i < db; i++)
            {
                string nev, stilus, cim;
                Console.Write("\nKérem adja meg a(z) {0}. kép címét: ",i+1);
                cim = Console.ReadLine();
                Console.Write("\nKérem adja meg a(z) {0}. kép festőét: ",i+1);
                nev = Console.ReadLine();
                Console.Write("\nKérem adja meg a(z) {0}. kép stílusát:",i+1);
                stilus = Console.ReadLine();
                festmenyLista.Add(new Festmeny(cim, nev, stilus));
            }
        }
        public static void beolvas(string file)
        {
            try
            {
                StreamReader olvas = new StreamReader(file);
                string sor = olvas.ReadLine();
                while (olvas.EndOfStream)
                {
                    string[] adat=sor.Split(';');
                    festmenyLista.Add(new Festmeny(adat[0],adat[1],adat[2]));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public static void randomLicit()
        {
            
            for (int i = 0; i < 20; i++)
            {
                Random rnd= new Random();
                int random = rnd.Next(0, festmenyLista.Count);
                festmenyLista[random].Licit();
            }
        }
        public static void felhasznaloLicit()
        {
            int mertek;
            int sorszam=1;
            while (sorszam!=0)
            {
                do
                {
                    try
                    {
                        Console.Write("Kérem adja meg a festmény sorszámát: ");
                        sorszam = int.Parse(Console.ReadLine());
                        if (sorszam - 1 > festmenyLista.Count)
                        {
                            Console.WriteLine("Hiba! nincs ilyen sorszam!!\nPróbálja újra!");
                        }
                        if (festmenyLista[sorszam - 1].getElkelt())
                        {
                            Console.WriteLine("Hiba a festmény már elkelt!\nKérem adjon meg új sorszámot.");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Hiba!! Nem számot adott meg!!");
                        Console.ReadKey();
                        throw;
                    }
                } while (sorszam - 1 > festmenyLista.Count&&festmenyLista[sorszam-1].getElkelt());
            }
            try
            {
                Console.Write("Milyen mértékkel szeretne licitálni?: ");
                string adat = Console.ReadLine();
                if (adat.Equals(""))
                {
                    mertek = 10;
                }
                else
                {
                    mertek = int.Parse(adat);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hiba!! Nem számot adott meg!!");
                Console.ReadKey();
                throw;
            }
        }
    }
}
