using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.Intrinsics.X86;

namespace Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly PersonDbContext _context;

    public PersonRepository(PersonDbContext context)
    {
        _context = context;
    }

    public async Task<Persons> AddPerson(Persons toCreate)
    {
        _context.Person.Add(toCreate);

        await _context.SaveChangesAsync();

        return toCreate;
    }

    public async Task DeletePerson(int personId)
    {
        var person = _context.Person
            .FirstOrDefault(p => p.Id == personId);

        if (person is null) return;

        _context.Person.Remove(person);

        await _context.SaveChangesAsync();
    }

   
    public async Task<ICollection<Persons>> GetAll()
    {
        return await _context.Person.ToListAsync();
    }

    public async Task<Persons> GetPersonById(int personId)
    {
        return await _context.Person.FirstOrDefaultAsync(p => p.Id == personId);
    }
    
    private async Task<IResult> GetPersonById(IMediator mediator, int id)
{
    var getPerson = new GetPersonById { Id = id };
    var person = await mediator.Send(getPerson);
    
    return TypedResults.Ok(person);
}

    public async Task<Persons> UpdatePerson(int personId, string name, string email)
    {
        var person = await _context.Person.FirstOrDefaultAsync(p => p.Id == personId);
        person.Name = name;
        person.Email = email;
        await _context.SaveChangesAsync();

        return person;

        // burada chapter yazıyordu ve persona cevırdım.
    }
}