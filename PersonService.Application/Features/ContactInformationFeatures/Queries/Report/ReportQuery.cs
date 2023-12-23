using PersonService.Application.Messaging;

namespace PersonService.Application.Features.ContactInformationFeatures.Queries.Report
{
    public sealed record ReportQuery() : IQuery<ReportQueryResponse>;
}
