namespace EntityFrameworkNorthwindModel
{
    public partial class Customer
    {
        public override string ToString()
        {
            return string.Format("ID: {0}, Company Name: {1}; Contact: {2}; Address: {4}, {5}, {8}",
            this.CustomerID,
            this.CompanyName,
            this.ContactName,
            this.ContactTitle,
            this.Address,
            this.City,
            this.Region,
            this.PostalCode,
            this.Country,
            this.Phone,
            this.Fax);
        }
    }

    public partial class Employee
    {
        public override string ToString()
        {
            return string.Format("ID: {0}; Full Name: {1}; Address: {2}, {3}, {4}; Manager: {5}",
            this.EmployeeID,
            this.FirstName + " " + this.LastName,
            this.Address,
            this.City,
            this.Country,
            this.Employee1
            );
        }
    }

    public partial class Order
    {
        public override string ToString()
        {
            return string.Format("Customer: {0}; Employee: {1}; Order Date: {2}",
            this.Customer,
            this.Employee,
            this.OrderDate
            );
        }
    }
}
