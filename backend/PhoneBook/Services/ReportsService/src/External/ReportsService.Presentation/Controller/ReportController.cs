using Microsoft.AspNetCore.Mvc;
using ReportsService.Application.Services.Abstraction;
using ReportsService.Presentation.Abstraction;

namespace ReportsService.Presentation.Controller
{
    public class ReportController : ApiController
    {
        private readonly IReportService _reportService;
        private readonly IReportQueueService _reportQueueService;

        public ReportController(IReportService reportService, IReportQueueService reportQueueService)
        {
            _reportService = reportService;
            _reportQueueService = reportQueueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _reportService.GetAll();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _reportService.GetById(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest()
        {
            await _reportQueueService.SendCreateReportRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reportService.Delete(id);

            return Ok();
        }
    }
}
