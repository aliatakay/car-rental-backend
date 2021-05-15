using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Helpers
{
    public static class BrandHelper
    {
        public static void Print()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            foreach (var brand in result.Data)
            {
                Console.WriteLine($"Brand Id: {brand.Id}");
                Console.WriteLine($"Brand Name: {brand.Name}");
            }
        }
    }
}
