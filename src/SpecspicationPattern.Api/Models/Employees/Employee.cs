using SpecspicationPattern.Api.Models.Departments;
using SpecspicationPattern.Api.Models.EmployeeProjects;
using SpecspicationPattern.Api.Models.Shared;

namespace SpecspicationPattern.Api.Models.Employees;

public sealed class Employee : Entity
{
    private readonly HashSet<EmployeeProject> _employeeProjects = [];
    public FirstName FirstName { get; }
    public LastName LastName { get; }

    public Guid DepartmentId { get; private set; }
    public Department Department { get; private set; }

    public IReadOnlyCollection<EmployeeProject> EmployeeProjects => _employeeProjects.ToList().AsReadOnly();

    private Employee()
    {
    }

    private Employee(FirstName firstName, LastName lastName, Department department)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Employee Create(FirstName firstName, LastName lastName, Department department)
    {
        return new Employee(firstName, lastName, department);
    }
}