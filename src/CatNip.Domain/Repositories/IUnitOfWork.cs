using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Repositories;

public interface IUnitOfWork<TModel> : IUnitOfWork
    where TModel : IModel
{
    void Create(TModel model);
    void Update(TModel model);
    void Delete(TModel model);
}

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellation = default);
}
