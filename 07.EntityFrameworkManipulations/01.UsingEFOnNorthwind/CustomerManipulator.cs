namespace _01.UsingEFOnNorthwind
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EntityFrameworkNorthwindModel;

    public static class CustomerManipulator
    {
        public static Customer Insert(NorthwindEntities context, Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("Cant add null customer!");
            }

            context.Customers.Add(customer);
            context.SaveChanges();
            Console.WriteLine("New customer successfully added!");
            Console.WriteLine(customer);
            return customer;
        }

        public static void Modify(NorthwindEntities context, string id, string name)
        {
            var modifiedCustomer = context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            if (modifiedCustomer != null)
            {
                modifiedCustomer.CompanyName = name;
                context.SaveChanges();
                Console.WriteLine("Customer with id: {0} successfully modified!", id);
                Console.WriteLine(modifiedCustomer);
                return;
            }

            Console.WriteLine("Customer  with id: {0} not found!", id);
        }

        public static void Delete(NorthwindEntities context, string id)
        {
            var customerToDelete = context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            if (customerToDelete != null)
            {
                context.Customers.Remove(customerToDelete);
                context.SaveChanges();
                Console.WriteLine("Customer with id: {0} successfully removed!", id);
                return;
            }

            Console.WriteLine("Customer  with id: {0} not found!", id);
        }
    }
}
