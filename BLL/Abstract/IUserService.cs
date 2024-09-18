﻿using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace BLL.Abstract
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