using Certe.Result.ErrorDefinitions;
using Certe.Result.ResultAbstractions;

namespace Certe.Result.Extensions;

public static class ResultExtensions
{
	public static void Match(this IResult result, Action onSuccess, Action<IEnumerable<Error>> onFailure)
	{
		if (result.IsSuccess)
			onSuccess();
		else
			onFailure(result.ErrorList ?? []);
	}
}
