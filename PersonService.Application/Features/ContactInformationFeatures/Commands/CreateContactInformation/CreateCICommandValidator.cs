using FluentValidation;
using PersonService.Domain.Validation;

namespace PersonService.Application.Features.ContactInformationFeatures.Commands.CreateContactInformation;

public sealed class CreateCICommandValidator : AbstractValidator<CreateCICommand>
{
    public CreateCICommandValidator()
    {
        RuleFor(r => r.ContactInformation.Email).NotNull().WithMessage(ValidationMessages.EmailRequired);
        RuleFor(r => r.ContactInformation.Email).EmailAddress().WithMessage(ValidationMessages.InvalidEmail);
        RuleFor(r => r.ContactInformation.PhoneNumber).NotEmpty().WithMessage(ValidationMessages.PhoneNumberRequired);
        RuleFor(r => r.ContactInformation.Location).NotEmpty().WithMessage(ValidationMessages.LocationRequired);
    }
}
