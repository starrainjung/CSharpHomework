using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string s1, s2;
        int a, b;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s1 = textBox1.Text;
            a = int.Parse(s1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            s2 = textBox2.Text;
            b = int.Parse(s2);
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string c = Convert.ToString(a * b);
            this.textBox3.Text = c;
        }

       

    }
}
