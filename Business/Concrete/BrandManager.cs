using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using System.Collections.Generic;
using CarRental.Data.Contracts.Entities;
using CarRental.Data.Contracts.Repositories;

namespace CarRental.Business.Concrete
{
    public class BrandService : IBrandService
    {
        IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            //ValidationTool.Validate(new BrandValidator(), brand);

            _brandRepository.Add(brand);
            return new SuccessDataResult<Brand>(Messages.DataAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandRepository.Delete(brand);
            return new SuccessDataResult<Brand>(Messages.DataDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandRepository.GetAll(), Messages.DataListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandRepository.Get(b => b.Id == id), Messages.DataListed);
        }

        public IDataResult<Brand> GetByName(string name)
        {
            return new SuccessDataResult<Brand>(_brandRepository.Get(b => b.Name == name), Messages.DataListed);
        }

        public IResult Update(Brand brand)
        {
            _brandRepository.Update(brand);
            return new SuccessDataResult<Brand>(Messages.DataUpdated);
        }
    }
}