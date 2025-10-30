using Certe.Result.ResultAbstractions;

namespace Certe.Result.ResultSets;

public class PagedResultSet<T> : IResultSet
{
	public IEnumerable<T> Items { get; set; }
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
	public int TotalRecords { get; set; }
	public int TotalPages { get; set; }

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
