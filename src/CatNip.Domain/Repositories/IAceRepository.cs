using CatNip.Domain.ImportExport.Csv;
using CatNip.Domain.ImportExport.Excel;
using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query.Filtering;
using CatNip.Domain.Repositories.Cqrs;

namespace CatNip.Domain.Repositories;

public interface IAceRepository<TModel, TId, TFiltering, TExchange>
    : ICrudRepository<TModel, TId>, IQueryRepository<TModel, TId, TFiltering>, IExchangeRespository<TExchange>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
    where TFiltering : IFilteringRequest
    where TExchange : ICsvMappable, IExcelMappable
{
}
