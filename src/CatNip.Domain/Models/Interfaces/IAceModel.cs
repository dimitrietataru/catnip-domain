using CatNip.Domain.Models.Interfaces.Trace;

namespace CatNip.Domain.Models.Interfaces;

public interface IAceModel<TId> : IAceModel<TId, TId>
    where TId : IEquatable<TId>
{
}

public interface IAceModel<TId, TTraceId> : ICrudModel<TId>, IAddTraceable<TTraceId>, IEditTraceable<TTraceId>, IRemoveTraceable<TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
{
}
