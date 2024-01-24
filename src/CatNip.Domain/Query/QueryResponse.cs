using CatNip.Domain.Models.Interfaces;
using CatNip.Domain.Query.Pagination;
using CatNip.Domain.Query.Sorting;

namespace CatNip.Domain.Query;

public sealed class QueryResponse<TModel> : QueryResponse, IPaginationResponse<TModel>
    where TModel : IModel
{
    public QueryResponse()
    {
    }

    public QueryResponse(int? page, int? size, int count, IEnumerable<TModel> items)
        : this()
    {
        Page = page;
        Size = size;
        Count = count;
        Items = items;
    }

    public int Count { get; init; }
    public IEnumerable<TModel> Items { get; init; } = new List<TModel>();
}

public class QueryResponse : IPaginationResponse, ISortingResponse
{
    public virtual int? Page { get; init; }

    public virtual int? Size { get; init; }
}
