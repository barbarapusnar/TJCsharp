using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrizciKrozci
{
    class NaključniAgent : IIgralec
    {
        Random r = new Random();
        int št = 2; //kateri po vrsti je ta igralec
        LogikaIgre a;
        public NaključniAgent(int š,LogikaIgre a1)
        {
            št = š;
            a = a1;
        }
        public int NarediPotezo(int[,] d)
        {
            int poteza = r.Next(0, 9);
            //spremeni v stolpec in vrstico
            //preveri, če je tam še prosto
            int vr = poteza / 3;
            int st = poteza % 3;
            while (d[vr, st]!=0 ) //če je št=1, ne sme biti 2, če pa je 2, ne sme biti 1
            {
                poteza = r.Next(0, 9);
                //spremeni v stolpec in vrstico
                //preveri, če je tam še prosto
                vr = poteza / 3;
                st = poteza % 3;
            }
            return poteza;
        }
    }
}
