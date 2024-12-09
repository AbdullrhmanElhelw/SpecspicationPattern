using System.Diagnostics;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using SpecspicationPattern.Api;
using SpecspicationPattern.Api.Data;
using SpecspicationPattern.Api.Data.Seeders;
using SpecspicationPattern.Api.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // seed data
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    var seeders = new List<IDataSeeder>
    {
        new DepartmentSeeder()
    };

    foreach (var seeder in seeders)
    {
        seeder.SeedAsync(context).Wait();
    }

    var department = context.Departments.ToList();
    Debug.WriteLine(department.Count);
}

app.UseHttpsRedirection();

app.UseExceptionHandler(o => { });

app.UseAuthorization();

app.MapControllers();

app.Run();