using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Person.Queries
{
    public class GetPersonById : IRequest<Persons>
    {
        public int Id { get; set; }
    };
}
