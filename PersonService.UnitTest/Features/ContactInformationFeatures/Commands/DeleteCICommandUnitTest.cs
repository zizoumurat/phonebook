using AutoMapper;
using Moq;
using PersonService.Application.Features.ContactInformationFeatures.Commands.CreateContactInformation;
using PersonService.Application.Features.ContactInformationFeatures.Commands.DeleteContactInformation;
using PersonService.Application.Services;
using Shouldly;

namespace PersonService.UnitTest.Features.ContactInformationFeatures.Commands
{
    public class DeleteCICommandUnitTest
    {
        private readonly Mock<IContactInformaionService> _contactInformationService;

        public DeleteCICommandUnitTest()
        {
            _contactInformationService = new();
        }

        [Fact]
        public async Task DeleteCICommandResponseShouldNotBeNull()
        {
            var command = new DeleteCICommand("123", "123");
            var handler = new DeleteCICommandHandler(_contactInformationService.Object);

            var response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.message.ShouldNotBeNullOrEmpty();
        }
    }
}
