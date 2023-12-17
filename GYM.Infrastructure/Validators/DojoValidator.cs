using FluentValidation;
using GYM.Core.DTOs;

namespace GYM.Infrastructure.Validators
{
    public class DojoValidator : AbstractValidator<DojoDto>
    {
        public DojoValidator()
        {
            RuleFor(dojo => dojo.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("The name cannot be empty");
        }
    }
}
