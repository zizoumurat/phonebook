using AutoMapper;
using Moq;
using ReportsService.Application.Services;
using ReportsService.Domain.Dtos;
using ReportsService.Domain.Entities;
using ReportsService.Domain.Repositories;

namespace ReportsService.UnitTest.Services
{
    public class ReportServiceUnitTest
    {
        private Mock<IReportRepository> _reportRepository;
        private Mock<IMapper> _mapperMock;
        private ReportService _reportService;

        public ReportServiceUnitTest()
        {
            _reportRepository = new Mock<IReportRepository>();
            _mapperMock = new Mock<IMapper>();
            _reportService = new ReportService(_reportRepository.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task AddDetailList_ShouldCallRepositoryWithMappedDetailList()
        {
            var reportId = 1;
            var detailList = new List<ReportDetailDto>();

            _mapperMock.Setup(m => m.Map<List<ReportDetail>>(detailList)).Returns(new List<ReportDetail>());

            await _reportService.AddDetailList(reportId, detailList);

            _reportRepository.Verify(r => r.AddDetailList(reportId, It.IsAny<List<ReportDetail>>()), Times.Once);
        }

        [Fact]
        public async Task Create_ShouldCallRepositoryWithMappedReport()
        {
            var reportDto = new ReportDto(); 
            var mappedReport = new Report(); 

            _mapperMock.Setup(m => m.Map<Report>(reportDto)).Returns(mappedReport);
            _reportRepository.Setup(r => r.Create(mappedReport)).ReturnsAsync(mappedReport);

            var result = await _reportService.Create(reportDto);
            
            _mapperMock.Verify(m => m.Map<ReportDto>(mappedReport), Times.Once);
            _reportRepository.Verify(r => r.Create(mappedReport), Times.Once);
            mappedReport.Equals(result);
        }
    }
}
