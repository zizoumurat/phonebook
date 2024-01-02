using PersonService.Application.Messaging;

namespace PersonService.Application.Features.ContactInformationFeatures.Commands.DeleteContactInformation
{
    public sealed record DeleteCICommand(string personId, string id) : ICommand<DeleteCICommandResponse>;
}
