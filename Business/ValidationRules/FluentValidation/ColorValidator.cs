﻿using CarRental.Data.Contracts.Entities;
using FluentValidation;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.Name).MaximumLength(50);
            RuleFor(c => c.Name).Matches(@"^[a-zA-Z\s]+$");
        }
    }
}