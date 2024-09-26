using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using CarRental.Data.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class ModelService : IModelService
    {
        IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        [ValidationAspect(typeof(ModelValidator))]
        public IResult Add(Model model)
        {
            //ValidationTool.Validate(new ModelValidator(), model);

            _modelRepository.Add(model);
            return new SuccessDataResult<Model>(Messages.DataAdded);
        }

        public IResult Delete(Model model)
        {
            _modelRepository.Delete(model);
            return new SuccessDataResult<Model>(Messages.DataDeleted);
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelRepository.GetAll(), Messages.DataListed);
        }

        public IDataResult<List<Model>> GetAllByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Model>> GetAllByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Model>> GetAllByYear(int year)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Model>> GetAllByYearBetween(int minYear, int maxYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Model>> GetAllByYearGreaterThan(int year)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Model>> GetAllByYearLessThan(int year)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Model> GetById(int id)
        {
            return new SuccessDataResult<Model>(_modelRepository.Get(m => m.Id == id), Messages.DataListed);
        }

        public IDataResult<Model> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Model model)
        {
            _modelRepository.Update(model);
            return new SuccessDataResult<Model>(Messages.DataUpdated);
        }
    }
}