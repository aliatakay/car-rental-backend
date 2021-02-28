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
                new Brand { BrandName = "BMW"},
                new Brand { BrandName = "Audi"},
                new Brand { BrandName = "Ford"},
                new Brand { BrandName = "Fiat"},
                new Brand { BrandName = "Tesla"},
                new Brand { BrandName = "Mercedes"}
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
                Console.WriteLine(brand.BrandName);
            }
        }
    }
}
