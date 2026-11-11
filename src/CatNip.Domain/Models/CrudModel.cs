using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Models;

public abstract class CrudModel<TId> : Model, ICrudModel<TId>
    where TId : IEquatable<TId>
{
    public virtual TId Id { get; set; } = default!;

    public override bool Equals(Model? other)
    {
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (other is not CrudModel<TId> model || other.GetType() != GetType())
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
