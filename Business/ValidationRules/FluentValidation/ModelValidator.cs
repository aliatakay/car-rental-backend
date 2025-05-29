using CarRental.Data.Contracts.Entities;
using FluentValidation;
using System;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Name).NotNull();
            RuleFor(m => m.Name).MinimumLength(1);
            RuleFor(m => m.Name).MaximumLength(200);

            RuleFor(m => m.BrandId).NotEmpty();
            RuleFor(m => m.BrandId).NotNull();
            RuleFor(m => m.BrandId).GreaterThan(0);

            RuleFor(m => m.CategoryId).NotEmpty();
            RuleFor(m => m.CategoryId).NotNull();
            RuleFor(m => m.CategoryId).GreaterThan(0);

            RuleFor(m => m.Year).NotEmpty();
            RuleFor(m => m.Year).NotNull();
            RuleFor(m => m.Year).GreaterThanOrEqualTo(2008);
            RuleFor(m => m.Year).LessThanOrEqualTo(DateTime.Now.Year);
        }
    }
}