using BLL.Abstract;
using BLL.Constants;
using BLL.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            //ValidationTool.Validate(new CategoryValidator(), category);

            _categoryDal.Add(category);
            return new SuccessDataResult<Category>(Messages.DataAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessDataResult<Category>(Messages.DataDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.DataListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Id == id), Messages.DataListed);
        }

        public IDataResult<Category> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessDataResult<Category>(Messages.DataAdded);
        }
    }
}
