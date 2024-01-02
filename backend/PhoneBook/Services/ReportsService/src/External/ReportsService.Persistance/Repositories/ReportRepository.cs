using Microsoft.EntityFrameworkCore;
using ReportsService.Domain.Entities;
using ReportsService.Domain.Repositories;
using ReportsService.Persistance.Context;

namespace ReportsService.Persistance.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly ReportsDbContext _context;

    public ReportRepository(ReportsDbContext context)
    {
        _context = context;
    }

    public async Task<Report> Create(Report report)
    {
        await _context.Reports.AddAsync(report);

        _context.SaveChanges();

        return report;
    }

    public async Task<IList<Report>> GetAll()
    {
        return await _context.Reports.ToListAsync();
    }

    public async Task<Report?> GetById(int id)
    {
        return await _context.Reports.Include(x => x.Details).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(Report report)
    {
        _context.Entry(report).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task AddDetailList(int reportId, IList<ReportDetail> detailList)
    {
        var report = await GetById(reportId);

        report.Details.AddRange(detailList);

        report.IsComplated = true;
        report.CreatedDate = DateTime.Now;

        await Update(report);
    }

    public async Task Delete(int id)
    {
        var report = new Report { Id = id };
        _context.Entry(report).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
}
