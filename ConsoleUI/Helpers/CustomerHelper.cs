using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using System;

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
                Console.WriteLine($"Customer Id: {customer.Id}");
                Console.WriteLine($"User Id: {customer.UserId}");
                Console.WriteLine($"Company Name: {customer.CompanyName}");
            }
        }
    }
}