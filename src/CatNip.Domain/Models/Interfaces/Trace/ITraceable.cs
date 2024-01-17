namespace CatNip.Domain.Models.Interfaces.Trace;

public interface ITraceable<TTraceId>
    : IAddTraceable<TTraceId>, IEditTraceable<TTraceId>, IRemoveTraceable<TTraceId>
    where TTraceId : IEquatable<TTraceId>
{
}
