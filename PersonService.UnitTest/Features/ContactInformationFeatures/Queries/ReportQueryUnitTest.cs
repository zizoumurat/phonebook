using Moq;
using PersonService.Application.Features.ContactInformationFeatures.Queries.Report;
using PersonService.Application.Services;
using PersonService.Domain.Dtos;
using Shouldly;

namespace PersonService.UnitTest.Features.ContactInformationFeatures.Queries;

public class ReportQueryUnitTest
{
    private readonly Mock<IContactInformaionService> _contactInformationService;

    public ReportQueryUnitTest()
    {
        _contactInformationService = new();
    }

    [Fact]
    public async Task ReportQueryResponseShouldBeEqual()
    {
        var reportQueryHandler = new ReportQueryHandler(_contactInformationService.Object);
        var reportQuery = new ReportQuery();

        var expectedReportList = new List<LocationReportDto>(); 
        _contactInformationService.Setup(x => x.GetReportList()).ReturnsAsync(expectedReportList);

        var result = await reportQueryHandler.Handle(reportQuery, CancellationToken.None);

        result.ShouldNotBeNull();
        result.Equals(expectedReportList);
    }
}
