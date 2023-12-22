using PersonService.Domain.Dtos;

namespace PersonService.Application.Features.PersonFeatures.Queries.GetPerson
{
    public sealed record GetPersonQueryResponse(PersonDetailDto person);
}