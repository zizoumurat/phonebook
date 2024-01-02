using FluentValidation;
using PersonService.Domain.Validation;

namespace PersonService.Application.Features.ContactInformationFeatures.Commands.CreateContactInformation;

public sealed class CreateCICommandValidator : AbstractValidator<CreateCICommand>
{
    public CreateCICommandValidator()
    {
        RuleFor(r => r.email).NotNull().WithMessage(ValidationMessages.EmailRequired);
        RuleFor(r => r.email).EmailAddress().WithMessage(ValidationMessages.InvalidEmail);
        RuleFor(r => r.phoneNumber).NotEmpty().WithMessage(ValidationMessages.PhoneNumberRequired);
        RuleFor(r => r.location).NotEmpty().WithMessage(ValidationMessages.LocationRequired);
    }
}
