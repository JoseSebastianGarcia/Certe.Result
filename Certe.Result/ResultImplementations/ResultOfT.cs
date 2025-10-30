using Certe.Result.ErrorDefinitions;
using Certe.Result.ResultAbstractions;

namespace Certe.Result.ResultImplementations;

public class Result<T> : IResult<T> 
	where T : IResultSet
{
	public bool IsSuccess { get; set; }
	public bool IsError => !IsSuccess;
	public List<Error>? ErrorList { get; set; }
	public T? Data { get; set; }

	private Result(bool isSuccess, List<Error>? errorList, T? data)
	{
		IsSuccess = isSuccess;
		ErrorList = errorList;
		Data = data;
	}
	public static Result<T> Success(T? data)
	{
		return new Result<T>(true, null, data);
	}
	public static Result<T> Failure(List<Error>? errorList)
	{
		return new Result<T>(false, errorList, default);
	}
}
