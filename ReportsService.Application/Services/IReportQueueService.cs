using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsService.Application.Services
{
    public interface IReportQueueService
    {
        Task SendCreateReportRequest();
        Task SendProcessReportRequest(int id);
    }
}
