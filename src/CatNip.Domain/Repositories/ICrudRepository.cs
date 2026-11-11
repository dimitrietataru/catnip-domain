using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Repositories.Command;
using CatNip.Domain.Repositories.Query;

namespace CatNip.Domain.Repositories;

public interface ICrudRepository<TModel, TId> : IRepository<TModel>, IQueryCrudRepository<TModel, TId>, ICommandCrudRepository<TModel, TId>
    where TModel : ICrudModel<TId>
    where TId : IEquatable<TId>
{
}
