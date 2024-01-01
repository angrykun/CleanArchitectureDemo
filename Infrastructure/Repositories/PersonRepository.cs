using Application.Abstractions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PersonRepository(PersonDbContext context) : IPersonRepository
{
    public async Task<ICollection<Person>> GetAll()
    {
        return await context.Persons.ToListAsync();
    }

    public async Task<Person> GetPersonById(int personId)
    {
        return await context.Persons.FirstOrDefaultAsync(c => c.Id == personId);
    }

    public async Task<Person> AddPerson(Person toCreate)
    {
        context.Persons.Add(toCreate);
        await context.SaveChangesAsync();
        return toCreate;
    }

    public async Task<Person> UpdatePerson(int personId, string name, string email)
    {
        var person = await context.Persons.FirstOrDefaultAsync(c => c.Id == personId);
        person.Name = name;
        person.Email = email;
        
        await context.SaveChangesAsync();
        return person;
    }

    public async Task DeletePerson(int personId)
    {
        var person = context.Persons
            .FirstOrDefault(p => p.Id == personId);

        if (person is null) return;

        context.Persons.Remove(person);

        await context.SaveChangesAsync();
    }
}