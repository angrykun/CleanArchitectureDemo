using Domain;

namespace Application.Abstractions;

public interface IPersonRepository
{
    Task<ICollection<Domain.Person>> GetAll();
    Task<Domain.Person> GetPersonById(int personId);
    Task<Domain.Person> AddPerson(Domain.Person toCreate);
    Task<Domain.Person> UpdatePerson(int personId, string name, string email);
    Task DeletePerson(int personId);
}