using AutoMapper;
using PersonService.Application.Messaging;
using PersonService.Application.Services;
using PersonService.Domain.Entities;

namespace PersonService.Application.Features.PersonFeatures.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, CreatePersonCommandResponse>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<CreatePersonCommandResponse> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);
            
            await _personService.CreatePerson(person);

            return new(person.Id.ToString());
        }
    }
}
