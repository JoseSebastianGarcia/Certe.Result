namespace Certe.Result.ResultAbstractions;

public interface IResult<T> : IResult where T : IResultSet
{
	public T? Data { get; init; }
}
