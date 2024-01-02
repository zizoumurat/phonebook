using PersonService.Application.Messaging;
using PersonService.Domain.Dtos;

namespace PersonService.Application.Features.ContactInformationFeatures.Commands.CreateContactInformation;

public sealed record CreateCICommand(string personId, string phoneNumber, string email, string location) : ICommand<CreateCICommandResponse>;
