using Certe.Result.Extensions;
using Certe.Result.ResultSets;
using FluentAssertions;
using RI = Certe.Result.ResultImplementations;

namespace Certe.Result.UnitTest.Extensions;

public class ResultOfTExtensionsTest
{
	[Fact]
	public void ResultOfT_ExtensionMethod_MustBeValid()
	{
		RI.Result<SimpleResultSet<int>> result = RI.Result<SimpleResultSet<int>>.Success(SimpleResultSet<int>.Create(100));
		bool isTrue = false;
		bool isFalse = false;

		result.Match(_ => isTrue = true, _ => isFalse = true);

		isFalse.Should().BeFalse();
		isTrue.Should().BeTrue();
	}
	[Fact]
	public void ResultOfT_ExtensionMethod_MustBeInvalid()
	{
		RI.Result<SimpleResultSet<int>> result = RI.Result<SimpleResultSet<int>>.Failure([]);
		bool isTrue = false;
		bool isFalse = false;

		result.Match(_ => isTrue = true, _ => isFalse = true);

		isFalse.Should().BeTrue();
		isTrue.Should().BeFalse();
	}
}
