using Application.Abstractions;
using Application.Person.Commands;
using MediatR;

namespace Application.Person.CommandHandlers;

public class CreatePersonHandler(IPersonRepository personRepository) : IRequestHandler<CreatePerson, Domain.Person>
{
    public async Task<Domain.Person> Handle(CreatePerson request, CancellationToken cancellationToken)
    {
        var person = new Domain.Person()
        {
            Name = request.Name,
            Email = request.Email
        };
        return await personRepository.AddPerson(person);
    }
}