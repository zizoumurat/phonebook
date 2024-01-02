using ReportsService.Api.Configurations.Abstraction;
using ReportsService.Application.Services;
using ReportsService.Domain.Repositories;
using ReportsService.Persistance;
using ReportsService.Persistance.Context;
using ReportsService.Persistance.Repositories;
using ReportsService.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Text.RegularExpressions;

namespace ReportsService.Api.Configurations;

public class PersistanceServiceInstaller : IServiceInstaller
{
    private const string SectionName = "PostgreConnection";
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(SectionName);

        services.AddDbContext<ReportsDbContext>(options =>
             options.UseNpgsql(connectionString));

        var dbContext = services.BuildServiceProvider().GetService<ReportsDbContext>();

        dbContext.Database.Migrate();


        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<IReportService, ReportService>();
        services.AddAutoMapper(typeof(AssemblyReference).Assembly);
    }
}
