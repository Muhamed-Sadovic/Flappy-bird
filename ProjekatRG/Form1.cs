using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatRG
{
    public partial class Form1 : Form
    {
        int gravitacija = 15; 
        int trRezultat = 0;
        int xoblaka1 = 200, yoblaka1 = 50,
            xoblaka2 = 600, yoblaka2 = 75,
            xoblaka3 = 350, yoblaka3 = 400,
            xGornjiP = 500, yGornjiP = -150, //gornja
            xGornjiP2 = 480, yGornjiP2 = 180,           
            xDonjiP = 500, yDonjiP = 500, //donja
            xDonjiP2 = 480, yDonjiP2 = 450;       

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            rezultat.ForeColor = Color.Red;
            rezultat.Font = new Font("Arial", 12, FontStyle.Bold);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.Clear(Color.LightBlue);
            SolidBrush sbbe = new SolidBrush(Color.White), 
                sbbr = new SolidBrush(Color.DarkGoldenrod);
            Rectangle oblak1 = new Rectangle(xoblaka1, yoblaka1, 180, 140),
            deooblaka1 = new Rectangle(xoblaka1 + 50, yoblaka1 - 30, 50, 50),
            oblak2 = new Rectangle(xoblaka2, yoblaka2, 180, 140),
            deooblaka2 = new Rectangle(xoblaka2 + 25, yoblaka2 - 30, 50, 50),
            oblak3 = new Rectangle(xoblaka3, yoblaka3, 180, 140),
            deooblaka3 = new Rectangle(xoblaka3 + 25, yoblaka3 - 30, 50, 50),
            pod = new Rectangle(0,630,this.ClientSize.Width,100),
            gornjaCev = new Rectangle(xGornjiP,yGornjiP,140,330),
            gornjaCev2 = new Rectangle(xGornjiP2,yGornjiP2,180,50),
            donjaCev = new Rectangle(xDonjiP,yDonjiP, 140, 330),
            donjaCev2 = new Rectangle(xDonjiP2,yDonjiP2,180,50);
            LinearGradientBrush lBrush = new LinearGradientBrush(gornjaCev2, Color.Green, Color.GreenYellow, LinearGradientMode.Horizontal);
            LinearGradientBrush lBrush2 = new LinearGradientBrush(donjaCev2, Color.Green, Color.GreenYellow, LinearGradientMode.Horizontal);

            HatchStyle hatchStyle = HatchStyle.Shingle;
            HatchBrush h1 = new HatchBrush(hatchStyle, Color.Red);
            Rectangle r0 = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height);
            g.FillRectangle(h1, r0);

            //SLIKA 
            ptica1.BackColor = Color.Transparent;

            //OBLACI
            g.FillRectangle(sbbe, oblak1);
            g.FillRectangle(sbbe, deooblaka1);
            g.FillRectangle(sbbe, oblak2);
            g.FillRectangle(sbbe, deooblaka2);
            g.FillRectangle(sbbe, oblak3);
            g.FillRectangle(sbbe, deooblaka3);

            //CEVI
            g.FillRectangle(lBrush, gornjaCev);
            g.FillRectangle(lBrush, gornjaCev2);  
            g.FillRectangle(lBrush2, donjaCev);
            g.FillRectangle(lBrush2, donjaCev2); 

            //POD
            g.FillRectangle(sbbr, pod);    
            

        }

        public void Gubitak()
        {
            if (ptica1.Top < 0 || ptica1.Top > 570 ||
            (ptica1.Right > xGornjiP && ptica1.Left < xGornjiP + 140 && ptica1.Top < yGornjiP + 330) ||
            (ptica1.Right > xGornjiP2 && ptica1.Left < xGornjiP2 + 180 && ptica1.Top < yGornjiP2 + 50) ||
            (ptica1.Right > xDonjiP && ptica1.Left < xDonjiP + 140 && ptica1.Bottom > yDonjiP) ||
            (ptica1.Right > xDonjiP2 && ptica1.Left < xDonjiP2 + 180 && ptica1.Bottom > yDonjiP2))
            {
                endGame();
            }    
        }
        public void PozicijaCevi()
        {
            Random r = new Random();
            int rb = r.Next(12);
            if (rb >= 0 && rb < 3)
            {
                yGornjiP = -200;
                yGornjiP2 = 130;
                yDonjiP = 450;
                yDonjiP2 = 400;
            }
            else if (rb >= 3 && rb < 6)
            {
                yGornjiP = -250;
                yGornjiP2 = 80;
                yDonjiP = 400;
                yDonjiP2 = 350;
            }
            else if(rb >= 6 && rb < 9)
            {
                yGornjiP = -310;
                yGornjiP2 = 20;
                yDonjiP = 340;
                yDonjiP2 = 290;
            }
            else
            {
                yGornjiP = -90;
                yGornjiP2 = 240;
                yDonjiP = 560;
                yDonjiP2 = 510;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ptica1.Top += gravitacija;
            rezultat.Text = "Rezultat: " + trRezultat;    
            PomeranjeOblaka();
            PomeranjeCevi();
            Gubitak();
            this.Invalidate();
        }

        private void endGame()
        {
            tajmer.Stop();
            MessageBox.Show("Izgubili ste!!! Vas rezultat je " + trRezultat.ToString());
            this.Close();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravitacija = -15;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravitacija = 15;
            }
        }
        public void PomeranjeOblaka()
        {
            xoblaka1 -= 10;
            xoblaka2 -= 10;
            xoblaka3 -= 10;

            if (xoblaka1 + 150 == 0)
            {
                xoblaka1 = 800;
            }
            if (xoblaka2 + 150 == 0)
            {
                xoblaka2 = 800;
            }
            if (xoblaka3 + 150 == 0)
            {
                xoblaka3 = 800;
            }
        }
        public void PomeranjeCevi()
        {
            xGornjiP -= 10;
            xGornjiP2 -= 10;
            xDonjiP -= 10;
            xDonjiP2 -= 10;
            if (xGornjiP2 + 180 == 0)
            {
                trRezultat++;
                xGornjiP = 800;
                xGornjiP2 = 780;
                xDonjiP = 800;
                xDonjiP2 = 780;
                PozicijaCevi();
            }
        }
    }
}
