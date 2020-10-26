using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TodoApi.model
{
    public class dbcontext:DbContext
    {
        public dbcontext():base("orderdatabase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<dbcontext>());
        }
        public DbSet<Order> dbOrders { get; set; }
    }
}
