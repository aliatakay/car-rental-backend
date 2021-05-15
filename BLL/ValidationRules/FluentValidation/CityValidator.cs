using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ValidationRules.FluentValidation
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).MinimumLength(3);
            RuleFor(c => c.Name).MaximumLength(50);
            RuleFor(c => c.Name).Matches(@"^[a-zA-Z\s]+$");
        }
    }
}
