using Core.Repository.EntityFramework;
using CarRental.Data.Contracts.Repositories;
using CarRental.Data.Contracts.Entities;

namespace CarRental.Data.Repositories
{
    public class ModelRepository : EntityRepositoryBase<Model, RentalManagementContext>, IModelRepository
    {

    }
}