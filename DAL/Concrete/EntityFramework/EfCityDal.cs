using Core.DAL.EntityFramework;
using DAL.Abstract;
using Entities.Concrete;

namespace DAL.Concrete.EntityFramework
{
    public class EfCityDal : EfEntityRepositoryBase<City, RentalManagementContext>, ICityDal
    {

    }
}