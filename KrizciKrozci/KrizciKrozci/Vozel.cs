using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrizciKrozci
{
    public abstract class Vozel
    {
        //vsi dediči enega vozla
        protected List<Vozel> otroci;
        // vrednost, ki je povezana z vozlom, je na listih - vozlih najbolj na dnu
        private double vrednost;
        public double Vrednost { get => vrednost; set => vrednost = value; }
        // otrok, ki predstavlja najboljšo potezo
        public Vozel najboljšiVozel;
        // na katero desko so vezani tej vozli
        protected int[,] deska;
        //poseben razred, ki izračuna vrednost za posamezno desko 
        protected static EvalvacijskaFunkcija evaluator;
        protected int mojaŠt=2; // 1 ali 2 - ta se bo menjavala, glede na to, kdo igra
        public int MojaŠt
        {
            get { return mojaŠt; }
            set
            {
                mojaŠt = value;
                nasprotnikovaŠt = 3 - value;
            }
        }
        protected int nasprotnikovaŠt=1; // 1 
        // kako smo od starševskega vozla prišli do tega vozla
        public int pozicija;
        //starševski vozel
        Vozel parent = null;
        public Vozel(int[,] d, Vozel starš, int p, int š) //p in š kako smo na tako desko prišli, pozicija in številka igralca
        {
            deska = new int[3, 3];
            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                {
                    deska[k, j] = d[k, j];
                }
            }
            this.parent = starš;
            pozicija = p;
            if (parent != null) //zamenjaj mojoŠt
                mojaŠt = 3 - š;
            otroci = new List<Vozel>();
        }

       
        public EvalvacijskaFunkcija Evaluator
        {
            set { evaluator = value; }
        }
        //abstraktna metoda, ki bo izračunala vrednost na listih, različno za min/max vozle
        protected abstract void Evaluate();

       
        public void IzberiNajboljšoPotezo()
        {
            // če ni nobenega otroka, je ni najboljše poteze
            if (otroci.Count == 0)
            {
                najboljšiVozel = null;
                return;
            }
            // uredi otroke, da bo najboljša poteza prva v tabeli
            List<Vozel> sortedChildren = SortChildren(otroci);
            this.najboljšiVozel = sortedChildren[0];
            vrednost = najboljšiVozel.vrednost;
            pozicija = najboljšiVozel.pozicija;
        }
        public virtual void PoiščiNajboljšoPotezo(int depth)
        {
            if (depth > 0)
            {
                // otroke ustvarim v razredih MinVozel in MaxVozel
                UstvariOtroke();
                //izračuna hevristiko za vsakega otroka
                IzračunajOtroke();
                // preveri, če že imamo kakšnega zmagovalca
                bool imamoZmagovalca= otroci.Exists(c => c.JeKončniVozelZaIgro());
                if (imamoZmagovalca)
                {
                    // robni pogoj
                    IzberiNajboljšoPotezo();
                    return;
                }
                else
                {                
                    foreach (Vozel otrok in otroci)
                    {
                        otrok.PoiščiNajboljšoPotezo(depth - 1);    //rekurzivni klic
                    }
                    IzberiNajboljšoPotezo();
                }
            }

        }
    public virtual bool JeKončniVozelZaIgro()
        {
            return vrednost == double.MaxValue || vrednost == double.MinValue;
        }
        protected void IzračunajOtroke()
        {
            foreach (Vozel child in this.otroci)
            {
                child.Evaluate();
            }
        }

        protected abstract void UstvariOtroke();
        protected abstract List<Vozel> SortChildren(List<Vozel> unsortedChildren);
        protected abstract bool IsWinningNode();

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
    }
    public class MaxVozel : Vozel
    {
        public MaxVozel(int[,] d, Vozel starš, int p, int š)
            : base(d,starš,p,š)
        {
        }
        // otroci MaxVozla so tipa MinVozel
        protected override void UstvariOtroke()
        {
            // preveri vse možne pozicije
            int[] openPositions = MožnePoteze(deska);
            foreach (int i in openPositions)
            {
                int[,] a = new int[3, 3];
                for (int k = 0; k < 3; k++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        a[k, j] = deska[k, j];
                    }
                }
                int vr = i / 3;
                int st = i % 3;
                a[vr, st] = mojaŠt;                           
                otroci.Add(new MinVozel(a, this, i,mojaŠt));

            }
        }
        protected override void Evaluate()
        {
            this.Vrednost = evaluator.Evaluate(deska, mojaŠt);
        }
        protected override bool IsWinningNode()
        {

            return this.Vrednost == double.MaxValue;
        }
        protected override List<Vozel> SortChildren(List<Vozel> unsortedChildren)
        {
            List<Vozel> sortedChildren = unsortedChildren.OrderByDescending(n => n.Vrednost).ToList();

            return sortedChildren;
        }
   }
    public class MinVozel : Vozel
    {
        public MinVozel(int[,] d, Vozel starš, int p, int š)
            : base(d, starš, p, š)
        {
        }
        protected override void UstvariOtroke()
        {

            int[] openPositions = MožnePoteze(deska);
            foreach (int i in openPositions)
            {
                int[,] a = new int[3, 3];
                for (int k = 0; k < 3; k++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        a[k, j] = deska[k, j];
                    }
                }
                int vr = i / 3;
                int st = i % 3;
                a[vr, st] = mojaŠt;
                otroci.Add(new MaxVozel(a, this, i, mojaŠt));
            }
        }
        protected override bool IsWinningNode()
        {
            return this.Vrednost == double.MinValue;
        }
        protected override List<Vozel> SortChildren(List<Vozel> unsortedChildren)
        {
            List<Vozel> sortedChildren = unsortedChildren.OrderBy(n => n.Vrednost).ToList();
            return sortedChildren;
        }
        protected override void Evaluate()
        {
            Vrednost = evaluator.Evaluate(deska, 3-mojaŠt);
        }
    }
}

