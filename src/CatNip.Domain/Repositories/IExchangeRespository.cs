using CatNip.Domain.ImportExport;
using CatNip.Domain.ImportExport.Csv;
using CatNip.Domain.ImportExport.Excel;

namespace CatNip.Domain.Repositories;

public interface IExchangeRespository<TExchange>
    where TExchange : ICsvMappable, IExcelMappable
{
    Task<ImportResponse> ImportAsync(ICollection<TExchange> records, CancellationToken cancellation);
}
