using Application;
using Application.Abstractions;
using Application.Person.Commands;
using Application.Person.Queries;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add your application and infrastructure services.
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Add your DbContext service.
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<PersonDbContext>(opt => opt.UseSqlServer(cs)); ;

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreatePerson)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/{id:int}", async (IMediator mediator, int id) =>
{
    var getPerson = new GetPersonById { Id = id };
    var person = await mediator.Send(getPerson);

    // Handle the response and return it
    // ...
});

app.MapControllers();

app.Run();

