using BLL.Abstract;
using BLL.Constants;
using BLL.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace BLL.Concrete
{
    public class BranchManager : IBranchService
    {
        IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        [ValidationAspect(typeof(BranchValidator))]
        public IResult Add(Branch branch)
        {
            //ValidationTool.Validate(new BranchValidator(), branch);

            _branchDal.Add(branch);
            return new SuccessDataResult<Branch>(Messages.DataAdded);
        }

        public IResult Delete(Branch branch)
        {
            _branchDal.Delete(branch);
            return new SuccessDataResult<Branch>(Messages.DataDeleted);
        }

        public IDataResult<List<Branch>> GetAll()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(), Messages.DataListed);
        }

        public IDataResult<List<Branch>> GetAllByCityId(int cityId)
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(b => b.CityId == cityId), Messages.DataListed);
        }

        public IDataResult<Branch> GetById(int id)
        {
            return new SuccessDataResult<Branch>(_branchDal.Get(b => b.Id == id), Messages.DataListed);
        }

        public IResult Update(Branch branch)
        {
            _branchDal.Update(branch);
            return new SuccessDataResult<Branch>(Messages.DataUpdated);
        }
    }
}