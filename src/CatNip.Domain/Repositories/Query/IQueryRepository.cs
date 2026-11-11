using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Repositories.Query;

public interface IQueryRepository<TModel>
    where TModel : IModel
{
    Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellation = default);
    Task<int> CountAsync(CancellationToken cancellation = default);
}
