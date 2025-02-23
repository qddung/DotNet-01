namespace SignalR.Models;
public class PagingData
{
    public PagingData()
    {
        PageIndex = 1;
        PageSize = 10;
    }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }

    public int TotalItems { get; set; }
}

public class BaseSearchPaging : PagingData
{
    public string? Keyword { get; set; }
}

public class BaseResponsePaging<T>
{
    public BaseResponsePaging()
    {
        items = default(T);

    }
    public T items { get; set; }
    public int pageIndex { get; set; }
    public int pageSize { get; set; }
    public int totalRow { get; set; }
    public string keywords { get; set; }
}