using MassTransit;
using ReportsService.Application.Services;
using ReportsService.Domain.Dtos;
using Microsoft.AspNetCore.SignalR;
using ReportsService.Infrasturcture.Hubs;

namespace ReportsService.Infrasturcture.Consumers
{
    public class CreateReportConsumer : IConsumer<CreateReportRequest>
    {
        private readonly IReportService _reportService;
        private readonly IReportQueueService _reportQueueService;

        private readonly IHubContext<NotificationHub> _hubContext;

        public CreateReportConsumer(IReportService reportService,
         IReportQueueService reportQueueService, IHubContext<NotificationHub> hubContext)
        {
            _reportService = reportService;
            _reportQueueService = reportQueueService;
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<CreateReportRequest> context)
        {
            var report = await _reportService.Create(new()
            {
                RequestDate = DateTime.Now,
                IsComplated = false
            });


            Thread.Sleep(2000);
            _hubContext.Clients.All.SendAsync("ReceiveNotification", "Rapor Oluşturuldu.Veriler Hazırlanıyor");

            await _reportQueueService.SendProcessReportRequest(report.Id);
        }
    }
}
