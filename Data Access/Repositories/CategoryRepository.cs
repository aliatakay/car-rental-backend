using Core.Repository.EntityFramework;
using CarRental.Data.Contracts.Repositories;
using CarRental.Data.Contracts.Entities;

namespace CarRental.Data.Repositories
{
    public class CategoryRepository : EntityRepositoryBase<Category, RentalManagementContext>, ICategoryRepository
    {

    }
}