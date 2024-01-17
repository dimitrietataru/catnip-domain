namespace CatNip.Domain.Models.Interfaces.Trace;

public interface IAddTraceable<TTraceId>
    where TTraceId : IEquatable<TTraceId>
{
    DateTimeOffset? CreatedAt { get; set; }
    TTraceId? CreatedBy { get; set; }
}
