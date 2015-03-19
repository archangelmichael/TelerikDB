using Orders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DataGenerator
{
    internal class OrderDataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private ordersEntities db;
        private int count;

        public OrderDataGenerator(IRandomDataGenerator randomDataGenerator, ordersEntities entities, int ordersCount)
        {
            this.random = randomDataGenerator;
            this.db = entities;
            this.count = ordersCount;
        }

        public void Generate()
        {
            Console.Write("Generating orders.");
            for (int i = 0; i < this.count; i++)
            {
                var newOrder = new order
                {
                    Name = this.random.GetRandomStringWithRandomLength(5, 20),
                    Date = this.random.GetRandomDateSinceNow(30),
                    Info = this.random.GetRandomStringWithRandomLength(20, 50)
                };

                this.db.orders.Add(newOrder);

                if (i % 5 == 0)
                {
                    Console.Write(".");
                    this.db.SaveChanges();
                }
            }
            Console.Write("Orders generated successfully!");
        }
    }
}
