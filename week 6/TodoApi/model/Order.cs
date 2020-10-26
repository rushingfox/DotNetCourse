using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.model
{
    [Serializable]
    public class Order
    {

        [Key]
        public int OrderNumber { get; set; }
        public string ProductName { get; set; }
        public string ClientName { get; set; }
        public int price { get; set; }
        public Order()
        {

        }
        public Order(int n,string p,string c, int pr)
        {
            this.OrderNumber = n;
            this.ProductName = p;
            this.ClientName = c;
            this.price = pr;
        }
        override public string ToString()
        {
            return $"ordernumber:{OrderNumber},productname:{ProductName},clientname{ClientName},price:{price}";
        }
        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            return m!=null&&m.OrderNumber==this.OrderNumber&&m.ClientName==this.ClientName&&m.ProductName==this.ProductName&&m.price==this.price;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //all the elements in this class are value-type or string, so we can just use the MemberwiseClone function to copy the object!
    }
}
