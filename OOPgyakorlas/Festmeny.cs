using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AukcioProjekt
{
    class Festmeny
    {
        private string cim;
        private string festo;
        private string stilus;
        private int licitekSzama;
        private int legmagasabbLicit;
        private DateTime legutolsoLicitIdeje;
        private bool elkelt;

        public Festmeny(string cim, string festo, string stilus)
        {
            this.cim = cim;
            this.festo = festo;
            this.stilus = stilus;
            this.licitekSzama = 0;
            this.legmagasabbLicit = 0;
            this.elkelt = false;
        }
        public string Festo()
        {
            return this.festo;
        }
        public string Stilus()
        {
            return this.stilus;
        }
        public int LicitekSzama()
        {
            return this.licitekSzama;
        }
        public int LegmagasabbLicit()
        {
            return this.legmagasabbLicit;
        }
        public DateTime LegutolsoLicitIdeje()
        {
            return this.legutolsoLicitIdeje;
        }
        public bool getElkelt()
        {
            return this.elkelt;
        }
        public void setElkelt(bool ertek)
        {
            this.elkelt = ertek;
        }
        public void Licit()
        {
            if (this.elkelt)
            {
                Console.WriteLine("Hiba! A festmeny már elkelt");
            }
            if (this.legmagasabbLicit==0)
            {
                this.legmagasabbLicit = 100;
                this.licitekSzama++;
                this.legutolsoLicitIdeje = DateTime.Now;
            }
            if (this.legmagasabbLicit>0)
            {
                this.legmagasabbLicit +=this.legmagasabbLicit/10;
               this.licitekSzama++;
                this.legutolsoLicitIdeje = DateTime.Now;
            }
        }
        public void Licit(int meret)
        {
            
            if (meret>=10&&meret<=100)
            {
                this.legmagasabbLicit += this.legmagasabbLicit / meret;
                this.licitekSzama++;
                this.legutolsoLicitIdeje = DateTime.Now;
            }
            else
            {
                Console.WriteLine("Hiba. Helytelen paraméter!");
            }
           
        }
        public void Kiir()
        {
            Console.WriteLine("festo: {0}({1})",this.festo,this.stilus);
            if (elkelt)
            {
                Console.WriteLine("elkelt");
            }
            else
            {
                Console.WriteLine("nem kelt el");
            }
            Console.WriteLine("{0} $ - {1}({2}db)",this.legmagasabbLicit,this.legutolsoLicitIdeje,this.licitekSzama);
        }
        public override string ToString()
        {
            return string.Format("festo: {0}({1})\n{5}\n{2} $ - {3}({4}db)", this.festo, this.stilus, this.legmagasabbLicit, this.legutolsoLicitIdeje, this.licitekSzama,this.elkelt);
        }

    }
}
