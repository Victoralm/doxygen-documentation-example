using doxygen_documentation_example.Data.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Configuration;
using doxygen_documentation_example.Data;
using doxygen_documentation_example.Mediator;
//using MediatR;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<Context>(); // Can't be used with Transactions
builder.Services.AddScoped<Context>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient(typeof(IUserRepository), typeof(UserRepository));

//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();
//builder.Services.AddTransient(typeof(IMediatorHandler), typeof(MediatorHandler));


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
