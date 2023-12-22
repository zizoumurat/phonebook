using FluentValidation;
using PersonService.Domain.Validation;

namespace PersonService.Application.Features.PersonFeatures.Commands.CreatePerson
{
    public sealed class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(r => r.Person.FirstName).NotNull().WithMessage(ValidationMessages.FirstNameRequired);
            RuleFor(r => r.Person.LastName).NotEmpty().WithMessage(ValidationMessages.LastNameRequired);
            RuleFor(r => r.Person.Company).NotEmpty().WithMessage(ValidationMessages.CompanyNameRequired);
        }
    }
}
