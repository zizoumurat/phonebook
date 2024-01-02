using Moq;
using ReportsService.Domain.Repositories;

namespace ReportsService.UnitTest.Services
{
    public class ReportServiceUnitTest
    {
        private readonly Mock<IReportRepository> _personService;

        public ReportServiceUnitTest()
        {
            _personService = new();
        }

    }
}
