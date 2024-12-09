using SpecspicationPattern.Api.Models.Departments;

namespace SpecspicationPattern.Api.Data.Specifications.DepartmentSpecifications;

public class DepartmentWithEmployeesSpecification : Specification<Department>
{
    public DepartmentWithEmployeesSpecification(Guid id) : base(department =>
        department.Id == id)
    {
        AddInclude(d => d.Employees);
    }
}