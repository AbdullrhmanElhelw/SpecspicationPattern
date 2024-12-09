namespace SpecspicationPattern.Api.UseCases.Departments.Queries.GetAllDepartments;

public record DepartmentDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public bool IsDeleted { get; init; }
}