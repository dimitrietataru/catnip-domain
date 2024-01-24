namespace CatNip.Domain.Query.Pagination;

public interface IPaginationRequest
{
    int? Page { get; }
    int? Size { get; }
}
