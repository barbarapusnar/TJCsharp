using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KrizciKrozci
{
    public partial class Form1 : Form
    {
        LogikaIgre a;
        int zmagovalec=0;
        IIgralec rač1;
        IIgralec rač2;
        public Form1()
        {
            InitializeComponent();
            a = new LogikaIgre();
         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Pen p = new Pen(Color.Black, 5);
            Graphics g = e.Graphics;
            PictureBox panel = (PictureBox)sender;
            int širina = panel.Width;
            int višina = panel.Height;
            g.DrawLine(p, širina / 3, 0, širina / 3, višina);
            g.DrawLine(p, 2*širina / 3, 0, 2*širina / 3, višina);
            g.DrawLine(p, 0, višina / 3, širina, višina / 3);
            g.DrawLine(p, 0, 2*višina / 3, širina, 2*višina / 3);
            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Rectangle r = new Rectangle(j*širina/3+35,k*višina/3+30,širina/3,višina/3);
                    if (a.deska[k, j] == 1)
                    {
                        g.DrawString("X", new Font("Arial", 48), new SolidBrush(Color.Black), r);
                    }
                    if (a.deska[k, j] == 2)
                    {
                        g.DrawString("0", new Font("Arial", 48), new SolidBrush(Color.Green), r);
                    }
                }
            }
            if (zmagovalec !=0)
            {
                
                    if (a.deska[0,0]!=0&&a.deska[0,0]==a.deska[0,1]&&a.deska[0,1]==a.deska[0,2]) 
                        g.DrawLine(p, 0, višina / 3 - višina / 3 / 2, širina, višina / 3 - višina / 3 / 2);
                    else
                    if (a.deska[1, 0] != 0&&a.deska[1, 0] == a.deska[1, 1] && a.deska[1, 1] == a.deska[1, 2])
                       g.DrawLine(p, 0, višina / 3 + višina / 3 / 2, širina, višina / 3 + višina / 3 / 2);
                    else
                    if (a.deska[2, 0] != 0 && a.deska[2, 0] == a.deska[2, 1] && a.deska[2, 1] == a.deska[2, 2])
                       g.DrawLine(p, 0, višina- višina / 3 / 2, širina, višina- višina / 3 / 2);
                //sami dodajo še ostale

                if (a.deska[0, 0] != 0 && a.deska[0, 0] == a.deska[1, 0] && a.deska[1, 0] == a.deska[2, 0])
                    g.DrawLine(p, širina/3/2-5, 0, širina/3/2-5, višina);
                else
                if (a.deska[0, 1] != 0 && a.deska[0, 1] == a.deska[1, 1] && a.deska[1, 1] == a.deska[2, 1])
                    g.DrawLine(p, širina/3+širina/3/2-5, 0, širina / 3 + širina / 3 / 2-5, višina);
                else
                if (a.deska[0, 2] != 0 && a.deska[0, 2] == a.deska[1, 2] && a.deska[1, 2] == a.deska[2, 2])
                    g.DrawLine(p, širina-širina/3/2-5, 0, širina - širina / 3 / 2-5, višina);
                //še 2 diagonale
                if (a.deska[0,0]!=0&&a.deska[0,0]==a.deska[1,1]&&a.deska[1,1]==a.deska[2,2])
                    g.DrawLine(p, 5,5, širina - 5, višina-5);
                if (a.deska[0, 2] != 0 && a.deska[0, 2] == a.deska[1, 1] && a.deska[1, 1] == a.deska[2, 0])
                    g.DrawLine(p, širina-5, 5, 5, višina - 5);
            }
        }

        private void ObKliku(object sender, MouseEventArgs e)
        {
           
                int pozX = e.X;
                int pozY = e.Y;
                int vr = 0;
                int st = 0;
                int širina = pictureBox1.Width;
                int višina = pictureBox1.Height;
                //tukaj samo nastavi na desk, izriši zgoraj
                if (pozX < širina / 3)
                    st = 0;
                else
                if (pozX < 2 * širina / 3) st = 1;
                else
                if (pozX < širina) st = 2;
                else
                    st = -1;

                if (pozY < višina / 3)
                    vr = 0;
                else
                if (pozY < 2 * višina / 3) vr = 1;
                else
                if (pozY < višina) vr = 2;
                else
                    vr = -1;
            if (st != -1 && vr != -1 && a.deska[vr, st] == 0)
            {
                a.deska[vr, st] = a.igralec;
                if (a.ImaKdo3(vr, st))
                {
                    zmagovalec = a.deska[vr, st];
                    pictureBox1.MouseClick -= ObKliku;
                    pictureBox1.Invalidate();

                    return;
                }
                if (a.JeNeodločeno(vr, st))
                {
                    zmagovalec = 0;
                    pictureBox1.MouseClick -= ObKliku;
                    pictureBox1.Invalidate();
                    return;
                }
                pictureBox1.Invalidate();
                a.igralec = 3 - a.igralec; //zamenjaj igralca
               
            }
            if (rač1 != null)
             {
                    int p = rač1.NarediPotezo(a.deska);
                    vr = p / 3;
                    st = p % 3;
                    a.deska[vr, st] = a.igralec;
                    if (a.ImaKdo3(vr, st))
                    {
                        zmagovalec = a.deska[vr, st];
                        pictureBox1.MouseClick -= ObKliku;
                        pictureBox1.Invalidate();
                    }
                    if (a.JeNeodločeno(vr, st))
                    {
                        zmagovalec = 0;
                        pictureBox1.MouseClick -= ObKliku;
                        pictureBox1.Invalidate();
                    }
                    pictureBox1.Invalidate();
                    a.igralec = 3 - a.igralec;              
                   
                }
                
            
               
        }

        private void novaIgraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a = new LogikaIgre();
            zmagovalec = 0;
            pictureBox1.MouseClick += ObKliku;
            rač1 = null;
            rač2 = null;
            pictureBox1.Invalidate();
        }

        private void protiRačunalnikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a = new LogikaIgre();
            zmagovalec = 0;
            rač1 = new EnKorak(2, a);
            pictureBox1.MouseClick += ObKliku;
            pictureBox1.Invalidate();
        }

        private void dvaRačunalnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a = new LogikaIgre();
            zmagovalec = 0;
            rač1 = new NaključniAgent(1, a);
            rač2 = new EnKorak(2, a);
            int p = 0;
            while (true)
            {
                if (a.igralec == 1)
                    p = rač1.NarediPotezo(a.deska);
                else
                    p = rač2.NarediPotezo(a.deska);
                int vr = p / 3;
                int st = p % 3;
                a.deska[vr, st] = a.igralec;
                if (a.ImaKdo3(vr, st))
                {
                    zmagovalec = a.deska[vr, st];                 
                    pictureBox1.Invalidate();
                    return;
                }
                if (a.JeNeodločeno(vr, st))
                {
                    zmagovalec = 0;                   
                    pictureBox1.Invalidate();
                    return;
                }
                pictureBox1.Invalidate();
                a.igralec = 3 - a.igralec;
            }
            
        }

        private void testirajVečIgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int zmaga1 = 0; int zmaga2 = 0; int neodločeno = 0;
            for (int k = 0; k < 10000; k++)
            {
                a = new LogikaIgre();
                //zmagovalec = 0;
                rač1 = new EnKorak(1, a);
                rač2 = new NaključniAgent(2, a);
                int p = 0;
                while (true)
                {
                    if (a.igralec == 1)
                        p = rač1.NarediPotezo(a.deska);
                    else
                        p = rač2.NarediPotezo(a.deska);
                    int vr = p / 3;
                    int st = p % 3;
                    a.deska[vr, st] = a.igralec;
                    if (a.ImaKdo3(vr, st))
                    {
                        zmagovalec = a.deska[vr, st];
                        if (zmagovalec == 1) zmaga1++;
                        if (zmagovalec == 2) zmaga2++;
                        //pictureBox1.Invalidate();
                        //return;
                        break;
                    }
                    if (a.JeNeodločeno(vr, st))
                    {
                        zmagovalec = 0;
                        neodločeno++;
                        //pictureBox1.Invalidate();
                        //return;
                        break;
                    }
                   // pictureBox1.Invalidate();
                    a.igralec = 3 - a.igralec;
                }
            }
            labRezultati.Text = ("Zmaga 1 " + zmaga1 + "(" + zmaga1 / 100 + "% )" + " Zmaga 2" + zmaga2 + "(" + zmaga2 / 100 + "% )+" +
                " Neodločeni " + neodločeno) + "(" + neodločeno / 100 + "% )";
                              
        }
    }
}
