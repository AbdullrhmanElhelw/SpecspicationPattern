using SpecspicationPattern.Api.Models.Departments;
using SpecspicationPattern.Api.Models.EmployeeProjects;
using SpecspicationPattern.Api.Models.Shared;

namespace SpecspicationPattern.Api.Models.Projects;

public sealed class Project : Entity
{
    private readonly HashSet<EmployeeProject> _employeeProjects = [];

    public Name Name { get; private set; }
    public Duration Duration { get; private set; }

    public Guid DepartmentId { get; private set; }
    public Department Department { get; private set; }

    public Money Budget { get; private set; }
    public IReadOnlyCollection<EmployeeProject> EmployeeProjects => _employeeProjects.ToList().AsReadOnly();

    private Project()
    {
    }

    private Project(Name name, Duration duration, Department department, Money budget)
    {
        Name = name;
        Duration = duration;
        Department = department;
        Budget = budget;
    }

    public static Project Create(Name name, Duration duration, Department department, Money budget)
    {
        return new Project(name, duration, department, budget);
    }
}