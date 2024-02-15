using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query.Filtering;
using CatNip.Domain.Repositories.Cqrs;

namespace CatNip.Domain.Repositories;

public interface IAceRepository<TModel, TId, TFiltering> : ICrudRepository<TModel, TId>, IQueryRepository<TModel, TId, TFiltering>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
    where TFiltering : IFilteringRequest
{
}
