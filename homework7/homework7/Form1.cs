using homework7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;



namespace homework7
{
    public partial class Form1 : Form
    {
         private List<Order> list;

        public Form1()
        {

        Order order1 = new Order("001", "mina", "鞋", 600);
        Order order2 = new Order("002", "momo", "猪蹄", 20);
        Order order3 = new Order("003", "jyh", "奶茶", 12);
        Order order4 = new Order("004", "jyh", "鞋", 622);
        Order order5 = new Order("005", "sana", "书", 48);
        Order order6 = new Order("006", "sana", "帽子", 100);
        OrderService Od = new OrderService();


            Od.Add(order1);                    
            Od.Add(order2);
            Od.Add(order3);
            Od.Add(order4);
            Od.Add(order5);
            Od.Add(order6);

        }

    private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}