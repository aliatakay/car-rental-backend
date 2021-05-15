using System.Linq;
using Core.DAL.EntityFramework;
using DAL.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalManagementContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentalManagementContext context = new RentalManagementContext())
            {
                var result = from brand in context.Brands
                             join model in context.Models
                             on brand.Id equals model.BrandId
                             join car in context.Cars
                             on model.Id equals car.ModelId
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.Name,
                                 ModelName = model.Name,
                                 ColorName = color.Name,
                                 ModelYear = model.Year,
                                 DailyPrice = car.DailyPrice,
                                 IsAvailable = car.IsAvailable,
                                 Description = car.Description
                             };
                
                return result.ToList();
            }
        }
    }
}
