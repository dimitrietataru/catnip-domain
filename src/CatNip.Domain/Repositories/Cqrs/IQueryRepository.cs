using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query;
using CatNip.Domain.Query.Filtering;

namespace CatNip.Domain.Repositories.Cqrs;

public interface IQueryRepository<TModel, TId, TFiltering> : IQueryRepository<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
    where TFiltering : IFilteringRequest
{
    Task<QueryResponse<TModel>> GetAsync(QueryRequest<TFiltering> request, CancellationToken cancellation = default);
    Task<int> CountAsync(TFiltering filter, CancellationToken cancellation = default);
    Task<bool> ExistsAsync(TFiltering filter, CancellationToken cancellation = default);
}

public interface IQueryRepository<TModel, TId> : IQueryRepository<TModel>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
    Task<TModel> GetByIdAsync(TId id, CancellationToken cancellation = default);
    Task<bool> ExistsAsync(TId id, CancellationToken cancellation = default);
}

public interface IQueryRepository<TModel>
    where TModel : IModel
{
    Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellation = default);
    Task<int> CountAsync(CancellationToken cancellation = default);
}
