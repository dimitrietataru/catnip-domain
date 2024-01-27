using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Repositories.Internal;

namespace CatNip.Domain.Repositories;

public interface ICrudRepository<TModel, TId>
    : IQueryRepository<TModel, TId>, ICommandRepository<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
}
