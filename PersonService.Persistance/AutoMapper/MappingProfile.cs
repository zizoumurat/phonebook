using AutoMapper;
using PersonService.Domain.Dtos;
using PersonService.Domain.Entities;


namespace PersonService.Persistance.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PersonDto, Person>().ReverseMap();
        CreateMap<Person, PersonDetailDto>().ReverseMap();
        CreateMap<ContactInformationDto,ContactInformation>().ReverseMap();
    }
}
