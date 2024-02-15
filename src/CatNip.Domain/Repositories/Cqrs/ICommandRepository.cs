using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Repositories.Cqrs;

public interface ICommandRepository<TModel, TId> : ICommandRepository<TModel>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
    Task UpdateAsync(TId id, TModel model, CancellationToken cancellation = default);
    Task DeleteAsync(TId id, CancellationToken cancellation = default);
}

public interface ICommandRepository<TModel>
    where TModel : IModel
{
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellation = default);
    Task UpdateAsync(TModel model, CancellationToken cancellation = default);
    Task DeleteAsync(TModel model, CancellationToken cancellation = default);
}
