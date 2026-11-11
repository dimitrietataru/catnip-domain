using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Repositories.Command;
using CatNip.Domain.Repositories.Query;
using CatNip.Domain.Repositories.UnitOfWork;

namespace CatNip.Domain.Repositories;

public interface IRepository<TModel> : IQueryRepository<TModel>, ICommandRepository<TModel>
    where TModel : IModel
{
    IUnitOfWork<TModel> UnitOfWork { get; }
}
