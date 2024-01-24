using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Services.Internal;

public interface ICommandService<TModel, TId> : ICommandService<TModel>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
    Task DeleteAsync(TId id, CancellationToken cancellation = default);
}

public interface ICommandService<TModel>
    where TModel : IModel
{
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellation = default);
    Task UpdateAsync(TModel model, CancellationToken cancellation = default);
}
