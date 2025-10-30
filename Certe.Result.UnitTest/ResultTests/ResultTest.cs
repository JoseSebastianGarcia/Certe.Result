using Certe.Result.ErrorDefinitions;
using FluentAssertions;
using RI = Certe.Result.ResultImplementations;

namespace Certe.Result.UnitTest.ResultTests;

public class ResultTest
{
	[Fact]
	public void Result_ShouldBeSuccess()
	{
		RI.Result result = RI.Result.Success();

		result.IsSuccess.Should().BeTrue();
		result.ErrorList.Should().BeNull();
		result.IsError.Should().BeFalse();
	}

	[Fact]
	public void Result_ShouldBeFailure()
	{
		RI.Result result = RI.Result.Failure([Errors.ValidationError("A validation error")]);
		result.IsSuccess.Should().BeFalse();
		result.ErrorList.Should().HaveCount(1);
		result.ErrorList.Should().Contain(e=> e.Code == "Error.ValidationError");
		result.IsError.Should().BeTrue();
	}

}
