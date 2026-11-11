using CatNip.Domain.Models;

namespace CatNip.Domain.Tests.Models;

internal sealed class StubModel : Model
{
    public int Key { get; init; }

    public sealed override bool Equals(Model? other)
    {
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return other is StubModel model && model.Key == Key;
    }

    protected sealed override int DetermineHashCode()
    {
        return HashCode.Combine(Key);
    }
}

public sealed class ModelTests
{
    [Fact]
    internal void GivenEqualsWhenObjectIsEqualModelThenReturnsTrue()
    {
        // Arrange
        var left = new StubModel { Key = 1 };
        var right = new StubModel { Key = 1 };

        // Act / Assert
        left.Equals((object)right).Should().BeTrue();
    }

    [Fact]
    internal void GivenEqualsWhenObjectIsDifferentModelThenReturnsFalse()
    {
        // Arrange
        var left = new StubModel { Key = 1 };
        var right = new StubModel { Key = 2 };

        // Act / Assert
        left.Equals((object)right).Should().BeFalse();
    }
}
