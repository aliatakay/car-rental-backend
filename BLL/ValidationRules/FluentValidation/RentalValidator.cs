using Entities.Concrete;
using FluentValidation;

namespace BLL.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CarId).NotNull();
            RuleFor(r => r.CarId).GreaterThan(0);

            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.CustomerId).NotNull();
            RuleFor(r => r.CustomerId).GreaterThan(0);

            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.RentDate).NotNull();

            RuleFor(r => r.ReturnDate.Value).GreaterThan(r => r.RentDate).When(r => r.ReturnDate.HasValue);
        }
    }
}