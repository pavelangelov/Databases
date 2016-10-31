using Nortwind_Entity_Operations.Data;
using Nortwind_Entity_Operations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind_Entity_Operations
{
    public class Startup
    {
        public static void Main()
        {
            // Add new Customer to DB 
            //CustomersDAO.AddNewCustomer("Telerik", "12347", "Bulgaria", "Sofia", "0888111111");

            // Add new Customer to DB using POCO
            //CustomersDAO.AddNewCustomer(new CustomerPoco
            //{
            //    Address = "Mladost",
            //    City = "Sofia",
            //    CompanyName = "Progress",
            //    ContactName = "Doncho Minkov",
            //    CustomerID = "DMTAP",
            //    Country = "Bulgaria",
            //    Phone = "0888123456"
            //});


            //var allCustomers = CustomersDAO.ListAllCustomers();

            //Console.WriteLine(CustomersDAO.UpdateCustomer("12345", "Pavel Angelov"));
            //Console.WriteLine(CustomersDAO.UpdateCustomer("12346", "Hristo Hristov"));
            //Console.WriteLine(CustomersDAO.UpdateCustomer("12347", "Pesho Peshev"));

            //Console.WriteLine(CustomersDAO.ListAllCustomers());

            //var message = CustomersDAO.RemoveCustomer("12347");
            //Console.WriteLine(message);

            var orders = CustomersDAO.ListAllCustomersByOrdersYearAndShippedCountry(1997, "Canada");
            Console.WriteLine(orders);

            var customers = CustomersDAO.ListAllCustomersWithSqlQuery(1997, "Canada");
            Console.WriteLine(customers);
        }
    }
}
