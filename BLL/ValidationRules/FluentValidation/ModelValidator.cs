using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Name).MinimumLength(2);
            RuleFor(m => m.Name).MaximumLength(200);

            RuleFor(m => m.BrandId).NotEmpty();

            RuleFor(m => m.CategoryId).NotEmpty();

            RuleFor(m => m.Year).NotEmpty();
            RuleFor(m => m.Year).GreaterThanOrEqualTo(2008);
            RuleFor(m => m.Year).LessThanOrEqualTo(DateTime.Now.Year);
        }
    }
}
