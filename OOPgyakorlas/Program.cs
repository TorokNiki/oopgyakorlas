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
    }
}
