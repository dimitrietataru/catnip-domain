using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Repositories.Query;

public interface IQueryCrudRepository<TModel, TId> : IQueryRepository<TModel>
    where TModel : ICrudModel<TId>
    where TId : IEquatable<TId>
{
    Task<TModel> GetByIdAsync(TId id, CancellationToken cancellation = default);
    Task<bool> ExistsAsync(TId id, CancellationToken cancellation = default);
}
