using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Query.Pagination;

public interface IPaginationResponse<TModel> : IPaginationResponse
    where TModel : IModel
{
    int Count { get; }
    IEnumerable<TModel> Items { get; }
}

public interface IPaginationResponse
{
    int? Page { get; }
    int? Size { get; }
}
