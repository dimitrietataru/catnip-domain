using CatNip.Domain.ImportExport.Csv;
using CatNip.Domain.ImportExport.Excel;
using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query.Filtering;
using CatNip.Domain.Repositories.Command;
using CatNip.Domain.Repositories.Query;

namespace CatNip.Domain.Repositories;

public interface IAceRepository<TModel, TId, TModelRoot, TFiltering, TExchange>
    : IAceRepository<TModel, TId, TId, TModelRoot, TFiltering, TExchange>
    where TModel : IAceModel<TId>
    where TId : IEquatable<TId>
    where TModelRoot : ICrudModel<TId>
    where TFiltering : IFilteringRequest
    where TExchange : ICsvMappable, IExcelMappable
{
}

public interface IAceRepository<TModel, TId, TTraceId, TModelRoot, TFiltering, TExchange>
    : ICrudRepository<TModel, TId>, IQueryAceRepository<TModel, TId, TTraceId, TModelRoot, TFiltering>, ICommandAceRepository<TModel, TId, TTraceId, TExchange>
    where TModel : IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
    where TModelRoot : ICrudModel<TId>
    where TFiltering : IFilteringRequest
    where TExchange : ICsvMappable, IExcelMappable
{
}
