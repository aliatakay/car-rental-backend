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
                             join car in context.Cars
                             on brand.BrandId equals car.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice
                             };
                
                return result.ToList();
            }
        }
    }
}
