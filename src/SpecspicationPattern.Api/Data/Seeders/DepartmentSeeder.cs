using SpecspicationPattern.Api.Models.Departments;
using SpecspicationPattern.Api.Models.Shared;

namespace SpecspicationPattern.Api.Data.Seeders;

public class DepartmentSeeder : IDataSeeder
{
    public Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Departments.Any())
        {
            return Task.CompletedTask;
        }

        var departments = new List<Department>
        {
          Department.Create(
              name: new Name("HR"),
              code: new Code("HR"),
                description: "Human Resources Department"
              ),
            Department.Create(
                name: new Name("IT"),
                code: new Code("IT"),
                description: "Information Technology Department"
                ),
            Department.Create(
                name: new Name("FIN"),
                code: new Code("FIN"),
                description: "Finance Department"
                ),
            Department.Create(
                name: new Name("SALES"),
                code: new Code("SALES"),
                description: "Sales Department"
                ),
            Department.Create(
                name: new Name("MARKETING"),
                code: new Code("MARKETING"),
                description: "Marketing Department"
                ),
            Department.Create(
                name: new Name("OPS"),
                code: new Code("OPS"),
                description: "Operations Department"
                ),
            Department.Create(
                name: new Name("LEGAL"),
                code: new Code("LEGAL"),
                description: "Legal Department"
                )
        };

        context.Departments.AddRange(departments);
        return context.SaveChangesAsync();
    }
}