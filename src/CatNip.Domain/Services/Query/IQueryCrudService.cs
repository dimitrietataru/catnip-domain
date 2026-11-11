using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Services.Query;

public interface IQueryCrudService<TModel, TId> : IQueryService<TModel>
    where TModel : ICrudModel<TId>
    where TId : IEquatable<TId>
{
    Task<TModel> GetByIdAsync(TId id, CancellationToken cancellation = default);
    Task<bool> ExistsAsync(TId id, CancellationToken cancellation = default);
}
