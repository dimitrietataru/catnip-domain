using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Services.Internal;

namespace CatNip.Domain.Services;

public interface ICrudService<TModel, TId> : IQueryService<TModel, TId>, ICommandService<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
}
