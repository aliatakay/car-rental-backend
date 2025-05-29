using Core.Repository.EntityFramework;
using CarRental.Data.Contracts.Entities;
using CarRental.Data.Contracts.Repositories;

namespace CarRental.Data.Repositories
{
    public class BranchRepository : EntityRepositoryBase<Branch, RentalManagementContext>, IBranchRepository
    {

    }
}