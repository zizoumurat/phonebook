using ReportsService.Api.Configurations.Abstraction;
using ReportsService.Application.Services;
using ReportsService.Domain.Repositories;
using ReportsService.Persistance;
using ReportsService.Persistance.Context;
using ReportsService.Persistance.Repositories;
using ReportsService.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace ReportsService.Api.Configurations;

public class PersistanceServiceInstaller : IServiceInstaller
{
    private const string SectionName = "PostgreConnection";
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(SectionName);

        services.AddDbContext<ReportsDbContext>(options =>
             options.UseNpgsql(connectionString));

        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<IReportService, ReportService>();
        services.AddAutoMapper(typeof(AssemblyReference).Assembly);
    }
}
