using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using System;

namespace ConsoleUI.Helpers
{
    public static class ColorHelper
    {
        public static void Print()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();

            foreach (var color in result.Data)
            {
                Console.WriteLine($"Color Id: {color.Id}");
                Console.WriteLine($"Color Name: {color.Name}");
            }
        }
    }
}