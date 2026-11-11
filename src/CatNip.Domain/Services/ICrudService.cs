using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Services.Command;
using CatNip.Domain.Services.Query;

namespace CatNip.Domain.Services;

public interface ICrudService<TModel, TId> : IService<TModel>, IQueryCrudService<TModel, TId>, ICommandCrudService<TModel, TId>
    where TModel : ICrudModel<TId>
    where TId : IEquatable<TId>
{
}
