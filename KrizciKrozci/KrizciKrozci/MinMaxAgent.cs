using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrizciKrozci
{
    class MinMaxAgent : IIgralec
    {
        Random r = new Random();
        int št = 2; //kateri po vrsti je ta igralec
        LogikaIgre a;
        public MinMaxAgent(int š, LogikaIgre a1)
        {
            št = š;
            a = a1;
        }
        public int[] MožnePoteze(int[,] d)
        {
            List<int> možne = new List<int>();
            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                    if (d[k, j] == 0)
                        možne.Add(k * 3 + j);
            }
            return možne.ToArray();
        }
        public int NarediPotezo(int[,] d)
        {
            
            //to make things interesting we move randomly if the board we
            //are going first (i.e. the board is empty)
            if (MožnePoteze(d).Length == 9)
            {
                int poteza = r.Next(0, 9);
                return poteza;
            }

            Vozel root = new MaxVozel(a.deska,null,-1,št);
            root.MojaŠt = št;
            root.Evaluator = new EvalvacijskaFunkcija();
            root.PoiščiNajboljšoPotezo(1);
            return root.najboljšiVozel.pozicija;

         
        }
    }
}
