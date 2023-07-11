using Application;
using Application.Abstractions;
using Infrastructure;
using Infrastructure.Repositories;
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

