using AutoMapper;
using Eventim.Expenses.Model.Context;
using Eventim.ExpensesAPI.Config;
using Eventim.ExpensesAPI.Repository;
using Eventim.ExpensesAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SqlContext>(options =>options.UseSqlServer(connectionString));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IExpensesGroupsRepository, ExpensesGroupsRepository>();
builder.Services.AddScoped<IExpensesGroupsPeopleRepository, ExpensesGroupsPeopleRepository>();
builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Eventim",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                          
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Eventim");

app.UseAuthorization();

app.MapControllers();

app.Run();
