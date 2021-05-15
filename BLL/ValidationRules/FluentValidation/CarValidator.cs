using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelId).NotEmpty();
            RuleFor(c => c.ModelId).NotNull();
            RuleFor(c => c.ModelId).GreaterThan(0);

            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorId).NotNull();
            RuleFor(c => c.ColorId).GreaterThan(0);

            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            RuleFor(c => c.IsAvailable).NotEmpty();
            RuleFor(c => c.IsAvailable).NotNull();

            RuleFor(c => c.Description).MaximumLength(500);
        }
    }
}
