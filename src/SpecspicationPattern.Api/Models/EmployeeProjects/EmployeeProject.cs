using SpecspicationPattern.Api.Models.Employees;
using SpecspicationPattern.Api.Models.Projects;

namespace SpecspicationPattern.Api.Models.EmployeeProjects;

public sealed class EmployeeProject
{
    public Guid EmployeeId { get; private set; }
    public Guid ProjectId { get; private set; }

    public Employee Employee { get; private set; }
    public Project Project { get; private set; }
}