using PersonService.Domain.Entities;

namespace PersonService.Application.Services;
public interface IPersonService
{
    Task<IList<Person>> GetAll();
    Task<Person> GetWithDetail(string id);
    Task CreatePerson(Person person);
    Task DeletePerson(string id);
}
