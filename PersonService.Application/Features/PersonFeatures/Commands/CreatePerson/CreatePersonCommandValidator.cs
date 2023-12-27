using FluentValidation;
using PersonService.Domain.Validation;

namespace PersonService.Application.Features.PersonFeatures.Commands.CreatePerson
{
    public sealed class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(r => r.firstName).NotNull().WithMessage(ValidationMessages.FirstNameRequired);
            RuleFor(r => r.lastName).NotEmpty().WithMessage(ValidationMessages.LastNameRequired);
            RuleFor(r => r.company).NotEmpty().WithMessage(ValidationMessages.CompanyNameRequired);
        }
    }
}
