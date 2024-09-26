using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using System;

namespace ConsoleUI.Helpers
{
    public static class CarHelper
    {
        public static void Print()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine($"Car Id: {car.Id}");
                Console.WriteLine($"Model Id: {car.ModelId}");
                Console.WriteLine($"Color Id: {car.ColorId}");
                Console.WriteLine($"Daily Price: {car.DailyPrice:0.00##} $");
                Console.WriteLine($"Available: {car.IsAvailable}");
                Console.WriteLine($"Description: {car.Description}");
            }
        }

        public static void PrintDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAllAsDto();

            foreach (var car in result.Data)
            {
                Console.WriteLine($"Car Id: {car.CarId}");
                Console.WriteLine($"Model Id: {car.ModelName}");
                Console.WriteLine($"Color Id: {car.ColorName}");
                Console.WriteLine($"Daily Price: {car.DailyPrice:0.00##} $");
                Console.WriteLine($"Available: {car.IsAvailable}");
                Console.WriteLine($"Description: {car.Description}");
            }
        }
    }
}