using PersonService.Domain.Dtos;

namespace PersonService.Application.Features.ContactInformationFeatures.Queries.Report
{
    public sealed record ReportQueryResponse(IList<LocationReportDto> reportList);

}
