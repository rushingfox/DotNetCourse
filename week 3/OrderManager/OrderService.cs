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
        public List<Order> orders;
        public OrderService()
        {
            orders = new List<Order>();
        }
        public void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using(FileStream fs=new FileStream("s.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orders);
                Console.WriteLine("export successfully!");
            }
        }
        public void Import()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                this.orders = (List<Order>)xmlSerializer.Deserialize(fs);
                Console.WriteLine("import successfully!");
            }
        }
        public bool AddOrder(int num,string pname, string cname,int price)         //I think the detail of the order could be the same, but the order_number is not supposed to repeat
        {
            if (this.orders.FindAll(n=> { return num == n.OrderNumber; }).Count!=0)
            {
                Console.WriteLine("the order_number is in the List<Order> already!");
                return false;
            }
            else
            {
                orders.Add(new Order(num, pname, cname, price));
                return true;
            }
        }
        public void DeleteOrder(int num)
        {
            orders.RemoveAll(n => { return n.OrderNumber == num; });
        }
        public void ChangeOrder(int choice,int num,int one_four,string two_three)
        {
            switch (choice)
            {
                case 1:
                    if (this.orders.FindAll(s=>s.OrderNumber==one_four).Count!=0)
                    {
                        Console.WriteLine("the number you want to change to already existed");
                    }
                    else
                    {
                        this.orders.Find(s => s.OrderNumber == num).OrderNumber = one_four;
                    }
                    break;
                case 2:
                    this.orders.Find(s => s.OrderNumber == num).ProductName = two_three;
                    break;
                case 3:
                    this.orders.Find(s => s.OrderNumber == num).ClientName = two_three;
                    break;
                case 4:
                    this.orders.Find(s => s.OrderNumber == num).price = one_four;
                    break;
                default:
                    throw new Exception();
            }
        }
        public void OrderTheOrders(int choice = 1)//in the biginning, I try to use delegate to init the "comparison" but failed.
        {
            Comparison<Order> comparison = ((o1, o2) => { return o1.OrderNumber - o2.OrderNumber; });
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    comparison = (o1, o2) => { return String.Compare(o1.ProductName,o2.ProductName); };
                    break;
                case 3:
                    comparison = (o1, o2) => { return String.Compare(o1.ClientName, o2.ClientName); };
                    break;
                case 4:
                    comparison = (o1, o2) => { return o1.price-o2.price; };
                    break;
                default:
                    throw new Exception();
            }
            orders.Sort(comparison);
        }
        public List<Order> SearchOrder(int choice, string parameter)
        {
            switch (choice)
            {
                case 1:
                    var returnlist = orders.Where(w => w.OrderNumber == Convert.ToInt32(parameter)).OrderBy(s=>s.price);
                    return returnlist.ToList();
                case 2:
                    returnlist = orders.Where(w => w.ProductName == parameter).OrderBy(s => s.price);
                    return returnlist.ToList();
                case 3:
                    returnlist = orders.Where(w => w.ClientName == parameter).OrderBy(s => s.price);
                    return returnlist.ToList();
                case 4:
                    returnlist = orders.Where(w => w.price == Convert.ToInt32(parameter)).OrderBy(s => s.price);
                    return returnlist.ToList();
                default:
                    throw new Exception();
            }
        }
    }
}
