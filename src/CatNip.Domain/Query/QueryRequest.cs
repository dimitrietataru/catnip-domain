using CatNip.Domain.Query.Filtering;
using CatNip.Domain.Query.Pagination;
using CatNip.Domain.Query.Sorting;
using CatNip.Domain.Query.Sorting.Symbols;

namespace CatNip.Domain.Query;

public sealed class QueryRequest<TFilter> : QueryRequest
    where TFilter : IFilteringRequest
{
    public QueryRequest(TFilter filter)
    {
        Filter = filter;
    }

    public QueryRequest(TFilter filter, int? page, int? size)
        : this(filter)
    {
        Page = page;
        Size = size;
    }

    public QueryRequest(TFilter filter, int? page, int? size, string? sortBy, SortDirection? sortDirection)
        : this(filter, page, size)
    {
        SortBy = sortBy;
        SortDirection = sortDirection;
    }

    public TFilter Filter { get; init; }
}

public abstract class QueryRequest : IPaginationRequest, ISortingRequest
{
    public virtual int? Page { get; init; }
    public virtual int? Size { get; init; }

    public virtual string? SortBy { get; init; }
    public virtual SortDirection? SortDirection { get; init; }

    public bool HasPaginationData()
    {
        return Page.HasValue && Size.HasValue;
    }

    public bool HasSortingData()
    {
        return !string.IsNullOrWhiteSpace(SortBy) && SortDirection.HasValue;
    }
}
