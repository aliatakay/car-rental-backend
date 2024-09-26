using Core.Repository.EntityFramework;
using CarRental.Data.Abstract;
using Entities.Concrete;

namespace CarRental.Data.Concrete.EntityFramework
{
    public class EfModelRepository : EfEntityRepositoryBase<Model, RentalManagementContext>, IModelRepository
    {

    }
}