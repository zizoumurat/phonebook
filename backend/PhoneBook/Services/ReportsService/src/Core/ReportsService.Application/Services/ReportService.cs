using AutoMapper;
using ReportsService.Application.Services.Abstraction;
using ReportsService.Domain.Dtos;
using ReportsService.Domain.Entities;
using ReportsService.Domain.Repositories;

namespace ReportsService.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public ReportService(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task AddDetailList(int reportId, IList<ReportDetailDto> detailList)
        {
            await _reportRepository.AddDetailList(reportId, _mapper.Map<List<ReportDetail>>(detailList));
        }

        public async Task<ReportDto> Create(ReportDto report)
        {
            var entity = _mapper.Map<Report>(report);

            var addedReport = await _reportRepository.Create(entity);

            return _mapper.Map<ReportDto>(addedReport);
        }

        public async Task<IList<ReportDto>> GetAll()
        {
            var list = await _reportRepository.GetAll();

            return _mapper.Map<List<ReportDto>>(list);
        }

        public async Task<ReportWithDetailDto?> GetById(int id)
        {
            var report = await _reportRepository.GetById(id);

            return _mapper.Map<ReportWithDetailDto>(report);
        }

        public async Task Update(ReportDto report)
        {
            var entity = _mapper.Map<Report>(report);

            await _reportRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _reportRepository.Delete(id);
        }
    }
}
