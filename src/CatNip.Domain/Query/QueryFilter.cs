using CatNip.Domain.Query.Filtering;

namespace CatNip.Domain.Query;

public abstract class QueryFilter<TId> : IFilteringRequest
    where TId : IEquatable<TId>
{
    public virtual TId Id { get; init; } = default!;
    public virtual IEnumerable<TId> Ids { get; init; } = new HashSet<TId>();
}
