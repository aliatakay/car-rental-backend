using CarRental.Data.Contracts.Entities;
using FluentValidation;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.FirstName).MaximumLength(200);
            RuleFor(u => u.FirstName).Matches(@"^[a-zA-Z\s]+$");

            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.LastName).MaximumLength(100);
            RuleFor(u => u.LastName).Matches(@"^[a-zA-Z\s]+$");

            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Email).MaximumLength(100);

            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).NotNull();
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Password).MaximumLength(80);
        }
    }
}