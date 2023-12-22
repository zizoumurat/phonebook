using AutoMapper;
using PersonService.Application.Messaging;
using PersonService.Application.Services;
using PersonService.Domain.Dtos;

namespace PersonService.Application.Features.PersonFeatures.Queries.GetAllPerson
{
    public class GetAllPersonHandler : IQueryHandler<GetAllPersonQuery, GetAllPersonResponse>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public GetAllPersonHandler(IPersonService personService, IMapper mapper = null)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<GetAllPersonResponse> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var list = await _personService.GetAll();

            var personList = _mapper.Map<List<PersonDto>>(list);

            return new(personList);
        }
    }
}
