using Microsoft.EntityFrameworkCore;
using ReportsService.Domain.Entities;
using ReportsService.Domain.Repositories;
using ReportsService.Persistance.Context;

namespace ReportsService.Persistance.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportsDbContext _context;

        public ReportRepository(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task Create(Report report)
        {
            await _context.Reports.AddAsync(report);

            _context.SaveChanges();
        }

        public async Task<IList<Report>> GetAll()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<Report?> GetById(int Id)
        {
            return await _context.Reports.Include(x => x.Details).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Update(Report report)
        {
            _context.Entry(report).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
