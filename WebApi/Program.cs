using Application;
using Application.Abstractions;
using Application.Person.Commands;
using Application.Person.Queries;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<PersonDbContext>(options => { options.UseSqlite(cs); });
builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreatePerson).Assembly));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/{id}", async ([FromServices] IMediator mediator, [FromRoute] int id) =>
{
    var response = await mediator.Send(new GetPersonById()
    {
        Id = id
    });
    return Results.Ok(response);
});

app.Run();