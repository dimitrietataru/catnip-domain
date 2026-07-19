using CatNip.Domain.ImportExport;

namespace CatNip.Domain.Services;

public interface IExchangeService
{
    Task<ImportResponse> ImportAsync(ImportRequest request, CancellationToken cancellation = default);
}
