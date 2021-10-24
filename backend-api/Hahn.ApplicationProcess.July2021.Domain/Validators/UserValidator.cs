using FluentValidation;
using Hahn.ApplicationProcess.July2021.Domain.Models;

namespace Hahn.ApplicationProcess.July2021.Domain.Validators
{
    public class UserValidator : AbstractValidator<UserBase>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).Length(3).WithMessage("FirstName must has at least 3 characters.");
            RuleFor(x => x.LastName).Length(3).WithMessage("LastName must has at least 3 characters.");
            RuleFor(x => x.Age).GreaterThan(18).WithMessage("Age must be greater than 18");
            RuleFor(x => x.HouseNumber).NotNull().NotEmpty().WithMessage("House number is required");
            RuleFor(x => x.Street).NotNull().NotEmpty().WithMessage("Street is required");
            RuleFor(x => x.PostalCode).NotNull().NotEmpty().WithMessage("Postal code is required");
            RuleFor(x => x.Email).Must(BeAValidEmail).EmailAddress().WithMessage("Please specify a valid email");
        }

        private bool BeAValidEmail(string email)
        {
            return email.Contains('@');
        }
    }
}
