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
            //// Task 2. Add new Customer to DB 
            //CustomersDAO.AddNewCustomer("Telerik", "12347", "Bulgaria", "Sofia", "0888111111");

            //// Task 2. Add new Customer to DB using POCO
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

            //// Task 2. Modify customer
            //Console.WriteLine(CustomersDAO.UpdateCustomer("12345", "Pavel Angelov"));
            //Console.WriteLine(CustomersDAO.UpdateCustomer("12346", "Hristo Hristov"));
            //Console.WriteLine(CustomersDAO.UpdateCustomer("12347", "Pesho Peshev"));

            //Console.WriteLine(CustomersDAO.ListAllCustomers());

            //// Task 2. Remove customer by Id
            //var message = CustomersDAO.RemoveCustomer("12347");
            //Console.WriteLine(message);

            //// Task 3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            //var orders = CustomersDAO.ListAllCustomersByOrdersYearAndShippedCountry(1997, "Canada");
            //Console.WriteLine(orders);

            //// Task 4. Implement previous by using native SQL query and executing it through the DbContext.
            //var customers = CustomersDAO.ListAllCustomersWithSqlQuery(1997, "Canada");
            //Console.WriteLine(customers);

            //// Task 5. Write a method that finds all the sales by specified region and period (start / end dates).
            //var ordersInRegion = CustomersDAO.ListAllSalesByRegionAndPeriod("Lara", new DateTime(1997, 1, 1), new DateTime(1998, 1, 1));
            //Console.WriteLine(ordersInRegion);

            // Task 6. Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext.
            CustomersDAO.TwinDatabase();
        }
    }
}
