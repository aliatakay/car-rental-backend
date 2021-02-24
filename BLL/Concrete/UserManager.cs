﻿using BLL.Abstract;
using BLL.Constants;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.DataListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == id), Messages.DataListed);

        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.DataUpdated);
        }
    }
}