using CatNip.Domain.ImportExport;
using CatNip.Domain.ImportExport.Csv;
using CatNip.Domain.ImportExport.Excel;
using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Services.Command;

public interface ICommandAceService<TModel, TId, TExchange> : ICommandAceService<TModel, TId, TId, TExchange>
    where TModel : IAceModel<TId>
    where TId : IEquatable<TId>
    where TExchange : ICsvMappable, IExcelMappable
{
}

public interface ICommandAceService<TModel, TId, TTraceId, TExchange> : ICommandCrudService<TModel, TId>
    where TModel : IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
    where TExchange : ICsvMappable, IExcelMappable
{
    Task<ImportResponse> ImportCsvAsync(ImportRequest request, CancellationToken cancellation = default);
    Task<ImportResponse> ImportExcelAsync(ImportRequest request, CancellationToken cancellation = default);
}
