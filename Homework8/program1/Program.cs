using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.Runtime.Serialization;

using System.Xml.Serialization;
using System.Xml.Xsl;

/*
 * 验证数据并利用xslt写html
 */
namespace program1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
               

                Goods coffee = new Goods(1, "coffee", 39);
                Goods milktea = new Goods(2, "milktea", 12);
                Goods cola = new Goods(3, "cola", 3.5);

                OrderDetail orderDetails1 = new OrderDetail(1, coffee, 1);
                OrderDetail orderDetails2 = new OrderDetail(2, milktea, 2);
                OrderDetail orderDetails3 = new OrderDetail(3, cola, 5);

                Order order1 = new Order("001", "momo","13471087643");
                Order order2 = new Order("002", "sana", "13471087644");
                Order order3 = new Order("003", "chae", "13471087645");

                order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);

                order2.AddDetails(orderDetails2);
                order3.AddDetails(orderDetails1);
                order3.AddDetails(orderDetails3);
                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);
                //显示所有订单
                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine(os.legal());

               

                Console.WriteLine("___________序列化___和____反序列化__________");
                Console.WriteLine("_____________");
                os.Export("../../orderService.xml");
          
                List<Order> ods = OrderService.Import(@"../../orderService.xml").QueryAllOrders();
                foreach (Order od in ods)
                    Console.WriteLine(od.ToString());

                XslCompiledTransform trans = new XslCompiledTransform();
                trans.Load(@"../../orderService.xslt");
                trans.Transform(@"../../orderService.xml", @"../../orderService.html");

              

                Console.WriteLine("END");

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }


       

    }
}
