using MassTransit;
using ReportsService.Domain.Dtos;
using Microsoft.AspNetCore.SignalR;
using ReportsService.Infrasturcture.Hubs;
using ReportsService.Application.Services.Abstraction;

namespace ReportsService.Infrasturcture.Consumers
{
    public class ProcessReportConsumer : IConsumer<ProcessReportRequest>
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IReportService _reportService;
        private readonly IHubContext<NotificationHub> _hubContext;

        public ProcessReportConsumer(IHttpClientService httpClientService, IReportService reportService, IHubContext<NotificationHub> hubContext)
        {
            _httpClientService = httpClientService;
            _reportService = reportService;
             _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<ProcessReportRequest> context)
        {
            var list = await _httpClientService.GetLocationsReport();

            var reportDetailList = list.Select(x => new ReportDetailDto()
            {
                Location = x.Location,
                PersonCount = x.PersonCount,
                PhoneNumberCount = x.PhoneNumberCount,
                ReportId = context.Message.ReportId
            }).ToList();

            await _reportService.AddDetailList(context.Message.ReportId, reportDetailList);

            Thread.Sleep(2000);
            _hubContext.Clients.All.SendAsync("ReceiveNotification", "Rapor Tamamlandı");
        }
    }
}
