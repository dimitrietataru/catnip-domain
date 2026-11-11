namespace CatNip.Domain.Models.Interfaces;

public interface ICrudModel<TId> : IModel
    where TId : IEquatable<TId>
{
    TId Id { get; }
}
