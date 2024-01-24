using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query.Filtering;
using CatNip.Domain.Services.Internal;

namespace CatNip.Domain.Services;

public interface IAceService<TModel, TId, TFiltering>
    : IQueryService<TModel, TId, TFiltering>, ICrudService<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
    where TFiltering : IFilteringRequest
{
}
