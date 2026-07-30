using CatNip.Domain.ImportExport;
using CatNip.Domain.ImportExport.Csv;
using CatNip.Domain.ImportExport.Excel;

namespace CatNip.Domain.Services;

public interface IExchangeService<TExchange> : IExchangeCsvService<TExchange>, IExchangeExcelService<TExchange>
    where TExchange : ICsvMappable, IExcelMappable
{
}

public interface IExchangeCsvService<TCsvExchange>
    where TCsvExchange : ICsvMappable
{
    Task<ImportResponse> ImportCsvAsync(ImportRequest request, CancellationToken cancellation = default);
}

public interface IExchangeExcelService<TExcelExchange>
    where TExcelExchange : IExcelMappable
{
    Task<ImportResponse> ImportExcelAsync(ImportRequest request, CancellationToken cancellation = default);
}
