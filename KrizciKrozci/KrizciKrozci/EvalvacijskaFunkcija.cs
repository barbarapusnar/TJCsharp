using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrizciKrozci
{
    public class EvalvacijskaFunkcija
    {
        int functionCalls = 0;  // the number of function calls performed
        public EvalvacijskaFunkcija()
        {
        }

        /// <summary>
        /// gets the number of times the evaluation function has been called.
        /// </summary>
        public int FunctionCalls
        {
            get { return this.functionCalls; }
        }
        public double Evaluate(int[,] d, int maxPiece)
        {
            functionCalls++;
            //ali imamo zmagovalca
            zmagovalec = 0;
            if (ImamoZmagovalca(d))
            {
                if (zmagovalec == maxPiece)
                    return double.MaxValue;
                else
                    return double.MinValue;
            }
            double maxValue = Računaj(d, maxPiece); //moj rezultat
            double minValue = Računaj(d, 3 - maxPiece); //nasprotnikov rezultat
            return maxValue - minValue;
        }
        int zmagovalec = 0;
        public bool ImamoZmagovalca(int[,] d)
        {
            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (d[k, j] != 0)
                    {
                        if (ImaKdo3(d, k, j)) return true;
                    }
                }
            }
            return false;
        }
        public bool ImaKdo3(int[,] deska, int vr, int st)
        {
            if (PreveriVrstico(deska, vr, st) || PreveriStolpec(deska, vr, st) || PreveriDiagonale(deska, vr, st))
            {
                zmagovalec = deska[vr, st];
                return true;
            }
            return false;
        }
        public bool PreveriVrstico(int[,]deska,int vr, int st) //ko gremo v to preverjanje je to ali prvi vnos, ali pa naslednji (ni prazno)
        {

            if (deska[vr, 0] == deska[vr, st] && deska[vr, 1] == deska[vr, st] && deska[vr, 2] == deska[vr, st])
            {
                return true;
            }
            return false;
        }
        public bool PreveriStolpec(int[,] deska, int vr, int st)
        {

            if (deska[vr, st] == deska[0, st] && deska[vr, st] == deska[1, st] && deska[vr, st] == deska[2, st])
            {
                return true;
            }
            return false;
        }
        public bool PreveriDiagonale(int[,] deska, int vr, int st)
        {
            if (vr == 0 && st == 1 || vr == 1 && st == 0 || vr == 1 && st == 2 || vr == 2 && st == 1) return false;
            if (vr == 0)
            {
                if (st == 0)
                {
                    if (deska[1, 1] == deska[vr, st] && deska[2, 2] == deska[vr, st]) return true;
                }
                if (st == 2)
                {
                    if (deska[1, 1] == deska[vr, st] && deska[2, 0] == deska[vr, st]) return true;
                }
            }
            if (vr == 1)
            {
                if (st == 1)
                {
                    if (deska[0, 0] == deska[vr, st] && deska[2, 2] == deska[vr, st]) return true;
                    if (deska[0, 2] == deska[vr, st] && deska[2, 0] == deska[vr, st]) return true;
                }

            }
            if (vr == 2)
            {
                if (st == 0)
                {
                    if (deska[1, 1] == deska[vr, st] && deska[0, 2] == deska[vr, st]) return true;
                }
                if (st == 2)
                {
                    if (deska[1, 1] == deska[vr, st] && deska[0, 0] == deska[vr, st]) return true;
                }
            }
            return false;
        }
             
        public double Računaj(int[,] d, int igralec)
        {
            return RačunajVrstice(d, igralec) + RačunajStolpce(d, igralec) + RačunajDiagonale(d, igralec);
        }
        private double RačunajVrstice(int[,] b, int igralec)
        {

            double score = 0.0;
            int count;
            for (int i = 0; i < 3; i++)
            {
                count = 0;
                bool vrsticaČista = true;
                for (int j = 0; j < 3; j++)
                {
                    if (b[i, j] == igralec) //koliko imam mojih znakov v vrstici
                        count++;
                    else if (b[i, j] == 3 - igralec) //če ima v tej vrstici kakšen znak nasprotnik, ne bom štela
                    {
                        vrsticaČista = false;
                        break;
                    }
                }
                if (vrsticaČista && count != 0)
                    score += count;
            }

            return score;
        }
        private double RačunajStolpce(int[,] b, int igralec)
        {
            double score = 0.0;
            int count;
            // check the rows
            for (int j = 0; j < 3; j++)
            {
                count = 0;
                bool stolpecČist = true;
                for (int i = 0; i < 3; i++)
                {


                    if (b[i, j] == igralec)
                        count++;
                    else if (b[i, j] == 3 - igralec)
                    {
                        stolpecČist = false;
                        break;
                    }
                }
                if (stolpecČist && count != 0)
                    score += count; //Math.Pow(count, count);
            }
            return score;
        }
        private double RačunajDiagonale(int[,] b, int igralec)
        {
            int count = 0;
            bool diagonalClean = true;

            double score = 0.0;

            for (int i = 0; i < 3; i++)
            {
                if (b[i, i] == igralec)
                    count++;

                else if (b[i, i] == 3 - igralec)
                {
                    diagonalClean = false;
                    break;
                }
            }

            if (diagonalClean && count > 0)
                score += count;// Math.Pow(count, count);
            int row = 0;
            int col = 2;
            count = 0;
            diagonalClean = true;

            while (row < 3 && col >= 0)
            {


                if (b[row, col] == igralec)
                    count++;

                else if (b[row, col] == 3 - igralec)
                {
                    diagonalClean = false;
                    break;
                }
                row++;
                col--;
            }

            if (count > 0 && diagonalClean)
                score += count;

            return score;
        }
    }
}
