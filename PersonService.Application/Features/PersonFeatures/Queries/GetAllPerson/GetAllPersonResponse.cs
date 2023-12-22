using PersonService.Domain.Dtos;
using PersonService.Domain.Entities;

namespace PersonService.Application.Features.PersonFeatures.Queries.GetAllPerson
{
    public sealed record GetAllPersonResponse(IList<PersonDto> personList);
}