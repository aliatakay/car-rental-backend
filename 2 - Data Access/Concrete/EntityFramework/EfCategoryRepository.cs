using Core.Repository.EntityFramework;
using CarRental.Data.Abstract;
using Entities.Concrete;

namespace CarRental.Data.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category, RentalManagementContext>, ICategoryRepository
    {

    }
}