using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Helpers
{
    public static class ColorHelper
    {
        public static void Add()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            List<Color> colors = new List<Color>
            {
                new Color { ColorName = "Red"},
                new Color { ColorName = "Blue"},
                new Color { ColorName = "Black"},
                new Color { ColorName = "White"},
                new Color { ColorName = "Orange"},
                new Color { ColorName = "Dark Blue"}
            };

            foreach (var color in colors)
            {
                colorManager.Add(color);
            }
        }

        public static void Print()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();

            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }
    }
}
