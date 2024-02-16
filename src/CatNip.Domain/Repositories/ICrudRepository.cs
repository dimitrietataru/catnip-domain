using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Repositories.Cqrs;

namespace CatNip.Domain.Repositories;

public interface ICrudRepository<TModel, TId> : IQueryRepository<TModel, TId>, ICommandRepository<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
    IUnitOfWork<TModel> UnitOfWork { get; }
}

public interface ICrudRepository<TModel> : IQueryRepository<TModel>, ICommandRepository<TModel>
    where TModel : IModel
{
    IUnitOfWork<TModel> UnitOfWork { get; }
}
