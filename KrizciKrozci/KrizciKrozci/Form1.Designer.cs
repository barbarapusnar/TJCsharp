
namespace KrizciKrozci
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novaIgraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dvaČlovekaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protiRačunalnikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dvaRačunalnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labRezultati = new System.Windows.Forms.Label();
            this.testirajVečIgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaIgraToolStripMenuItem,
            this.testirajVečIgerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(564, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novaIgraToolStripMenuItem
            // 
            this.novaIgraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dvaČlovekaToolStripMenuItem,
            this.protiRačunalnikuToolStripMenuItem,
            this.dvaRačunalnikaToolStripMenuItem});
            this.novaIgraToolStripMenuItem.Name = "novaIgraToolStripMenuItem";
            this.novaIgraToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.novaIgraToolStripMenuItem.Text = "Nova igra";
            // 
            // dvaČlovekaToolStripMenuItem
            // 
            this.dvaČlovekaToolStripMenuItem.Name = "dvaČlovekaToolStripMenuItem";
            this.dvaČlovekaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.dvaČlovekaToolStripMenuItem.Text = "Dva človeka";
            this.dvaČlovekaToolStripMenuItem.Click += new System.EventHandler(this.novaIgraToolStripMenuItem_Click);
            // 
            // protiRačunalnikuToolStripMenuItem
            // 
            this.protiRačunalnikuToolStripMenuItem.Name = "protiRačunalnikuToolStripMenuItem";
            this.protiRačunalnikuToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.protiRačunalnikuToolStripMenuItem.Text = "Proti računalniku";
            this.protiRačunalnikuToolStripMenuItem.Click += new System.EventHandler(this.protiRačunalnikuToolStripMenuItem_Click);
            // 
            // dvaRačunalnikaToolStripMenuItem
            // 
            this.dvaRačunalnikaToolStripMenuItem.Name = "dvaRačunalnikaToolStripMenuItem";
            this.dvaRačunalnikaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.dvaRačunalnikaToolStripMenuItem.Text = "Dva računalnika";
            this.dvaRačunalnikaToolStripMenuItem.Click += new System.EventHandler(this.dvaRačunalnikaToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(57, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(437, 391);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
//            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // labRezultati
            // 
            this.labRezultati.AutoSize = true;
            this.labRezultati.Location = new System.Drawing.Point(57, 470);
            this.labRezultati.Name = "labRezultati";
            this.labRezultati.Size = new System.Drawing.Size(38, 15);
            this.labRezultati.TabIndex = 3;
            this.labRezultati.Text = "label1";
            // 
            // testirajVečIgerToolStripMenuItem
            // 
            this.testirajVečIgerToolStripMenuItem.Name = "testirajVečIgerToolStripMenuItem";
            this.testirajVečIgerToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.testirajVečIgerToolStripMenuItem.Text = "Testiraj več iger";
            this.testirajVečIgerToolStripMenuItem.Click += new System.EventHandler(this.testirajVečIgerToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 513);
            this.Controls.Add(this.labRezultati);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Križci krožci";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novaIgraToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem dvaČlovekaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem protiRačunalnikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dvaRačunalnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testirajVečIgerToolStripMenuItem;
        private System.Windows.Forms.Label labRezultati;
    }
}

