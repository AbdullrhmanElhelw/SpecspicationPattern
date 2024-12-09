using Microsoft.EntityFrameworkCore;
using SpecspicationPattern.Api.Models.Departments;
using SpecspicationPattern.Api.Models.Employees;
using SpecspicationPattern.Api.Models.Projects;

namespace SpecspicationPattern.Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Project> Projects => Set<Project>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}