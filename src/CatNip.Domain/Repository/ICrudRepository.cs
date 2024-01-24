using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Repository.Internal;

namespace CatNip.Domain.Repository;

public interface ICrudRepository<TModel, TId>
    : IQueryRepository<TModel, TId>, ICommandRepository<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
}
