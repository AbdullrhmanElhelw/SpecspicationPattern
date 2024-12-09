using SpecspicationPattern.Api.Data.Specifications;
using SpecspicationPattern.Api.Models.Shared;

namespace SpecspicationPattern.Api.Data.Repositories;

public interface IRepository<T> where T : Entity
{
    Task<T?> GetByIdAsync(int id);

    Task<IReadOnlyList<T>> ListAllAsync();

    Task<T?> GetEntityWithSpec(ISpecification<T> spec);

    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

    Task<int> CountAsync(ISpecification<T> spec);
}