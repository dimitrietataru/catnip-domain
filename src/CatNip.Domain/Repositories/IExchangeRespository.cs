using CatNip.Domain.ImportExport;
using CatNip.Domain.ImportExport.Csv;

namespace CatNip.Domain.Repositories;

public interface IExchangeRespository
{
    Task<ImportResponse> ImportAsync<T>(ICollection<T> records, CancellationToken cancellation)
        where T : ICsvMappable;
}
