using PersonService.Application.Messaging;

namespace PersonService.Application.Features.PersonFeatures.Queries.GetPerson
{
    public sealed record GetPersonQuery(string id) : IQuery<GetPersonQueryResponse>;
}
