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
    public class ModelManager
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        [ValidationAspect(typeof(ModelValidator))]
        public IResult Add(Model model)
        {
            //ValidationTool.Validate(new ModelValidator(), model);

            _modelDal.Add(model);
            return new SuccessDataResult<Model>(Messages.DataAdded);
        }

        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessDataResult<Model>(Messages.DataDeleted);
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(), Messages.DataListed);
        }

        public IDataResult<Model> GetById(int id)
        {
            return new SuccessDataResult<Model>(_modelDal.Get(m => m.Id == id), Messages.DataListed);
        }

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessDataResult<Model>(Messages.DataUpdated);
        }
    }
}
