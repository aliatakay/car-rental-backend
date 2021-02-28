using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Helpers
{
    public static class CustomerHelper
    {
        public static void Print()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetAll();

            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }
        public static void Add()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            List<Customer> customers = new List<Customer>
            {
                new Customer { UserId = 6, CompanyName = "CompanyName 1"},
                new Customer { UserId = 7, CompanyName = "CompanyName 2"},
                new Customer { UserId = 8, CompanyName = "CompanyName 3"},
                new Customer { UserId = 9, CompanyName = "CompanyName 4"},
                new Customer { UserId = 10, CompanyName = "CompanyName 5"}
            };

            foreach (var customer in customers)
            {
                customerManager.Add(customer);
            }
        }
    }
}
