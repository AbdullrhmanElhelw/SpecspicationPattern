using SpecspicationPattern.Api.Models.Departments;

namespace SpecspicationPattern.Api.Data.Repositories;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}