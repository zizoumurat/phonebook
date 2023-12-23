using ReportsService.Domain.Entities;

namespace ReportsService.Domain.Repositories
{
    public interface IReportRepository
    {
        Task<IList<Report>> GetAll();
        Task<Report?> GetById(int Id);
        Task Create(Report report);
        Task Update(Report report);
    }
}
