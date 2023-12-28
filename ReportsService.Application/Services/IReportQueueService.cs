namespace ReportsService.Application.Services;

public interface IReportQueueService
{
    Task SendCreateReportRequest();
    Task SendProcessReportRequest(int id);
}
