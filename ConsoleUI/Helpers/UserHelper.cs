using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using System;

namespace ConsoleUI.Helpers
{
    public static class UserHelper
    {
        public static void Print()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            var result = userManager.GetAll();

            foreach (var user in result.Data)
            {
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"First Name: {user.FirstName}");
                Console.WriteLine($"Last Name: {user.LastName}");
                Console.WriteLine($"Email: {user.Email}");
            }
        }
    }
}