using Certe.Result.Extensions;
using FluentAssertions;
using RI = Certe.Result.ResultImplementations;

namespace Certe.Result.UnitTest.Extensions;

public class ResultExtensionsTest
{
	[Fact]
	public void Result_ExtensionMethod_MustBeValid()
	{
		RI.Result result = RI.Result.Success();
		bool isTrue = false;
		bool isFalse = false;

		result.Match(() => isTrue = true, _ => isFalse = true);

		isFalse.Should().BeFalse();
		isTrue.Should().BeTrue();
	}
	[Fact]
	public void Result_ExtensionMethod_MustBeInvalid()
	{
		RI.Result result = RI.Result.Failure([]);
		bool isTrue = false;
		bool isFalse = false;

		result.Match(() => isTrue = true, _ => isFalse = true);

		isFalse.Should().BeTrue();
		isTrue.Should().BeFalse();
	}
}
