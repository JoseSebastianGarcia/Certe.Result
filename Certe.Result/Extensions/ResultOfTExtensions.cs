using Certe.Result.ErrorDefinitions;
using Certe.Result.ResultAbstractions;

namespace Certe.Result.Extensions;

public static class ResultOfTExtensions
{
	public static void Match<T>(this IResult<T> result, Action<T?> onSuccess, Action<IEnumerable<Error>> onFailure)
		where T : IResultSet
	{
		
		if(result.IsSuccess)
			onSuccess(result.Data);
		else
			onFailure(result.ErrorList ?? []);
	}
}
