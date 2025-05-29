using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using CarRental.Data.Contracts.Entities;
using System.Collections.Generic;
using CarRental.Data.Contracts.Repositories;

namespace CarRental.Business.Concrete
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            //ValidationTool.Validate(new UserValidator(), user);

            _userRepository.Add(user);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Delete(User user)
        {
            _userRepository.Delete(user);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userRepository.GetAll(), Messages.DataListed);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userRepository.Get(u => u.Email == email), Messages.DataListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userRepository.Get(u => u.Id == id), Messages.DataListed);

        }

        public IResult Update(User user)
        {
            _userRepository.Update(user);
            return new SuccessResult(Messages.DataUpdated);
        }
    }
}