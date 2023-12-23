using ReportsService.Domain.Dtos;

namespace ReportsService.Application.Services
{
    public interface IReportService
    {
        Task<IList<ReportDto>> GetAll();
        Task<ReportDto?> GetById(int id);
        Task Create(ReportDto report);
        Task Update(ReportDto report);
        Task AddDetailList(ReportDto report, IList<ReportDetailDto> detailList);
    }
}
