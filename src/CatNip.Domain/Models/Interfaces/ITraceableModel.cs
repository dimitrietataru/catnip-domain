using CatNip.Domain.Models.Interfaces.Trace;

namespace CatNip.Domain.Models.Interfaces;

public interface ITraceableModel<TId> : ITraceableModel<TId, TId>
    where TId : IEquatable<TId>
{
}

public interface ITraceableModel<TModelId, TTraceId> : IModel<TModelId>, ITraceable<TTraceId>
    where TModelId : IEquatable<TModelId>
    where TTraceId : IEquatable<TTraceId>
{
}
