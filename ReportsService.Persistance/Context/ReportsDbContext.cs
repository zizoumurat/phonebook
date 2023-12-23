using Microsoft.EntityFrameworkCore;
using ReportsService.Domain.Entities;

namespace ReportsService.Persistance.Context
{
    public class ReportsDbContext : DbContext
    {
        public ReportsDbContext(DbContextOptions<ReportsDbContext> options) : base(options)
        {
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportDetail> ReportDetails { get; set; }
    }
}
