using CodeFirst.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new OrdersDbContext();

            var orders = db.Orders.Any();
            Console.WriteLine(orders);
        }
    }
}
