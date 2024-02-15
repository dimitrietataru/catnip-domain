using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Services.Cqrs;

namespace CatNip.Domain.Services;

public interface ICrudService<TModel, TId> : ICrudService<TModel>, IQueryService<TModel, TId>, ICommandService<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
}

public interface ICrudService<TModel> : IQueryService<TModel>, ICommandService<TModel>
    where TModel : IModel
{
}
