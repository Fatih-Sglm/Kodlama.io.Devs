namespace Core.Application.Requests;

public class PageRequest
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 5;
}