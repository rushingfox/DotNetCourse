using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace OrderManager
{
    public class OrderService
    {
        public OrderService()
        {

        }
        public bool AddOrder(int num,string pname, string cname,int price)         //I think the detail of the order could be the same, but the order_number is not supposed to repeat
        {
            using (var db = new dbcontext())
            {
                var order = new Order() { OrderNumber = num, ProductName = pname, ClientName = cname, price = price };
                db.dbOrders.Add(order);
                db.SaveChanges();
            }
            return true;
        }
        public void DeleteOrder(int num)
        {
            using (var db = new dbcontext())
            {
                var order = db.dbOrders.FirstOrDefault(p => p.OrderNumber == num);
                if (order!=null)
                {
                    db.dbOrders.Remove(order);
                    db.SaveChanges();
                }
            }
        }
        public void ChangeOrder(int choice,int num,int one_four,string two_three)
        {
            switch (choice)
            {
                case 1:
                    using (var db = new dbcontext())
                    {
                        var order = db.dbOrders.FirstOrDefault(p => p.OrderNumber == num);
                        if (order!=null)
                        {
                            order.OrderNumber = one_four;
                            db.SaveChanges();
                        }
                    }
                    break;
                case 2:
                    using (var db = new dbcontext())
                    {
                        var order = db.dbOrders.FirstOrDefault(p => p.OrderNumber == num);
                        if (order != null)
                        {
                            order.ProductName = two_three;
                            db.SaveChanges();
                        }
                    }
                    break;
                case 3:
                    using (var db = new dbcontext())
                    {
                        var order = db.dbOrders.FirstOrDefault(p => p.OrderNumber == num);
                        if (order != null)
                        {
                            order.ClientName = two_three;
                            db.SaveChanges();
                        }
                    }
                    break;
                case 4:
                    using (var db = new dbcontext())
                    {
                        var order = db.dbOrders.FirstOrDefault(p => p.OrderNumber == num);
                        if (order != null)
                        {
                            order.price = one_four;
                            db.SaveChanges();
                        }
                    }
                    break;
                default:
                    throw new Exception();
            }
        }
        public List<Order> SearchOrder(int choice, string parameter)
        {
            switch (choice)
            {
                case 1:
                    using (var db = new dbcontext())
                    {
                        var query = db.dbOrders.Where(b => b.OrderNumber == Convert.ToInt32(parameter));
                        return (List<Order>)query;
                    }
                case 2:
                    using (var db = new dbcontext())
                    {
                        var query = db.dbOrders.Where(b => b.ProductName == parameter);
                        return (List<Order>)query;
                    }
                case 3:
                    using (var db = new dbcontext())
                    {
                        var query = db.dbOrders.Where(b => b.ClientName == parameter);
                        return (List<Order>)query;
                    }
                case 4:
                    using (var db = new dbcontext())
                    {
                        var query = db.dbOrders.Where(b => b.price == Convert.ToInt32(parameter));
                        return (List<Order>)query;
                    }
                default:
                    throw new Exception();
            }
        }
    }
}
