using Moq;
using PersonService.Application.Features.PersonFeatures.Queries.GetAllPerson;
using PersonService.Application.Services;
using PersonService.Domain.Dtos;
using PersonService.Domain.Entities;
using PersonService.UnitTest.Base;
using Shouldly;

namespace PersonService.UnitTest.Features.PersonFeatures.Queries;

public class GetAllPersonUnitTest : BaseFixture
{
    private readonly Mock<IPersonService> _personService;

    public GetAllPersonUnitTest()
    {
        _personService = new();
    }

    [Fact]
    public async Task Handle_ShouldReturnAllPersons()
    {

        var getAllPersonHandler = new GetAllPersonHandler(_personService.Object, _mapper.Object);

        var getAllPersonQuery = new GetAllPersonQuery();

        var personList = new List<Person>();
        _personService.Setup(x => x.GetAll()).ReturnsAsync(personList);

        var personDtoList = new List<PersonDto>();
        _mapper.Setup(x => x.Map<List<PersonDto>>(personList)).Returns(personDtoList);

        var result = await getAllPersonHandler.Handle(getAllPersonQuery, CancellationToken.None);

        result.ShouldNotBeNull();
        result.Equals(result.personList);

        _personService.Verify(x => x.GetAll(), Times.Once);

        _mapper.Verify(x => x.Map<List<PersonDto>>(personList), Times.Once);
    }
}
