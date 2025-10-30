using Certe.Result.ResultAbstractions;

namespace Certe.Result.ResultSets;

public class SimpleResultSet<T> : IResultSet
{
	public T Value { get; set; }
	private SimpleResultSet(T value) 
		=> Value = value;
	

	public static SimpleResultSet<T> Create(T value) => new SimpleResultSet<T>(value);
	
}
