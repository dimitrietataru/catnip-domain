using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Services.Query;

public interface IQueryService<TModel>
    where TModel : IModel
{
    Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellation = default);
    Task<int> CountAsync(CancellationToken cancellation = default);
}
