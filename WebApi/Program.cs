using Application.Features.Commands.CreateDonorCommand;
using Application.Interfaces;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICreateDonorRepository, CreateDonorRepository>();
builder.Services.AddScoped<IDeleteDonorRepository, DeleteDonorRepository>();
builder.Services.AddScoped<IGetDonorRepository, GetDonorRepository>();
builder.Services.AddScoped<IGetDonorsRepository, GetDonorsRepository>();
builder.Services.AddScoped<IUpdateDonorRepository, UpdateDonorRepository>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CrudWithCqrsUsingOnion"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
