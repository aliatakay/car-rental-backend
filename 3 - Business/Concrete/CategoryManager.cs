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
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            //ValidationTool.Validate(new CategoryValidator(), category);

            _categoryRepository.Add(category);
            return new SuccessDataResult<Category>(Messages.DataAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryRepository.Delete(category);
            return new SuccessDataResult<Category>(Messages.DataDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryRepository.GetAll(), Messages.DataListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryRepository.Get(c => c.Id == id), Messages.DataListed);
        }

        public IDataResult<Category> GetByName(string name)
        {
            return new SuccessDataResult<Category>(_categoryRepository.Get(c => c.Name == name), Messages.DataListed);
        }

        public IResult Update(Category category)
        {
            _categoryRepository.Update(category);
            return new SuccessDataResult<Category>(Messages.DataAdded);
        }
    }
}