namespace CatNip.Domain.Models.Interfaces.Trace;

public interface IEditTraceable<TTraceId>
    where TTraceId : IEquatable<TTraceId>
{
    DateTimeOffset? UpdatedAt { get; set; }
    TTraceId? UpdatedBy { get; set; }
}
