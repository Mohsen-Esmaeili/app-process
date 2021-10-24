using FluentValidation;
using Hahn.ApplicationProcess.July2021.Domain.Models;

namespace Hahn.ApplicationProcess.July2021.Domain.Validators
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator()
        {
            RuleFor(u => u.Id).NotNull().NotEmpty();
        }
    }
}
