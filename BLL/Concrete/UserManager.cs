using BLL.Abstract;
using BLL.Constants;
using BLL.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
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

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            //ValidationTool.Validate(new UserValidator(), user);

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

        public IDataResult<List<User>> GetAllByFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAllByLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.DataListed);

        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.DataUpdated);
        }
    }
}
