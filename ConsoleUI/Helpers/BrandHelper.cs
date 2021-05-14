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
        public static void Add()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            List<Brand> brands = new List<Brand>
            {
                new Brand { Name = "BMW"},
                new Brand { Name = "Audi"},
                new Brand { Name = "Ford"},
                new Brand { Name = "Fiat"},
                new Brand { Name = "Tesla"},
                new Brand { Name = "Mercedes"}
            };

            foreach (var brand in brands)
            {
                brandManager.Add(brand);
            }
        }

        public static void Print()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.Name);
            }
        }
    }
}
