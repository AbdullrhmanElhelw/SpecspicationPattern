using SpecspicationPattern.Api.Models.Departments;

namespace SpecspicationPattern.Api.Data.Specifications.DepartmentSpecifications;

public class DepartmentByNameSpecification : Specification<Department>
{
    public DepartmentByNameSpecification(string name)
        : base(department =>
            !string.IsNullOrEmpty(department.Name.Value) &&
            department.Name.Value.ToLower().Contains(name.ToLower()))
    {
        AddOrderBy(d => d.Name.Value.Length);
    }
}