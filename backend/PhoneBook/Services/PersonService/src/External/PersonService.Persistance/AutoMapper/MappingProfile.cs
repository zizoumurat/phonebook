using AutoMapper;
using PersonService.Domain.Dtos;
using PersonService.Domain.Entities;
using PersonService.Application.Features.PersonFeatures.Commands.CreatePerson;
using PersonService.Application.Features.ContactInformationFeatures.Commands.CreateContactInformation;


namespace PersonService.Persistance.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PersonDto, Person>().ReverseMap();
        CreateMap<Person, PersonDetailDto>().ReverseMap();

        CreateMap<CreatePersonCommand, Person>();
        CreateMap<CreateCICommand, ContactInformation>();
        CreateMap<ContactInformationDto,ContactInformation>().ReverseMap();
    }
}
