using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext() : base("OrdersConnectionString")
        {
        }

        public IDbSet<Order> Orders { get; set; }
    }
}
