using CatNip.Domain.ImportExport;
using CatNip.Domain.ImportExport.Csv;

namespace CatNip.Domain.Repositories;

public interface IExchangeRespository<TExchange>
    where TExchange : ICsvMappable
{
    Task<ImportResponse> ImportAsync(ICollection<TExchange> records, CancellationToken cancellation);
}
