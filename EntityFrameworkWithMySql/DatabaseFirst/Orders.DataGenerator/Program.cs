using Orders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DataGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var random = RandomDataGenerator.Instance;
            var db = new ordersEntities();

            var listOfGenerators = new List<IDataGenerator> {
                new OrderDataGenerator(random, db, 20)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }
        }
    }
}
