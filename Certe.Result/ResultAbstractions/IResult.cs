using Certe.Result.ErrorDefinitions;

namespace Certe.Result.ResultAbstractions;

public interface IResult
{
	bool IsSuccess { get; set; }
	bool IsError { get; }
	List<Error>? ErrorList { get; set; }
}
