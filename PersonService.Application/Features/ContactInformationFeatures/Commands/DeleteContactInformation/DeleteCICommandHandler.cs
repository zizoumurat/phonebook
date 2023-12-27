using AutoMapper;
using PersonService.Application.Messaging;
using PersonService.Application.Services;

namespace PersonService.Application.Features.ContactInformationFeatures.Commands.DeleteContactInformation
{
    public class DeleteCICommandHandler : ICommandHandler<DeleteCICommand, DeleteCICommandResponse>
    {
        private readonly IContactInformaionService _service;

        public DeleteCICommandHandler(IContactInformaionService service)
        {
            _service = service;
        }

        public async Task<DeleteCICommandResponse> Handle(DeleteCICommand request, CancellationToken cancellationToken)
        {
            await _service.Delete(request.personId,request.id);
            return new();
        }
    }

}
