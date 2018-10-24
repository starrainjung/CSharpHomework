using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order("001", "mina", "鞋",600);
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


            Console.WriteLine("订单改变前：");
            Od.ShowAllOrders();
            Console.WriteLine();


            Console.WriteLine("搜索005号订单和搜索鞋的订单结果：");
            Od.SearchOrderByNumber("005");                  
            Od.SearchOrderByName("鞋");
            Console.WriteLine();


            Od.ChangeOrder("004", "chae");
            Od.DeleteOrderByOrderNumber("006");     


            Console.WriteLine("订单改变后：");
            Od.ShowAllOrders();
            Console.WriteLine();


            Od.Export();
            Console.WriteLine();
            Od.Import("s.xml");
            Console.ReadKey();
        }
    }

}
        