using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using CarRental.Data.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class BranchService : IBranchService
    {
        IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        [ValidationAspect(typeof(BranchValidator))]
        public IResult Add(Branch branch)
        {
            //ValidationTool.Validate(new BranchValidator(), branch);

            _branchRepository.Add(branch);
            return new SuccessDataResult<Branch>(Messages.DataAdded);
        }

        public IResult Delete(Branch branch)
        {
            _branchRepository.Delete(branch);
            return new SuccessDataResult<Branch>(Messages.DataDeleted);
        }

        public IDataResult<List<Branch>> GetAll()
        {
            return new SuccessDataResult<List<Branch>>(_branchRepository.GetAll(), Messages.DataListed);
        }

        public IDataResult<List<Branch>> GetAllByCityId(int cityId)
        {
            return new SuccessDataResult<List<Branch>>(_branchRepository.GetAll(b => b.CityId == cityId), Messages.DataListed);
        }

        public IDataResult<Branch> GetById(int id)
        {
            return new SuccessDataResult<Branch>(_branchRepository.Get(b => b.Id == id), Messages.DataListed);
        }

        public IResult Update(Branch branch)
        {
            _branchRepository.Update(branch);
            return new SuccessDataResult<Branch>(Messages.DataUpdated);
        }
    }
}