using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4_2
{
    class Program2
    {
        class Order {
            
            internal string OrderNumber;

            internal string OrderName;

            public Order(String OrderNumber, String OrderName = "")
            {
                this.OrderNumber = OrderNumber;
                this.OrderName = OrderName;
            }
        }
        class OrderDetails {
            private string goodName;
            private int goodNumber;
            private double Price;

            public OrderDetails(string goodName, int goodNumber, double singlePrice)
            {
                this.goodName = goodName;
                this.goodNumber = goodNumber;
                this.Price = singlePrice;
            }
        }
        class OrderService {
            /*1、用list储存订单数据
             2、删除订单信息
             3、查询（按不同类型）
             4、显示
             */

            public static List<Order> orders = new List<Order>();

            public static void delete(string OrderNumber)
            {
                bool Y = false;//判断是否有该订单号的订单
                foreach (Order o in orders)
                {
                    if (o.OrderNumber == OrderNumber)
                    {
                        Y = true;
                        orders.Remove(o);
                        break;
                    }
                }
                if (Y == false)
                {
                    Console.WriteLine("没有该订单号");
                }
            }
        }


        static void Main(string[] args)
        {
            /*异常处理、*/
        }


    }
}
