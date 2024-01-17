namespace CatNip.Domain.Models.Interfaces;

public interface IModel<TId> : IModel
    where TId : IEquatable<TId>
{
    TId Id { get; }
}

public interface IModel
{
}
