using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Repository.Internal;

public interface ICommandRepository<TModel, TId> : ICommandRepository<TModel>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
    Task DeleteAsync(TId id, CancellationToken cancellation = default);
}

public interface ICommandRepository<TModel>
    where TModel : IModel
{
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellation = default);
    Task UpdateAsync(TModel model, CancellationToken cancellation = default);
}
