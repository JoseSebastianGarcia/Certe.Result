using Certe.Result.ResultSets;
using FluentAssertions;

namespace Certe.Result.UnitTest.ResultSets;

public class ResultSetsTest
{
	[Fact]
	public void SimpleResultSet_MustBeValid()
	{
		var resultSet = SimpleResultSet<int>.Create(60);

		resultSet.Should().NotBeNull();
		resultSet.Value.Should().Be(60);
	}

	[Fact]
	public void PagedResultSet_MustBeValid()
	{
		int[] numbers = [10,20,30,40,50,60,70,80,90,100];
		int[] filteredNumber = numbers.Skip(0).Take(5).ToArray();
		var resultSet = PagedResultSet<int>.Create(filteredNumber, 1,5, numbers.Length);

		resultSet.Should().NotBeNull();
		resultSet.Items.Should().HaveCount(5);
		resultSet.PageNumber.Should().Be(1);
		resultSet.PageSize.Should().Be(5);
		resultSet.TotalRecords.Should().Be(10);
		resultSet.TotalPages.Should().Be(2);
	}
}
