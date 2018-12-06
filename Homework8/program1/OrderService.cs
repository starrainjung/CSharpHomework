using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Runtime.Serialization;

using System.Xml.Serialization;

using System.Text.RegularExpressions;


/*

 
     */
namespace program1
{
    [Serializable]
    public class OrderService
    {

        public List<Order> orderDict = new List<Order>();
      //  public void AddOrder(Order order) => orderDict.Add(order);
        public void AddOrder(Order order)
        {
            if (orderDict.Contains(order))
            {
                throw new Exception($"order-{order.OrderId} is already existed!");
            }
            orderDict.Add(order);
        }

        public List<Order> QueryAllOrders()
        {           
            return orderDict.ToList();
        }

        public Order GetById(int orderId)
        {
            return orderDict[orderId];
        }

        public List<Order> QueryByGoodsName(string goodsName)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in orderDict)
            {
                foreach (OrderDetail detail in order.Details)
                {
                    if (detail.Goods.GoodName == goodsName)
                    {
                        result.Add(order);
                        break;
                    }
                }
            }
            return result;
        }

        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderDict
                .Where(order => order.OrderCustomer == customerName);
            return query.ToList();
        }
        public List<Order> QueryByOrderID(string orderId)
        {
           // String unit1 = Convert.ToUInt32(orderId);
            var query = orderDict
                .Where(order => order.OrderId == orderId);
            return query.ToList();
        }
        //查询金额大于传入参数的订单
        public List<Order> QueryByAmount(double Amount)
        {
            var query = orderDict
                .Where(order => order.Amount >= Amount);
            return query.ToList();
        }
        public OrderService() { }
        public void Export(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderService));
            string xmlFileName = path;
            FileStream fs = new FileStream(xmlFileName, FileMode.Create);
            xmlSerializer.Serialize(fs, this);
            fs.Close();         
        }
        public static OrderService Import(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderService));
            OrderService OrderService = (OrderService)xmlSerializer.Deserialize(file);
            file.Close();
            return OrderService;
        }



        //验证数据是否符合格式要求
        //首先 订单号 是不是 十一位 数字！  
        //其次，年是不是正确  
        //第三  月  1-12  
        //第四  日  用一个“十三个月”的数组存 各月的日期///不对 还要考虑闰年平年。。那。 行的吧
        //第五   电话号码是不是都是数字 并且有 11 位 （这里假装没有  086-1243****的情况好了 ）
        public bool legal()
        {
            bool TF = true;
            int[] days = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            List<String> result = new List<String>();
            string Num = @"^[0-9]{11}";
            Regex rx = new Regex(Num);

            foreach (Order order in orderDict)
            {
                bool TF1 = true;
                //电话号码是否合格
                Match m1 = rx.Match(order.phoneNumber);
                if (m1.Success == false || order.phoneNumber.Length != 11)
                {
                    Console.WriteLine($"order-{order.OrderId}客户-{order.OrderCustomer}电话-{order.phoneNumber}不正确！");
                    TF1 = false;
                }

                //订单号是否合格
                Match m2 = rx.Match(order.OrderId);
                if (order.OrderId.Length==11 && m2.Success == true)
                {
                    if (int.Parse(order.OrderId.Substring(0, 4)) > DateTime.Now.Year)
                    {
                        TF1 = false;
                        Console.WriteLine($"order-{order.OrderId} 日期不正确！");
                    }
                    else if (int.Parse(order.OrderId.Substring(4, 2)) > 12 || int.Parse(order.OrderId.Substring(4, 2)) < 1)
                    {
                        TF1 = false;
                        Console.WriteLine($"order-{order.OrderId} 日期不正确!");
                    }
                    else if (days[int.Parse(order.OrderId.Substring(4, 2))] < int.Parse(order.OrderId.Substring(6, 2)) || int.Parse(order.OrderId.Substring(6, 2)) < 1
                        //   这里搞不清楚 先不考虑闰年2月29日了
                        //不是闰年                    
                        //!(int.Parse(order.OrderId.Substring(0, 4)) % 400 == 0 || (int.Parse(order.OrderId.Substring(0, 4)) % 4 == 0 && int.Parse(order.OrderId.Substring(0, 4)) % 100 != 0))
                        // ||     //不是2月
                        // int.Parse(order.OrderId.Substring(4, 2)) != 2
                        // ||     //不是29号
                        // int.Parse(order.OrderId.Substring(6, 2)) != 29
                         )                   
                    {
                        TF1 = false;
                        Console.WriteLine($"order-{order.OrderId} 日期不正确!");
                    }
                    //是否有重复 
                        if (result.Contains(order.OrderId))
                        {
                            Console.WriteLine($"order-{order.OrderId} appeared more than once!");
                            TF1 = false;
                        }
                    if (TF1) result.Add(order.OrderId);
                    else TF = false;
                    
                }
                else
                {
                    Console.WriteLine($"order-{order.OrderId} 不是十一位数！");
                    TF = false;
                }
            }
            return TF;
            
        }

    }
}
