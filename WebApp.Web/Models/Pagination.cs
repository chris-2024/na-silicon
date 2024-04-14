namespace WebApp.Web.Models;

public class Pagination
{
    public int CurrentPage { get; set; }
    public int PageTotal { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}
