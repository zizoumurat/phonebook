using ReportsService.Application.Services.Abstraction;
using ReportsService.Domain.Dtos;
using System.Net.Http.Json;

namespace ReportsService.Infrasturcture.Services;

public class HttpClientService : IHttpClientService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IList<LocationReportDto>> GetLocationsReport()
    {
        var httpClient = _httpClientFactory.CreateClient("UserServiceClient");

        var response = await httpClient.GetAsync($"api/contactinformation/report");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<IList<LocationReportDto>>();
        }

        throw new HttpRequestException($"Error: {response.StatusCode}");
    }
}
