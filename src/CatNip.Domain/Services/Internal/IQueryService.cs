using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query;
using CatNip.Domain.Query.Filtering;

namespace CatNip.Domain.Services.Internal;

public interface IQueryService<TModel, TId, TFiltering> : IQueryService<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
    where TFiltering : IFilteringRequest
{
    Task<QueryResponse<TModel>> GetAsync(QueryRequest<TFiltering> request, CancellationToken cancellation = default);
    Task<int> CountAsync(QueryRequest<TFiltering> request, CancellationToken cancellation = default);
}

public interface IQueryService<TModel, TId> : IQueryService<TModel>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
    Task<TModel> GetByIdAsync(TId id, CancellationToken cancellation = default);
    Task<bool> ExistsAsync(TId id, CancellationToken cancellation = default);
}

public interface IQueryService<TModel>
    where TModel : IModel
{
    Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellation = default);
    Task<int> CountAsync(CancellationToken cancellation = default);
}
