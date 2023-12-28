using Moq;
using PersonService.Application.Features.PersonFeatures.Commands.DeletePerson;
using PersonService.Application.Services;
using Shouldly;

namespace PersonService.UnitTest.Features.PersonFeatures.Commands
{
    public class DeletePersonCommandUnitTest
    {
        private readonly Mock<IPersonService> _personService;

        public DeletePersonCommandUnitTest()
        {
            _personService = new();
        }

        [Fact]
        public async Task Handle_ShouldDeletePersonAndReturnResponse()
        {
            var deletePersonCommandHandler = new DeletePersonCommandHandler(_personService.Object);

            var deletePersonCommand = new DeletePersonCommand("d85979ba-41d5-4919-9680-dfff3e51ac6b");
            
            var result = await deletePersonCommandHandler.Handle(deletePersonCommand, CancellationToken.None);

            result.ShouldNotBeNull();

            _personService.Verify(x => x.DeletePerson(deletePersonCommand.Id), Times.Once);
        }
    }
}
