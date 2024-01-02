using ReportsService.Domain.Dtos;

namespace ReportsService.Application.Services.Abstraction
{
    public interface IReportService
    {
        Task<IList<ReportDto>> GetAll();
        Task<ReportWithDetailDto> GetById(int id);
        Task<ReportDto> Create(ReportDto report);
        Task Update(ReportDto report);
        Task AddDetailList(int reportId, IList<ReportDetailDto> detailList);
        Task Delete(int id);
    }
}
