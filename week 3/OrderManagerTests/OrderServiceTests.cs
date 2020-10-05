using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(1, "wjh", "whu", 22);
            Assert.AreEqual(orderService.orders[0],new Order(1,"wjh","whu",22));
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(1, "wjh", "whu", 22);
            orderService.DeleteOrder(1);
            Assert.IsTrue(orderService.orders.Count==0);
        }

        [TestMethod()]
        public void ChangeOrderTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(1, "wjh", "whu", 22);
            orderService.ChangeOrder(1, 1, 4, "");
            Assert.AreEqual(orderService.orders[0], new Order(4, "wjh", "whu", 22));
        }

        [TestMethod()]
        public void OrderTheOrdersTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(1, "wjh", "whu", 22);
            orderService.AddOrder(2, "yzy", "whu", 7);
            orderService.OrderTheOrders(4);
            Assert.AreEqual(orderService.orders[0], new Order(2, "yzy", "whu", 7));
        }

        [TestMethod()]
        public void SearchOrderTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(1, "wjh", "whu", 22);
            orderService.AddOrder(2, "yzy", "whu", 7);
            Assert.AreEqual(orderService.orders[1], orderService.SearchOrder(2, "yzy")[0]);
        }
    }
}