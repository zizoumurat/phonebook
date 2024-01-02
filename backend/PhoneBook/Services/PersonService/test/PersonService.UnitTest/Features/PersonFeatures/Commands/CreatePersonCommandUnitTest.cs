using Moq;
using PersonService.Application.Features.PersonFeatures.Commands.CreatePerson;
using PersonService.Application.Services;
using PersonService.Domain.Entities;
using PersonService.UnitTest.Base;
using Shouldly;

namespace PersonService.UnitTest.Features.PersonFeatures.Commands
{
    public class CreatePersonCommandUnitTest: BaseFixture
    {
        private readonly Mock<IPersonService> _personService;

        public CreatePersonCommandUnitTest()
        {
            _personService = new();
        }

        [Fact]
        public async Task Handle_ShouldCreatePersonAndReturnResponse()
        {
            var createPersonCommandHandler = new CreatePersonCommandHandler(_personService.Object, _mapper.Object);

            var createPersonCommand = new CreatePersonCommand
            (
                firstName:"John",
                lastName:  "Valid",
                company: "Abibas"
            );

            var expectedPersonId = "d85979ba-41d5-4919-9680-dfff3e51ac6b";
            var person = new Person { Id = expectedPersonId };
            _mapper.Setup(x => x.Map<Person>(createPersonCommand)).Returns(person);
            
            var result = await createPersonCommandHandler.Handle(createPersonCommand, CancellationToken.None);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(expectedPersonId.ToString());

            _personService.Verify(x => x.CreatePerson(person), Times.Once);
        }
    }
}
