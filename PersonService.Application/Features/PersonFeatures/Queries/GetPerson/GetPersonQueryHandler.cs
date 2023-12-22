using AutoMapper;
using MediatR;
using PersonService.Application.Features.PersonFeatures.Queries.GetAllPerson;
using PersonService.Application.Messaging;
using PersonService.Application.Services;
using PersonService.Domain.Dtos;

namespace PersonService.Application.Features.PersonFeatures.Queries.GetPerson
{
    public class GetPersonQueryHandler : IQueryHandler<GetPersonQuery, GetPersonQueryResponse>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public GetPersonQueryHandler(IPersonService personService, IMapper mapper = null)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<GetPersonQueryResponse> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var result = await _personService.GetWithDetail(request.id);

            var person = _mapper.Map<PersonDetailDto>(result);

            return new(person);
        }
    }
}
