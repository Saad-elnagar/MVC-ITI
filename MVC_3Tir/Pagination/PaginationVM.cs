using MVC_3Tir.Models;

namespace MVC_3Tir.Pagination;

public class PaginationVM<T> where T :  Product
{
    public IEnumerable<T> Data { get; set; } = new List<T>();

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalItems { get; set; }

    public int TotalPages =>
        (int)Math.Ceiling((double)TotalItems / PageSize);

    public bool HasPrevious =>
        CurrentPage > 1;

    public bool HasNext =>
        CurrentPage < TotalPages;
    
}