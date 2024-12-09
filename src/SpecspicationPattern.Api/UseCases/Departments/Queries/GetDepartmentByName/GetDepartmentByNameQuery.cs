using MediatR;
using SpecspicationPattern.Api.Data.Specifications.DepartmentSpecifications;
using SpecspicationPattern.Api.Models.Departments;
using SpecspicationPattern.Api.UseCases.Departments.Queries.GetAllDepartments;
using SpecspicationPattern.Api.Utilities.Exceptions;

namespace SpecspicationPattern.Api.UseCases.Departments.Queries.GetDepartmentByName;

public record GetDepartmentByNameQuery(string Name) : IRequest<IReadOnlyList<DepartmentDto>>;

public sealed class GetDepartmentByNameQueryHandler(IDepartmentRepository departmentRepository)
     : IRequestHandler<GetDepartmentByNameQuery, IReadOnlyList<DepartmentDto>>
{
    public async Task<IReadOnlyList<DepartmentDto>> Handle(GetDepartmentByNameQuery request, CancellationToken cancellationToken)
    {
        var specification = new DepartmentByNameSpecification(request.Name);

        var departments = await departmentRepository.ListAsync(new DepartmentByNameSpecification(request.Name));

        return departments.Select(d => new DepartmentDto
        {
            Id = d.Id,
            Name = d.Name.Value,
            Description = d.Description.Value,
            IsDeleted = d.IsDeleted
        }).ToList();
    }
}