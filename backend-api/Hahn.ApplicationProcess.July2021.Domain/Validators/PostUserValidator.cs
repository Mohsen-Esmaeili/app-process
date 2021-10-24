using FluentValidation;
using Hahn.ApplicationProcess.July2021.Domain.Models;

namespace Hahn.ApplicationProcess.July2021.Domain.Validators
{
    public class PostUserValidator : AbstractValidator<PostUserRequest>
    {
        public PostUserValidator()
        {
            RuleFor(x => x.FirstName).Length(3, 50);
            RuleFor(x => x.LastName).Length(3, 50);
            //RuleFor(x => x.Age).GreaterThanOrEqualTo(18);
            RuleFor(x => x.HouseNumber).NotNull().NotEmpty();
            RuleFor(x => x.Street).NotNull().NotEmpty();
            RuleFor(x => x.PostalCode).NotNull().NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
