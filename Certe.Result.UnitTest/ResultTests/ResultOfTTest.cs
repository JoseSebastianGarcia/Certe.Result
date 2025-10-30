using Certe.Result.ErrorDefinitions;
using Certe.Result.ResultSets;
using FluentAssertions;
using RI = Certe.Result.ResultImplementations;



namespace Certe.Result.UnitTest.ResultTests;

public class ResultOfTTest
{
	[Fact]
	public void ResultOfT_ShouldBeSingleSuccess()
	{
		RI.Result<SimpleResultSet<int>> result = RI.Result<SimpleResultSet<int>>.Success(SimpleResultSet<int>.Create(10));

		result.IsSuccess.Should().BeTrue();
		result.ErrorList.Should().BeNull();
		result.IsError.Should().BeFalse();
		result.Data.Should().NotBeNull();
		result.Data.Value.Should().Be(10);
	}

	[Fact]
	public void ResultOfT_ShouldBeSingleFailure()
	{
		RI.Result<SimpleResultSet<int>> result = RI.Result<SimpleResultSet<int>>.Failure([Errors.InternalServerError("An example error")]);
		result.IsSuccess.Should().BeFalse();
		result.ErrorList.Should().HaveCount(1);
		result.ErrorList.Should().Contain(e => e.Code == "Error.InternalServerError");
		result.IsError.Should().BeTrue();
		result.Data.Should().BeNull();
	}

	[Theory]
	[InlineData(1, 10)]
	[InlineData(1, 15)]
	[InlineData(1, 5)]
	[InlineData(2, 5)]
	public void ResultOfT_ShouldBePagedSuccess(int PageNumber, int PageSize)
	{
		List<string> fruits = ["apple", "banana", "orange", "grape", "watermelon", "pineapple", "strawberry", "blueberry", "mango", "pear", "peach", "cherry", "kiwi", "plum", "raspberry", "blackberry", "papaya", "lemon", "lime", "coconut", "pomegranate", "apricot", "fig", "guava", "tangerine", "nectarine", "passionfruit", "cranberry", "dragonfruit", "melon"];
		IEnumerable<string> filteredFruits = fruits.Skip(PageNumber-1).Take(PageSize);
		RI.Result<PagedResultSet<string>> result = RI.Result<PagedResultSet<string>>.Success(PagedResultSet<string>.Create(filteredFruits, PageNumber, PageSize, fruits.Count));

		result.IsSuccess.Should().BeTrue();
		result.ErrorList.Should().BeNull();
		result.IsError.Should().BeFalse();
		result.Data.Should().NotBeNull();
		result.Data.Items.Should().HaveCount(filteredFruits.Count());
		result.Data.PageNumber.Should().Be(PageNumber);
		result.Data.PageSize.Should().Be(PageSize);
		result.Data.TotalRecords.Should().Be(fruits.Count);
		result.Data.TotalPages.Should().Be((int)Math.Ceiling((double)fruits.Count/PageSize));
	}

	[Fact]
	public void ResultOfT_ShouldBePagedFailure()
	{
		RI.Result<PagedResultSet<string>> result = RI.Result<PagedResultSet<string>>.Failure([Errors.InternalServerError("An example error")]);
		result.IsSuccess.Should().BeFalse();
		result.ErrorList.Should().HaveCount(1);
		result.ErrorList.Should().Contain(e => e.Code == "Error.InternalServerError");
		result.IsError.Should().BeTrue();
		result.Data.Should().BeNull();
	}
}
