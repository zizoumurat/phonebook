using AutoMapper;
using ReportsService.Domain.Dtos;
using ReportsService.Domain.Entities;

namespace ReportsService.Persistance.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Report, ReportDto>().ReverseMap();
        CreateMap<ReportDetail, ReportDetailDto>().ReverseMap();
    }
}
