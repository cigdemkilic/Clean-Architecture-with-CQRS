using Application.Abstractions;
using Application.Person.Commands;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Person.CommandHandlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePerson, Persons>
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Persons> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            var person = new Persons
            {
                Name = request.Name,
                Email = request.Email
            };

            return await _personRepository.AddPerson(person);
        }
    }
}
