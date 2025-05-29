using CarRental.Data.Contracts.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace CarRental.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int id);
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<User> GetByEmail(string email);
    }
}