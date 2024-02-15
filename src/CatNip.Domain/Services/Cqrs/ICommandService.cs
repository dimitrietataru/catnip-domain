using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Services.Cqrs;

public interface ICommandService<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellation = default);
    Task UpdateAsync(TId id, TModel model, CancellationToken cancellation = default);
    Task DeleteAsync(TId id, CancellationToken cancellation = default);
}

public interface ICommandService<TModel>
    where TModel : IModel
{
    Task CreateAsync(TModel model, CancellationToken cancellation = default);
    Task UpdateAsync(TModel model, CancellationToken cancellation = default);
    Task DeleteAsync(TModel model, CancellationToken cancellation = default);
}
