using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

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
                Console.WriteLine(user.Email);
            }
        }
        public static void Add()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            List<User> users = new List<User>
            {
                new User { FirstName = "Name 1", LastName = "LastName 1", Email = "mail1@mail.com", Password = "Password1"},
                new User { FirstName = "Name 2", LastName = "LastName 2", Email = "mail2@mail.com", Password = "Password2"},
                new User { FirstName = "Name 3", LastName = "LastName 3", Email = "mail3@mail.com", Password = "Password3"},
                new User { FirstName = "Name 4", LastName = "LastName 4", Email = "mail4@mail.com", Password = "Password4"},
                new User { FirstName = "Name 5", LastName = "LastName 5", Email = "mail5@mail.com", Password = "Password5"}
            };

            foreach (var user in users)
            {
                userManager.Add(user);
            }
        }
    }
}
