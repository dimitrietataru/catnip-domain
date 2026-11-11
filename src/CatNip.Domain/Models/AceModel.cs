using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Models;

public abstract class AceModel<TId> : AceModel<TId, TId>, IAceModel<TId>
    where TId : IEquatable<TId>
{
}

public abstract class AceModel<TId, TTraceId> : CrudModel<TId>, IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
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
