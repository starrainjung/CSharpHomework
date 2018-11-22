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
        private OrderService service;
        public Form1()
        {

            InitializeComponent();
            service = OrderService.Import("../../s.xml");
            orderBindingSource.DataSource = service.orders;


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
            if (this.textBox1.Text == "")
            {
                orderBindingSource.DataSource = service.orders;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.Export("../../s.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
             service.ExportHtml("../../s.html");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            orderBindingSource.DataSource = service.OrderList.
                Where(s =>
                s.Client.Contains(text) ||
                s.Id.Contains(text) ||
                s.Name.Contains(text));

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int row = e.RowIndex;

                string name = (string)((DataGridView)sender).Rows[row].Cells[0].Value;
                string client = (string)((DataGridView)sender).Rows[row].Cells[1].Value;
                string id = (string)((DataGridView)sender).Rows[row].Cells[2].Value;
                ((DataGridView)sender).Rows.RemoveAt(row);
                Order order = service.orders
                    .Where(s =>
                    s.orderNumber == client &&
                    s.guestName == id &&
                    s.goodsName == name)
                    .FirstOrDefault();
                service.orders.Remove(order);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int row = e.RowIndex;

                string name = (string)((DataGridView)sender).Rows[row].Cells[0].Value;
                double count = (double)((DataGridView)sender).Rows[row].Cells[1].Value;
                double price = (double)((DataGridView)sender).Rows[row].Cells[2].Value;
                ((DataGridView)sender).Rows.RemoveAt(row);
                List<Order> details = (List<Order>)((DataGridView)sender).DataSource;
                Order detail = details
                    .Where(s =>
                    name == s.goodsName &&
                    price == s.goodsPrice)
                    .FirstOrDefault();
                details.Remove(detail);
            }
        }
    }
}