using Application.Abstractions;
using Application.Person.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Person.QueryHandlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonById, Persons>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonByIdHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Persons> Handle(GetPersonById request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetPersonById(request.Id);
        }
    };
}
