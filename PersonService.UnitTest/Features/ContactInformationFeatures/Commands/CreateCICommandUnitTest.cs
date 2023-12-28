using AutoMapper;
using Moq;
using PersonService.Application.Features.ContactInformationFeatures.Commands.CreateContactInformation;
using PersonService.Application.Services;
using PersonService.Persistance.AutoMapper;
using Shouldly;

namespace PersonService.UnitTest.Features.ContactInformationFeatures.Commands;

public class CreateCICommandUnitTest
{
    private readonly Mock<IContactInformaionService> _contactInformationService;
    private readonly IMapper _mapper;

    public CreateCICommandUnitTest()
    {
        _contactInformationService = new();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        _mapper = new Mapper(configuration);
    }

    [Fact]
    public async Task CreateCICommandResponseShouldNotBeNull()
    {
        var command = new CreateCICommand("", "09999999999", "test@test.com", "Konya");
        var handler = new CreateCICommandHandler(_contactInformationService.Object, _mapper);

        var response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.message.ShouldNotBeNullOrEmpty();
    }

}
