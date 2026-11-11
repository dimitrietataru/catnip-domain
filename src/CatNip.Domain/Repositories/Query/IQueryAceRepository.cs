using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query;
using CatNip.Domain.Query.Filtering;

namespace CatNip.Domain.Repositories.Query;

public interface IQueryAceRepository<TModel, TId, TModelRoot, TFiltering> : IQueryAceRepository<TModel, TId, TId, TModelRoot, TFiltering>
    where TModel : IAceModel<TId>
    where TId : IEquatable<TId>
    where TModelRoot : ICrudModel<TId>
    where TFiltering : IFilteringRequest
{
}

public interface IQueryAceRepository<TModel, TId, TTraceId, TModelRoot, TFiltering> : IQueryCrudRepository<TModel, TId>
    where TModel : IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
    where TModelRoot : ICrudModel<TId>
    where TFiltering : IFilteringRequest
{
    Task<QueryResponse<TModelRoot>> GetAsync(QueryRequest<TFiltering> request, CancellationToken cancellation = default);
    Task<int> CountAsync(TFiltering filter, CancellationToken cancellation = default);
    Task<bool> ExistsAsync(TFiltering filter, CancellationToken cancellation = default);
}
