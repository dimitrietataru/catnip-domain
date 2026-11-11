using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Services.Command;

public interface ICommandCrudService<TModel, TId> : ICommandService<TModel>
    where TModel : ICrudModel<TId>
    where TId : IEquatable<TId>
{
    Task UpdateAsync(TId id, TModel model, CancellationToken cancellation = default);
    Task DeleteAsync(TId id, CancellationToken cancellation = default);
}
