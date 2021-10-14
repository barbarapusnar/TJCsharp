using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrizciKrozci
{
    class LogikaIgre
    {
        public int[,] deska;
        public int igralec;
        public LogikaIgre()
        {
            deska = new int[3, 3];
            igralec = 1;
        }
        public bool ImaKdo3(int vr, int st)
        {
            if (PreveriVrstico(vr, st) || PreveriStolpec(vr, st) || PreveriDiagonale(vr, st))
                return true;
            return false;
        }
        public bool PreveriVrstico(int vr,int st) //ko gremo v to preverjanje je to ali prvi vnos, ali pa naslednji (ni prazno)
        {
            
            if (deska[vr, 0] == deska[vr, st] && deska[vr, 1] == deska[vr, st] && deska[vr,2]==deska[vr,st]) 
                return true;
            return false;
        }
        public bool PreveriStolpec(int vr, int st) 
        {

            if (deska[vr, st] == deska[0, st] && deska[vr, st] == deska[1, st] && deska[vr, st] == deska[2, st]) return true;
            return false;
        }
        public bool PreveriDiagonale(int vr, int st)
        {
            //ne more biti v diagonali, če vnesemo določene pozicije
            if (vr == 0 && st == 1 || vr == 1 && st == 0 || vr == 1 && st == 2 || vr == 2 && st == 1) return false;
            if (vr==0)
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
        public bool JeNeodločeno(int vr, int st)
        {
            //če je kakšno polje prazno ni neodločeno
            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                    if (deska[k, j] == 0)
                        return false;
            }
            //Če nima nobeden 3 je neodločeno
            if (!ImaKdo3(vr, st))
                return true;
            return false;
        }
       
    }
}
