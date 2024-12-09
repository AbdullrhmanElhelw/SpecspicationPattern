using MediatR;
using SpecspicationPattern.Api.Models.Departments;

namespace SpecspicationPattern.Api.UseCases.Departments.Queries.GetAllDepartments;

public class GetAllDepartmentsQuery : IRequest<IReadOnlyList<DepartmentDto>>
{
}

public class GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
    : IRequestHandler<GetAllDepartmentsQuery, IReadOnlyList<DepartmentDto>>
{
    public async Task<IReadOnlyList<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = await departmentRepository.ListAllAsync();

        return departments.Select(d => new DepartmentDto
        {
            Id = d.Id,
            Name = d.Name.Value,
            Description = d.Description.Value,
            IsDeleted = d.IsDeleted
        }).ToList();
    }
}