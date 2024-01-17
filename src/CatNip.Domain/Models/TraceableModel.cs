using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Models;

public abstract class TraceableModel<TId> : TraceableModel<TId, TId>
    where TId : IEquatable<TId>
{
}

public abstract class TraceableModel<TModelId, TTraceId> : Model<TModelId>, ITraceableModel<TModelId, TTraceId>
    where TModelId : IEquatable<TModelId>
    where TTraceId : IEquatable<TTraceId>
{
    public virtual DateTimeOffset? CreatedAt { get; set; }
    public virtual TTraceId? CreatedBy { get; set; }

    public virtual DateTimeOffset? UpdatedAt { get; set; }
    public virtual TTraceId? UpdatedBy { get; set; }

    public virtual bool IsDeleted { get; set; }
    public virtual DateTimeOffset? DeletedAt { get; set; }
    public virtual TTraceId? DeletedBy { get; set; }
}
