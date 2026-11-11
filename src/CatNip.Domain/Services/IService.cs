using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Services.Command;
using CatNip.Domain.Services.Query;

namespace CatNip.Domain.Services;

public interface IService<TModel> : IQueryService<TModel>, ICommandService<TModel>
    where TModel : IModel
{
}
