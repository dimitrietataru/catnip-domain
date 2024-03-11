using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query.Filtering;
using CatNip.Domain.Services.Cqrs;

namespace CatNip.Domain.Services;

public interface IAceService<TModel, TId, TFiltering>
    : ICrudService<TModel, TId>, IQueryService<TModel, TId, TFiltering>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
    where TFiltering : IFilteringRequest
{
}
