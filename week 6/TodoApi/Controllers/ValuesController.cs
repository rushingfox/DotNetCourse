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
        public dbcontext db;
        public ValuesController(dbcontext dbcontext1)
        {
            this.db = dbcontext1;
        }

        //search order and return
        // GET api/values
        [HttpGet]
        public ActionResult<List<Order>> Get(string n,string pname,string cname,string pr)
        {
            IQueryable<Order> query = db.orders;
            if (n!=null)
            {
                query = query.Where(p => p.OrderNumber == Convert.ToInt32(n));
            }
            if (pname != null)
            {
                query = query.Where(p => p.ProductName == pname);
            }
            if (cname != null)
            {
                query = query.Where(p => p.ClientName == cname);
            }
            if (pr != null)
            {
                query = query.Where(p => p.price == Convert.ToInt32(pr));
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
        public void Post(Order order)
        {
            db.orders.Add(order);
            db.SaveChanges();
        }

        //change order
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, Order neworder)
        {
            var order = db.orders.FirstOrDefault(p => p.OrderNumber == id);
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
            var order = db.orders.FirstOrDefault(p => p.OrderNumber == id);
            if (order != null)
            {
                db.orders.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
