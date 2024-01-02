using PersonService.Application.Messaging;

namespace PersonService.Application.Features.PersonFeatures.Commands.DeletePerson
{
    public sealed record DeletePersonCommand(string Id) : ICommand<DeletePersonCommandResponse>;
}
