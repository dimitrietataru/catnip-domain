using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Models;

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
