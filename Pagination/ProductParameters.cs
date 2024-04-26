namespace APICatalogo.Pagination;

public class ProductParameters
{
    public int MaxPageSize { get; set; } = 50;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; }
}