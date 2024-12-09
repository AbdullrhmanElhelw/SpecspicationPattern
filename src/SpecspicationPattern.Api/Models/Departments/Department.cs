using SpecspicationPattern.Api.Models.Employees;
using SpecspicationPattern.Api.Models.Projects;
using SpecspicationPattern.Api.Models.Shared;

namespace SpecspicationPattern.Api.Models.Departments;

public sealed class Department : Entity
{
    private readonly HashSet<Project> _projects = [];
    private readonly HashSet<Employee> _employees = [];
    public Name Name { get; private set; }

    public Code Code { get; private set; }
    public Description Description { get; private set; }

    public IReadOnlyCollection<Project> Projects => _projects.ToList().AsReadOnly();

    public IReadOnlyCollection<Employee> Employees => _employees.ToList().AsReadOnly();

    private Department()
    {
    }

    private Department(Name name, Code code, Description description)
    {
        Name = name;
        Code = code;
        Description = description;
    }

    public static Department Create(Name name, Code code, Description description)
    {
        return new Department(name, code, description);
    }
}