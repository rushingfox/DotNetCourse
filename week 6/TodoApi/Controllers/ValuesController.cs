using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.model;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly dbcontext db;
        public ValuesController(dbcontext dbcontext1)
        {
            this.db = dbcontext1;
        }

        //search order and return
        // GET api/values
        [HttpGet]
        public ActionResult<List<Order>> Get(int n,string pname,string cname,int p)
        {
            IQueryable<Order> query = db.dbOrders;
            if (n!=null)
            {
                query = query.Where(p => p.OrderNumber == n);
            }
            if (pname != null)
            {
                query = query.Where(p => p.ProductName == pname);
            }
            if (n != null)
            {
                query = query.Where(p => p.ClientName == cname);
            }
            if (n != null)
            {
                query = query.Where(p => p.price == p);
            }
            return query.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        //add order
        // POST api/values
        [HttpPost]
        public List<Order> Post(Order order)
        {
            db.dbOrders.Add(order);
            db.SaveChanges();
        }

        //change order
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, Order neworder)
        {
            var order = db.dbOrders.FirstOrDefault(p => p.OrderNumber == id);
            if (order != null)
            {
                order = neworder;
                db.SaveChanges();
            }
        }

        //delete order
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var order = db.dbOrders.FirstOrDefault(p => p.OrderNumber == id);
            if (order != null)
            {
                db.dbOrders.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
