using CatNip.Domain.ImportExport;
using CatNip.Domain.ImportExport.Csv;

namespace CatNip.Domain.Services;

public interface IExchangeService<TExchange>
    where TExchange : ICsvMappable
{
    Task<ImportResponse> ImportAsync(ImportRequest request, CancellationToken cancellation = default);
}
