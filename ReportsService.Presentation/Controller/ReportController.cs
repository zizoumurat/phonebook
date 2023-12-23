using Microsoft.AspNetCore.Mvc;
using ReportsService.Application.Services;
using ReportsService.Domain.Dtos;
using ReportsService.Presentation.Abstraction;

namespace ReportsService.Presentation.Controller
{
    public class ReportController : ApiController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
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
        public async Task<IActionResult> Create()
        {
            var report = new ReportDto()
            {
                RequestDate = DateTime.Now,
                IsComplated = false
            };

            await _reportService.Create(report);

            return Ok();
        }
    }
}
