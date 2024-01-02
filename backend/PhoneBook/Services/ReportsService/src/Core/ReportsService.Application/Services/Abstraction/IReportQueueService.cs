namespace ReportsService.Application.Services.Abstraction;

public interface IReportQueueService
{
    Task SendCreateReportRequest();
    Task SendProcessReportRequest(int id);
}
