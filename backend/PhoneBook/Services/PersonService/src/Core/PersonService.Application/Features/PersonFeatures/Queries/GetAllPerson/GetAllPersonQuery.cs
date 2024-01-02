using PersonService.Application.Messaging;

namespace PersonService.Application.Features.PersonFeatures.Queries.GetAllPerson
{
    public sealed record GetAllPersonQuery() : IQuery<GetAllPersonResponse>;
}
