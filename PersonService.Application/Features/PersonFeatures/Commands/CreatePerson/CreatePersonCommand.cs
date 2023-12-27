using PersonService.Application.Messaging;
using PersonService.Domain.Dtos;

namespace PersonService.Application.Features.PersonFeatures.Commands.CreatePerson
{
    public sealed record CreatePersonCommand(string firstName, string lastName, string company) : ICommand<CreatePersonCommandResponse>;
}
