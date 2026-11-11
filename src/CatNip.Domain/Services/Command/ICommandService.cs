using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Services.Command;

public interface ICommandService<TModel>
    where TModel : IModel
{
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellation = default);
    Task UpdateAsync(TModel model, CancellationToken cancellation = default);
    Task DeleteAsync(TModel model, CancellationToken cancellation = default);
}
