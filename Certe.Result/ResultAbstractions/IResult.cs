using Certe.Result.ErrorDefinitions;

namespace Certe.Result.ResultAbstractions;

public interface IResult
{
	bool IsSuccess { get; init; }
	bool IsError { get; }
	List<Error>? ErrorList { get; init; }
}
