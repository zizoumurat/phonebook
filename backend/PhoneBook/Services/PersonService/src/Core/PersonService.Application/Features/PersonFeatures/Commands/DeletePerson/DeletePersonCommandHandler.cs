using PersonService.Application.Messaging;
using PersonService.Application.Services;

namespace PersonService.Application.Features.PersonFeatures.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : ICommandHandler<DeletePersonCommand, DeletePersonCommandResponse>
    {
        private readonly IPersonService _personService;

        public DeletePersonCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<DeletePersonCommandResponse> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await _personService.DeletePerson(request.Id);
            return new();
        }
    }

}
