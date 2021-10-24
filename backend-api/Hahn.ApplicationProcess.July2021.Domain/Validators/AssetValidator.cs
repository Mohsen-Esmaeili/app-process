using FluentValidation;
using Hahn.ApplicationProcess.July2021.Domain.Models;

namespace Hahn.ApplicationProcess.July2021.Domain.Validators
{
    public class AssetValidator: AbstractValidator<AssetBase>
    {
        public AssetValidator()
        {
            RuleFor(a => a.Name).NotNull().NotEmpty().WithMessage("Asset name is required");
            RuleFor(a => a.Symbol).NotNull().NotEmpty().WithMessage("Asset symbol is required");
        }
    }
}
