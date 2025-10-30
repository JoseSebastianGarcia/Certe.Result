using Certe.Result.ErrorDefinitions;
using FluentAssertions;

namespace Certe.Result.UnitTest.ErrorDefinitions;

public class ErrorTest
{
	[Fact]
	public void Error_MustBe_Valid() 
	{
		Error error = Errors.InternalServerError("An unexpected error");
		error.Code.Should().Be("Error.InternalServerError");
		error.Message.Should().Be("An unexpected error");
		error.Detail.Should().BeNull();
	}
	[Fact]
	public void CustomError_MustBe_Valid()
	{
		Error error = Error.Throw("Custom.Error","A message","A detail 123");
		error.Code.Should().Be("Custom.Error");
		error.Message.Should().Be("A message");
		error.Detail.Should().Be("A detail 123");
	}

}
