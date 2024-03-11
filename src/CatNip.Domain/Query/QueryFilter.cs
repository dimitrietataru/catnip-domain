using CatNip.Domain.Query.Filtering;

namespace CatNip.Domain.Query;

public abstract class QueryFilter<TId> : QueryFilter<TId, TId>
    where TId : IEquatable<TId>
{
}

public abstract class QueryFilter<TId, TIds> : IFilteringRequest
    where TId : IEquatable<TId>
    where TIds : IEquatable<TIds>
{
    public virtual TId Id { get; init; } = default!;
    public virtual IEnumerable<TIds> Ids { get; init; } = [];
}
