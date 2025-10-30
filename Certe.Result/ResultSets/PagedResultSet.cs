using Certe.Result.ResultAbstractions;

namespace Certe.Result.ResultSets;

public class PagedResultSet<T> : IResultSet
{
	public IEnumerable<T> Items { get; init; }
	public int PageNumber { get; init; }
	public int PageSize { get; init; }
	public int TotalRecords { get; init; }
	public int TotalPages { get; init; }

	private PagedResultSet(IEnumerable<T> items, int pageNumber, int pageSize, int totalRecords)
	{
		Items = items;
		PageNumber = pageNumber;
		PageSize = pageSize;
		TotalRecords = totalRecords;
		TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
	}

	public static PagedResultSet<T> Create(IEnumerable<T> items, int pageNumber, int pageSize, int totalRecords)
	 => new PagedResultSet<T>(items, pageNumber, pageSize, totalRecords);
	
}
