using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query;
using CatNip.Domain.Query.Filtering;

namespace CatNip.Domain.Services.Query;

public interface IQueryAceService<TModel, TId, TModelRoot, TFiltering> : IQueryAceService<TModel, TId, TId, TModelRoot, TFiltering>
    where TModel : IAceModel<TId>
    where TId : IEquatable<TId>
    where TModelRoot : ICrudModel<TId>
    where TFiltering : IFilteringRequest
{
}

public interface IQueryAceService<TModel, TId, TTraceId, TModelRoot, TFiltering> : IQueryCrudService<TModel, TId>
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
