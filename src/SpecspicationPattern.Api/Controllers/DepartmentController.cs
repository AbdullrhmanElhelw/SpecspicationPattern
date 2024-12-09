using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpecspicationPattern.Api.Controllers.Infrastructure;
using SpecspicationPattern.Api.Controllers.Requests.Departments;
using SpecspicationPattern.Api.UseCases.Departments.Queries.GetAllDepartments;
using SpecspicationPattern.Api.UseCases.Departments.Queries.GetDepartmentByName;
using SpecspicationPattern.Api.UseCases.Departments.Queries.GetDepartmentWithEmployees;

namespace SpecspicationPattern.Api.Controllers;

[Route(ApiRoutes.Departments.Base)]
[ApiController]
public class DepartmentController(
    ISender sender) : ApiController(sender)
{
    [HttpGet(ApiRoutes.Departments.GetAll)]
    public async Task<IReadOnlyList<DepartmentDto>> GetAll()
    {
        return await Sender.Send(new GetAllDepartmentsQuery());
    }

    [HttpGet(ApiRoutes.Departments.GetById)]
    public async Task<DepartmentWithEmployeesDto> GetById(Guid id)
    {
        return await Sender.Send(new GetDepartmentWithEmployeesQuery { Id = id });
    }

    [HttpGet("by-name")]
    public async Task<IReadOnlyList<DepartmentDto>> GetByName([FromQuery] GetDepartmentByNameRequest request)
    {
        return await Sender.Send(new GetDepartmentByNameQuery(request.Name));
    }
}