using AutoMapper;
using ReportsService.Application.Services;
using ReportsService.Domain.Dtos;
using ReportsService.Domain.Entities;
using ReportsService.Domain.Repositories;

namespace ReportsService.Persistance.Services
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

        public async Task AddDetailList(ReportDto report, IList<ReportDetailDto> detailList)
        {
            var entity = _mapper.Map<Report>(report);

            entity.Details.AddRange(_mapper.Map<List<ReportDetail>>(detailList));

            await _reportRepository.Update(entity);
        }

        public async Task Create(ReportDto report)
        {
            var entity = _mapper.Map<Report>(report);

            await _reportRepository.Create(entity);
        }

        public async Task<IList<ReportDto>> GetAll()
        {
            var list = await _reportRepository.GetAll();

            return _mapper.Map<List<ReportDto>>(list);
        }

        public async Task<ReportDto?> GetById(int id)
        {
            var report = await _reportRepository.GetById(id);

            return _mapper.Map<ReportDto>(report);
        }

        public async Task Update(ReportDto report)
        {
            var entity = _mapper.Map<Report>(report);

            await _reportRepository.Create(entity);
        }
    }
}
