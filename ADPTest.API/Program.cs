using ADPTest.Application.Abstract;
using ADPTest.Application.Services;
using ADPTest.Domain.Abstract.Repository;
using ADPTest.Repository.Context;
using ADPTest.Repository.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI 
builder.Services.AddScoped<IAdpTestService, ADPTestService>();
builder.Services.AddScoped<IAdpTestRepository, AdpTestRepository>();

// DBContext 
builder.Services.AddDbContext<AdpContext>(options =>
    options.UseInMemoryDatabase("DemoDb")); 

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
