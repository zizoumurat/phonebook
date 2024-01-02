using ReportsService.Domain.Dtos;

namespace ReportsService.Application.Services
{
    public interface IHttpClientService
    {
        Task<IList<LocationReportDto>> GetLocationsReport();
    }
}
