using Certe.Result.ErrorDefinitions;
using Certe.Result.ResultAbstractions;

namespace Certe.Result.ResultImplementations;

public class Result : IResult
{
	public bool IsSuccess { get; init; }

	public bool IsError => !IsSuccess;

	public List<Error>? ErrorList { get; init; }

	private Result(bool isSuccess, List<Error>? errorList)
	{
		IsSuccess = isSuccess;
		ErrorList = errorList;
	}
	public static Result Success() 
		=> new Result(true, null);
	
	public static Result Failure(List<Error>? errorList) 
		=> new Result(false, errorList);
	

}
