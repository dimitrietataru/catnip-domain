using CatNip.Domain.ImportExport.Csv;
using CatNip.Domain.ImportExport.Excel;
using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query.Filtering;
using CatNip.Domain.Services.Cqrs;

namespace CatNip.Domain.Services;

public interface IAceService<TModel, TId, TFiltering, TExchange>
    : ICrudService<TModel, TId>, IQueryService<TModel, TId, TFiltering>, IExchangeService<TExchange>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
    where TFiltering : IFilteringRequest
    where TExchange : ICsvMappable, IExcelMappable
{
}
