using CatNip.Domain.Query.Sorting.Symbols;

namespace CatNip.Domain.Query.Sorting;

public interface ISortingRequest
{
    string? SortBy { get; }
    SortDirection? SortDirection { get; }

    bool HasSortingData();
}
