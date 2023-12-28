using AutoMapper;
using PersonService.Application.Messaging;
using PersonService.Application.Services;
using PersonService.Domain.Entities;

namespace PersonService.Application.Features.ContactInformationFeatures.Commands.CreateContactInformation
{
    public class CreateCICommandHandler : ICommandHandler<CreateCICommand, CreateCICommandResponse>
    {
        private readonly IContactInformaionService _contactInformationService;
        private readonly IMapper _mapper;

        public CreateCICommandHandler(IContactInformaionService contactInformationService, IMapper mapper)
        {
            _contactInformationService = contactInformationService;
            _mapper = mapper;
        }

        public async Task<CreateCICommandResponse> Handle(CreateCICommand request, CancellationToken cancellationToken)
        {
            var contactInformation = _mapper.Map<ContactInformation>(request);

            await _contactInformationService.Create(request.personId, contactInformation);

            return new();   
        }
    }
}
