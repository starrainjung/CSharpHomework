using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework5_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
            private void button1_Click(object sender, EventArgs e)
            {
                if (graphics == null) graphics = this.CreateGraphics();
                drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
            }
        private Graphics graphics;
        double th1 = 70 * Math.PI / 180;
        double th2 = 50 * Math.PI / 180;
        double per1 = 0.7;
        double per2 = 0.5;

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x1, y1, x0, y0);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double a, double b, double c, double d)
        {
            graphics.DrawLine(
                Pens.Green, (int)a, (int)b, (int)c, (int)d);
        }
    }
}
