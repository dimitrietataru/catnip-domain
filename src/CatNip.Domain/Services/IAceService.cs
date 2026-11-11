using CatNip.Domain.ImportExport.Csv;
using CatNip.Domain.ImportExport.Excel;
using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query.Filtering;
using CatNip.Domain.Services.Command;
using CatNip.Domain.Services.Query;

namespace CatNip.Domain.Services;

public interface IAceService<TModel, TId, TModelRoot, TFiltering, TExchange>
    : IAceService<TModel, TId, TId, TModelRoot, TFiltering, TExchange>
    where TModel : IAceModel<TId>
    where TId : IEquatable<TId>
    where TModelRoot : ICrudModel<TId>
    where TFiltering : IFilteringRequest
    where TExchange : ICsvMappable, IExcelMappable
{
}

public interface IAceService<TModel, TId, TTraceId, TModelRoot, TFiltering, TExchange>
    : ICrudService<TModel, TId>, IQueryAceService<TModel, TId, TTraceId, TModelRoot, TFiltering>, ICommandAceService<TModel, TId, TTraceId, TExchange>
    where TModel : IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
    where TModelRoot : ICrudModel<TId>
    where TFiltering : IFilteringRequest
    where TExchange : ICsvMappable, IExcelMappable
{
}
