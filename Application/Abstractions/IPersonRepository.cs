using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Application.Abstractions
{
    public interface IPersonRepository
    {
        Task<ICollection<Persons>> GetAll();

        Task<Persons> GetPersonById(int personId);

        Task<Persons> AddPerson(Persons toCreate);

        Task<Persons> UpdatePerson(int personId, string name, string email);

        Task DeletePerson(int personId);
    }
}
