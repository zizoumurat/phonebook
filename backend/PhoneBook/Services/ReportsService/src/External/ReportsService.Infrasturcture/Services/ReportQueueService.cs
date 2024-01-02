using MassTransit;
using ReportsService.Domain.Dtos;
using ReportsService.Domain.Entities;
using ReportsService.Application.Services.Abstraction;

namespace ReportsService.Infrasturcture.Services
{
    public class ReportQueueService : IReportQueueService
    {
        private readonly IBusControl _busControl;

        public ReportQueueService(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public async Task SendCreateReportRequest()
        {
            var endpoint = await _busControl.GetSendEndpoint(new Uri("queue:create_report_queue"));
            await endpoint.Send(new CreateReportRequest { RequestDate = DateTime.Now });
        }

        public async Task SendProcessReportRequest(int id)
        {
            var endpoint = await _busControl.GetSendEndpoint(new Uri("queue:process_report_queue"));
            await endpoint.Send(new ProcessReportRequest { ReportId = id });
        }
    }
}
