using CatNip.Domain.ImportExport;
using CatNip.Domain.ImportExport.Csv;
using CatNip.Domain.ImportExport.Excel;
using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Repositories.Command;

public interface ICommandAceRepository<TModel, TId, TExchange> : ICommandAceRepository<TModel, TId, TId, TExchange>
    where TModel : IAceModel<TId>
    where TId : IEquatable<TId>
    where TExchange : ICsvMappable, IExcelMappable
{
}

public interface ICommandAceRepository<TModel, TId, TTraceId, TExchange> : ICommandCrudRepository<TModel, TId>
    where TModel : IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
    where TExchange : ICsvMappable, IExcelMappable
{
    Task<ImportResponse> ImportAsync(ICollection<TExchange> records, CancellationToken cancellation = default);
}
