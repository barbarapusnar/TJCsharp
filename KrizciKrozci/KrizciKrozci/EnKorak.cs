using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrizciKrozci
{
    class EnKorak : IIgralec
    {
       
        int št = 2; //kateri po vrsti je ta igralec
        LogikaIgre a;
        public EnKorak(int š, LogikaIgre a1)
        {
            št = š;
            a = a1;
        }
        public int NarediPotezo(int[,] d)
        {
            //dobi vse možne poteze
            //izračunaj katera je najboljša, če jih je več izberi kar prvo
            int[] možne = MožnePoteze(d);
            double naj = 0;
            int najboljšaPoteza = 0;
            for (int k = 0; k < možne.Length; k++)
            {
                //izračunaj novo desko za možno potezo in njeno hevristiko
                //1. naredi tabelo, z naslednjim korakom
                int[,] a = NovaTabela(d, možne[k]);
                //2. izračunaj hevristiko
                double moj = Računaj(a, št);
                double nasprotnik = Računaj(a, 3 - št);
                double rezultat = moj - nasprotnik;
                if (rezultat > naj)
                {
                    naj = rezultat;
                    najboljšaPoteza = možne[k];

                }
            }
            return najboljšaPoteza;

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
        public int[,] NovaTabela(int[,] d, int poz)
        {
            int[,] a = new int[3, 3];
            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                {
                    a[k, j] = d[k, j];
                }
            }
            int vr = poz / 3;
            int st = poz % 3;
            a[vr, st] = št;
            return a;
        }
        public double Računaj(int[,] d, int igralec)
        {
            return RačunajVrstice(d, igralec) + RačunajStolpce(d, igralec) + RačunajDiagonale(d, igralec);
        }
        private double RačunajVrstice(int[,] b, int igralec)
        {

            double score = 0.0;
            int count;
            // check the rows
            for (int i = 0; i < 3; i++)
            {
                count = 0;
                bool vrsticaČista = true;
                for (int j = 0; j < 3; j++)
                {
                   

                    if (b[i,j] == igralec)
                        count++;
                    else if (b[i,j] == 3-igralec)
                    {
                        vrsticaČista = false;
                        break;
                    }
                }

                // if we get here then the row is clean (an open row)
                if (vrsticaČista && count != 0)
                    score += count;
            }

            return score;
        }


        // over all rows sums the number of pieces in the row if 
        // the specified piece can still win in that row i.e. the row
        // does not contain an opponent's piece
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
                    

                    if (b[i,j] == igralec)
                        count++;
                    else if (b[i, j] == 3-igralec)
                    {
                        stolpecČist = false;
                        break;
                    }
                }

                // if we get here then the row is clean (an open row)
                if (stolpecČist && count != 0)
                    score += count; //Math.Pow(count, count);

            }

            return score;
        }


        // over both diagonals sums the number of pieces in the diagonal if 
        // the specified piece can still win in that diagonal i.e. the diagonal
        // does not contain an opponent's piece
        private double RačunajDiagonale(int[,] b, int igralec)
        {
            // go down and to the right diagonal first
            int count = 0;
            bool diagonalClean = true;

            double score = 0.0;

            for (int i = 0; i < 3; i++)
            {
               

                if (b[i,i]== igralec)
                    count++;

                if (b[i, i] == 3-igralec)
                {
                    diagonalClean = false;
                    break;
                }
            }

            if (diagonalClean && count > 0)
                score += count;// Math.Pow(count, count);




            // now try the other way

            int row = 0;
            int col = 2;
            count = 0;
            diagonalClean = true;

            while (row < 3 && col >= 0)
            {
                

                if (b[row,col] == igralec)
                    count++;

                if (b[row, col] == 3-igralec)
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
