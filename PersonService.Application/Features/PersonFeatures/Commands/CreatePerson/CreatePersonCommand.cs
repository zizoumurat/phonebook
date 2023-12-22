using PersonService.Application.Messaging;
using PersonService.Domain.Dtos;

namespace PersonService.Application.Features.PersonFeatures.Commands.CreatePerson
{
    public class CreatePersonCommand : ICommand<CreatePersonCommandResponse>
    {
        public PersonDto Person { get; set; }
    }
}
