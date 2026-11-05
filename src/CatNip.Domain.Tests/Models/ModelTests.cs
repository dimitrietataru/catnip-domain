using CatNip.Domain.Models;

namespace CatNip.Domain.Tests.Models;

internal sealed class FooModel : Model<int>;
internal sealed class BarModel : Model<int>;
internal sealed class TextModel : Model<string>;
internal sealed class TraceModel : TraceableModel<int>;
internal class ParentModel : Model<int>;
internal sealed class ChildModel : ParentModel;

public sealed class ModelTests
{
    private static Model? NullModel => null;
    private static object? NullObject => null;

    [Fact]
    internal void GivenEqualsWhenTypeAndIdMatchThenReturnsTrue()
    {
        // Arrange
        var left = new FooModel { Id = 1 };
        var right = new FooModel { Id = 1 };

        // Act / Assert
        left.Equals(right).Should().BeTrue();
        left.Equals((object)right).Should().BeTrue();
    }

    [Fact]
    internal void GivenEqualsWhenTypesMatchAndIdsDifferThenReturnsFalse()
    {
        // Arrange
        var left = new FooModel { Id = 1 };
        var right = new FooModel { Id = 2 };

        // Act / Assert
        left.Equals(right).Should().BeFalse();
        left.Equals((object)right).Should().BeFalse();
    }

    [Fact]
    internal void GivenEqualsWhenTypesDifferAndIdsMatchThenReturnsFalse()
    {
        // Arrange
        var left = new FooModel { Id = 1 };
        var right = new BarModel { Id = 1 };

        // Act / Assert
        left.Equals(right).Should().BeFalse();
        right.Equals(left).Should().BeFalse();
    }

    [Fact]
    internal void GivenEqualsWhenComparingBaseAndDerivedTypesThenReturnsFalse()
    {
        // Arrange
        var parent = new ParentModel { Id = 1 };
        var child = new ChildModel { Id = 1 };

        // Act / Assert
        parent.Equals(child).Should().BeFalse();
        child.Equals(parent).Should().BeFalse();
    }

    [Fact]
    internal void GivenEqualsWhenModelArgumentIsNullThenReturnsFalse()
    {
        // Arrange
        var foo = new FooModel { Id = 1 };

        // Act / Assert
        foo.Equals(NullModel).Should().BeFalse();
    }

    [Fact]
    internal void GivenEqualsWhenObjectArgumentIsNullThenReturnsFalse()
    {
        // Arrange
        var foo = new FooModel { Id = 1 };

        // Act / Assert
        foo.Equals(NullObject).Should().BeFalse();
    }

    [Fact]
    internal void GivenEqualsWhenSameInstanceHasDefaultIdThenReturnsTrue()
    {
        // Arrange
        var foo = new FooModel();

        // Act / Assert
        foo.Equals(foo).Should().BeTrue();
    }

    [Fact]
    internal void GivenEqualsWhenDifferentInstancesHaveDefaultIdThenReturnsFalse()
    {
        // Arrange
        var left = new FooModel();
        var right = new FooModel();

        // Act / Assert
        left.Equals(right).Should().BeFalse();
        right.Equals(left).Should().BeFalse();
    }

    [Fact]
    internal void GivenEqualsWhenOneInstanceHasDefaultIdThenReturnsFalse()
    {
        // Arrange
        var saved = new FooModel { Id = 1 };
        var unsaved = new FooModel();

        // Act / Assert
        saved.Equals(unsaved).Should().BeFalse();
        unsaved.Equals(saved).Should().BeFalse();
    }

    [Fact]
    internal void GivenEqualsWhenSameInstanceHasNullIdThenReturnsTrue()
    {
        // Arrange
        var model = new TextModel();

        // Act / Assert
        model.Equals(model).Should().BeTrue();
    }

    [Fact]
    internal void GivenEqualsWhenDifferentInstancesHaveNullIdThenReturnsFalse()
    {
        // Arrange
        var left = new TextModel();
        var right = new TextModel();

        // Act / Assert
        left.Equals(right).Should().BeFalse();
    }

    [Fact]
    internal void GivenEqualsWhenOneInstanceHasNullIdThenReturnsFalse()
    {
        // Arrange
        var saved = new TextModel { Id = "a" };
        var unsaved = new TextModel();

        // Act / Assert
        saved.Equals(unsaved).Should().BeFalse();
        unsaved.Equals(saved).Should().BeFalse();
    }

    [Fact]
    internal void GivenEqualsWhenIdIsReferenceTypeThenComparesByValue()
    {
        // Arrange
        var first = new TextModel { Id = "a" };
        var second = new TextModel { Id = "a" };
        var third = new TextModel { Id = "b" };

        // Act / Assert
        first.Equals(second).Should().BeTrue();
        first.Equals(third).Should().BeFalse();
    }

    [Fact]
    internal void GivenEqualsWhenTraceFieldsDifferThenIgnoresThem()
    {
        // Arrange
        var left = new TraceModel { Id = 1, CreatedBy = 10 };
        var right = new TraceModel { Id = 1, CreatedBy = 20 };

        // Act / Assert
        left.Equals(right).Should().BeTrue();
    }

    [Fact]
    internal void GivenGetHashCodeWhenModelsAreEqualThenReturnsSameValue()
    {
        // Arrange
        var left = new FooModel { Id = 1 };
        var right = new FooModel { Id = 1 };

        // Act / Assert
        left.GetHashCode().Should().Be(right.GetHashCode());
    }

    [Fact]
    internal void GivenGetHashCodeWhenIdIsNullThenDoesNotThrow()
    {
        // Arrange
        var model = new TextModel();

        // Act / Assert
        model.Invoking(m => m.GetHashCode()).Should().NotThrow();
    }

    [Fact]
    internal void GivenHashSetWhenModelsAreUnsavedThenFindsEachInstance()
    {
        // Arrange
        var left = new FooModel();
        var right = new FooModel();
        var set = new HashSet<FooModel> { left, right };

        // Act / Assert
        set.Should().HaveCount(2);
        set.Contains(left).Should().BeTrue();
        set.Contains(right).Should().BeTrue();
    }

    [Fact]
    internal void GivenHashSetWhenSavedModelsShareIdThenKeepsOneInstance()
    {
        // Arrange
        var set = new HashSet<FooModel>
        {
            new() { Id = 1 },
            new() { Id = 1 },
        };

        // Act / Assert
        set.Should().HaveCount(1);
    }
}
