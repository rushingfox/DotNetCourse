using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.model
{
    public class dbcontext:DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options):base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Order> orders { get; set; }
    }
}
