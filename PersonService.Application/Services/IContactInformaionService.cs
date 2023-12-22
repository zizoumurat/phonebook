using PersonService.Domain.Entities;

namespace PersonService.Application.Services;

public interface IContactInformaionService
{
    Task Create(string personId, ContactInformation contactInformation);
    Task Delete(string personId, string id);
}
