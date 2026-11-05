using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Models;

public abstract class Model<TId> : Model, IModel<TId>
    where TId : IEquatable<TId>
{
    public virtual TId Id { get; set; } = default!;

    public override bool Equals(Model? other)
    {
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (other is not Model<TId> model || other.GetType() != GetType())
        {
            return false;
        }

        if (EqualityComparer<TId>.Default.Equals(Id, default) || EqualityComparer<TId>.Default.Equals(model.Id, default))
        {
            return false;
        }

        return Id.Equals(model.Id);
    }

    protected override int DetermineHashCode()
    {
        return HashCode.Combine(Id);
    }
}

public abstract class Model : IEquatable<Model>, IModel
{
    public override bool Equals(object? obj)
    {
        if (obj is not Model other)
        {
            return false;
        }

        return Equals(other);
    }

    public override int GetHashCode()
    {
        return DetermineHashCode();
    }

    public abstract bool Equals(Model? other);

    protected abstract int DetermineHashCode();
}
