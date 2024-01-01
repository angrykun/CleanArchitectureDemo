using Application.Abstractions;
using Application.Person.Queries;
using MediatR;

namespace Application.Person.QueryHandlers;

public class GetPersonByIdHandler(IPersonRepository personRepository) : IRequestHandler<GetPersonById, Domain.Person>
{
    public async Task<Domain.Person> Handle(GetPersonById request, CancellationToken cancellationToken)
    {
        return await personRepository.GetPersonById(request.Id);
    }
}