using program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace OrderWinForm
{
    public partial class Form1 : Form
    {
        OrderService service = new OrderService();
        public Form1()
        {
            InitializeComponent();
            Order order1 = new Order("001", "mina", "鞋", 600);
            Order order2 = new Order("002", "momo", "猪蹄", 20);
            Order order3 = new Order("003", "jyh", "奶茶", 12);
            Order order4 = new Order("004", "jyh", "鞋", 622);
            Order order5 = new Order("005", "sana", "书", 48);
            Order order6 = new Order("006", "sana", "帽子", 100);
          


            service.Add(order1);
            service.Add(order2);
            service.Add(order3);
            service.Add(order4);
            service.Add(order5);
            service.Add(order6);
            //service = OrderService.Import(s.xml);
            orderBindingSource.DataSource = service.orders;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==4)
            {
                int row = e.RowIndex;

                string name = (string) ((DataGridView)sender).Rows[row].Cells[0].Value;
                string client = (string)((DataGridView)sender).Rows[row].Cells[1].Value;
                string id = (string)((DataGridView)sender).Rows[row].Cells[2].Value;
                ((DataGridView)sender).Rows.RemoveAt(row);
                Order order = service.orders
                    .Where(s =>
                    s.goodsName == client &&
                    s.orderNumber == id &&
                    s.guestName == name)
                    .FirstOrDefault();
               
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            orderBindingSource.DataSource = service.orders.
                Where(s =>
                s.goodsName.Contains(text) ||
                s.orderNumber.Contains(text) ||
                s.guestName.Contains(text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(this.textBox1.Text=="")
            {
                orderBindingSource.DataSource = service.orders;
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.Export("../../s.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            service.Export("../../s.html");
        }

        private void bindingNavigator3_RefreshItems(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void orderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}




