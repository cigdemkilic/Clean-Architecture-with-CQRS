using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Person.Commands
{
    public class CreatePerson : IRequest<Domain.Entities.Persons>
    {
        //example use
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
