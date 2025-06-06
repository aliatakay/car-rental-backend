﻿using CarRental.Data.Contracts.Entities;
using CarRental.Data.Contracts.Entities;
using FluentValidation;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Name).NotNull();
            RuleFor(b => b.Name).MinimumLength(2);
            RuleFor(b => b.Name).MaximumLength(50);
        }
    }
}