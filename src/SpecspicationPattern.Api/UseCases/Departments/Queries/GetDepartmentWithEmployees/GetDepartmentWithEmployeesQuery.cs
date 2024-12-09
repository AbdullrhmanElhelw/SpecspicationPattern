using MediatR;
using SpecspicationPattern.Api.Data.Specifications.DepartmentSpecifications;
using SpecspicationPattern.Api.Models.Departments;
using SpecspicationPattern.Api.Utilities.Exceptions;

namespace SpecspicationPattern.Api.UseCases.Departments.Queries.GetDepartmentWithEmployees;

public class GetDepartmentWithEmployeesQuery : IRequest<DepartmentWithEmployeesDto>
{
    public Guid Id { get; init; }
}

public record DepartmentWithEmployeesDto(
    Guid Id,
    string Name,
    IReadOnlyList<EmployeeDto> Employees);

public record EmployeeDto
{
    public Guid Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;
}

public class
    GetAllDepartmentsWithEmployeesQueryHandler(IDepartmentRepository departmentRepository) :
    IRequestHandler<GetDepartmentWithEmployeesQuery, DepartmentWithEmployeesDto>
{
    public async Task<DepartmentWithEmployeesDto> Handle(
        GetDepartmentWithEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        var department = await departmentRepository.GetEntityWithSpec(new DepartmentWithEmployeesSpecification(request.Id));

        if (department is null)
        {
            throw new ApplicationException("Department not found");
        }

        var dto = new DepartmentWithEmployeesDto(department.Id,
            department.Name,
            department.Employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName
            }).ToList());

        return dto;
    }
}