using PersonService.Application.Messaging;
using PersonService.Domain.Dtos;

namespace PersonService.Application.Features.ContactInformationFeatures.Commands.CreateContactInformation;

public class CreateCICommand : ICommand<CreateCICommandResponse>
{
    public string PersonId { get; set; }
    public ContactInformationDto ContactInformation { get; set; }
}
