using CatNip.Domain.Models;
using CatNip.Domain.Models.Interfaces;

namespace CatNip.Domain.Tests.Models;

internal sealed class TraceModel : AceModel<int>;

public sealed class AceModelTests
{
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
    internal void GivenSingleIdModelWhenCheckingContractThenImplementsSingleIdInterface()
    {
        // Arrange
        var model = new TraceModel();

        // Act / Assert
        model.Should().BeAssignableTo<IAceModel<int>>();
    }
}
