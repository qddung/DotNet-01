namespace RestFull.Models;
using System;
public class PagingData
{
    public PagingData()
    {

    }
    
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}


