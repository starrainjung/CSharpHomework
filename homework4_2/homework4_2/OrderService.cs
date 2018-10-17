using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2

{
    
    class OrderService
    {
        public List<Order> orders = new List<Order>();
       

        //添加订单
        public void add(Order od)
        {
            orders.Add(od);
        }
        //删除订单
        public void DelOrder(Order order)
        {
            orders.Remove(order);
        }

        public void DeleteOrderByOrderNumber(string ordernum)                              //根据订单号删除订单
        {
            bool count = false;
            for (int i = 0; i < orders.Count; i++)
            {
                if (ordernum == orders[i].orderNumber)
                {
                    orders.Remove(orders[i]);
                    count=true;
                }
            }
            if (count == false)
            { throw new CanNotFindOrder("没有该订单！"); } 
        }

        public void DeleteOrder(string name)                                               //根据名字删除订单
        {
            bool count = false;
            for (int i = 0; i < orders.Count; i++)
            {
                if (name == orders[i].guestName || name == orders[i].goodsName)
                {
                    orders.Remove(orders[i]);
                    count=true;
                }
            }
            if (count == false)
            { throw new CanNotFindOrder($"没有该订单！"); }
        }


        public void ChangeOrder(string oldNumber, string newName)                           //根据订单号修改顾客名
        {
            bool count = false;
            foreach (var order in orders)
            {
                if (oldNumber == order.orderNumber)
                {
                    order.guestName= newName;
                    count = true;
                }
            }
            if (count == false)
            { throw new CanNotFindOrder($"没有该订单！"); }
        }

        public void SearchOrderByNumber(string ordernum)                             //根据订单号进行查询
        {
            bool count = false;
            foreach (var order in orders)
            {
                if (ordernum == order.orderNumber)
                {
                    Console.Write(order.orderNumber + " " + order.guestName + " " + order.goodsName + " " + order.goodsPrice);
                    Console.WriteLine();
                    count = true;
                }
            }
            if (count == false)
            { throw new CanNotFindOrder($"没有该订单！"); }
        }

        public void SearchOrderByName(string name)                         //根据名查找订单
        {
            bool count = false;
            foreach (var order in orders)
            {
                if (name == order.guestName || name == order.goodsName)
                {
                    Console.Write(order.orderNumber + " " + order.guestName + " " + order.goodsName + " " + order.goodsPrice);
                    Console.WriteLine();
                    count = true;
                }
            }
            if (count == false)
            { throw new CanNotFindOrder($"没有该订单！"); }

        }
        public void ShowAllOrders()
            {
                int nCount = 1;
                foreach (var od in orders)
                {
                    Console.WriteLine("订单" + nCount);
                    od.ShowOrder();
                    nCount++;
                }
            }
        }
    }
