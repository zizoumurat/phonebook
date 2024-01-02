using ReportsService.Domain.Entities;

namespace ReportsService.Domain.Repositories
{
    public interface IReportRepository
    {
        Task<IList<Report>> GetAll();
        Task<Report> GetById(int id);
        Task<Report> Create(Report report);
        Task Update(Report report);
        Task AddDetailList(int reportId, IList<ReportDetail> detailList);
        Task Delete(int id);
    }
}
