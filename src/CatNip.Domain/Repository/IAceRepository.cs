using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query.Filtering;
using CatNip.Domain.Repository.Internal;

namespace CatNip.Domain.Repository;

public interface IAceRepository<TModel, TId, TFiltering>
    : IQueryRepository<TModel, TId, TFiltering>, ICrudRepository<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
    where TFiltering : IFilteringRequest
{
}
