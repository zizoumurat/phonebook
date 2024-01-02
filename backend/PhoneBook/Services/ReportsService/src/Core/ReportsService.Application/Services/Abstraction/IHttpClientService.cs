using ReportsService.Domain.Dtos;

namespace ReportsService.Application.Services.Abstraction
{
    public interface IHttpClientService
    {
        Task<IList<LocationReportDto>> GetLocationsReport();
    }
}
