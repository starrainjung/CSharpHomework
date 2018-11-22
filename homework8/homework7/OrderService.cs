using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace homework7
{
    class OrderService
    {
        public List<Order> orders = new List<Order>();


        //添加订单
        public void Add(Order od)
        {
            orders.Add(od);
        }
        //根据订单号删除订单
        public void DeleteOrderByOrderNumber(string ordernum)
        {
            bool count = false;
            for (int i = 0; i < orders.Count; i++)
            {
                if (ordernum == orders[i].orderNumber)
                {
                    orders.Remove(orders[i]);
                    count = true;
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
                    count = true;
                }
            }
            if (count == false)
            { throw new CanNotFindOrder($"没有该订单！"); }
        }


        public void ChangeOrder(string Number, string newName)                           //根据订单号修改顾客名
        {
            bool count = false;
            foreach (var order in orders)
            {
                if (Number == order.orderNumber)
                {
                    order.guestName = newName;
                    count = true;
                }
            }
            if (count == false)
            { throw new CanNotFindOrder($"没有该订单！"); }
        }

        public void SearchOrderByNumber(string ordernum)                             //根据订单号进行查询(linq)
        {
            var selorder = from n in orders where n.orderNumber == ordernum select n;

            foreach (var n in selorder)
            {
                Console.Write(n.orderNumber + " " + n.guestName + " " + n.goodsName + " " + n.goodsPrice);
                Console.WriteLine();
            }

        }

        public void SearchOrderByName(string name)                         //根据名查找订单(linq)
        {

            var selorder = from n in orders where n.guestName == name || n.goodsName == name select n;
            foreach (var n in selorder)
            {
                Console.Write(n.orderNumber + " " + n.guestName + " " + n.goodsName + " " + n.goodsPrice);
                Console.WriteLine();

            }
        }

        public void ShowAllOrders()
        {
            int nCount = 1;
            foreach (var od in orders)
            {
                Console.Write("订单" + nCount + ":    ");
                od.ShowOrder();
                Console.WriteLine();
                nCount++;
            }
        }

        public void Export(string FileName = "jxy.xml")
        {

            XmlSerializer xmler = new XmlSerializer(typeof(OrderService));


            FileStream newfile = new FileStream(FileName, FileMode.Create);
            xmler.Serialize(newfile, this);
            newfile.Close();


            //在控制台显示xml文件的内容    书p403
            XmlDocument DOC = new XmlDocument
            {
                PreserveWhitespace = true
            };
            DOC.Load(FileName);
            Console.Write(DOC.InnerText);

        }

        public void Import(string FileName)
        {
            FileStream f = new FileStream(FileName, FileMode.Open);
            XmlSerializer xmler = new XmlSerializer(typeof(OrderService));
            OrderService orderService = (OrderService)xmler.Deserialize(f);
            f.Close();

            Console.WriteLine("反序列后的输出内容: ");
            orderService.ShowAllOrders();

        }
    }
}
