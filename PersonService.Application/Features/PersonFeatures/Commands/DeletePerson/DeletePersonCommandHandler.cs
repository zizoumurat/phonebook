using AutoMapper;
using PersonService.Application.Features.PersonFeatures.Commands.CreatePerson;
using PersonService.Application.Messaging;
using PersonService.Application.Services;
using PersonService.Domain.Entities;

namespace PersonService.Application.Features.PersonFeatures.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : ICommandHandler<DeletePersonCommand, DeletePersonCommandResponse>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public DeletePersonCommandHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<DeletePersonCommandResponse> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await _personService.DeletePerson(request.Id);
            return new();
        }
    }

}
