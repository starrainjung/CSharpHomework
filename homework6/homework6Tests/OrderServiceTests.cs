using Microsoft.VisualStudio.TestTools.UnitTesting;
using program2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        Order order1 = new Order("001", "mina", "鞋", 600);
        Order order2 = new Order("002", "momo", "猪蹄", 20);

        OrderService Od = new OrderService();

        [TestMethod()]
        public void AddTest()
        {
            Od.Add(order1);
            Od.Add(order2);
            Assert.IsTrue(Od.orders.Count == 0);

        }

        [TestMethod()]
        public void DeleteOrderByOrderNumberTest()
        {
            Od.Add(order1);
            Od.Add(order2);
            Od.DeleteOrderByOrderNumber("003");
            Assert.IsTrue(Od.orders.Count == 0);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            Od.Add(order1);
            Od.Add(order2);
            Od.DeleteOrder("jyh");
            Assert.IsTrue(Od.orders.Count == 0);

        }

        [TestMethod()]
        public void ChangeOrderTest()
        {
            Od.Add(order1);
            Od.Add(order2);
            Od.ChangeOrder("001", "tzuyu");
            Assert.IsTrue(Od.orders.Count == 1);

        }

        [TestMethod()]
        public void ShowAllOrdersTest()
        {
            Od.Add(order1);
            Od.Add(order2);
            Od.ShowAllOrders();

        }

        [TestMethod()]
        public void ExportTest()
        {
            Od.Add(order1);
            Od.Add(order2);
            Od.Export(@"D:\test.xml");
            System.IO.FileInfo file = new System.IO.FileInfo(@"D:\test.xml");
            Assert.IsTrue(Od.orders.Count == 1);

        }

        [TestMethod()]
        public void ImportTest()
        {
            Od.Add(order1);
            Od.Add(order2);
            Od.Import(@"D:\test.xml");
            Assert.IsTrue(Od.orders.Count == 1);
        }
    }
}