using MediatR;

namespace Application.Person.Queries;

public class GetPersonById : IRequest<Domain.Person>
{
    public int Id { get; set; }
}