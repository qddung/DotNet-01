namespace SignalR.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SignalR.Models;

public static class QueryStringHelper
{
    public static string BuildQueryBaseSearchPaging(this BaseSearchPaging search)
    {
        var queryString = QueryString.Create("pageIndex", search.PageIndex.ToString());
        queryString = queryString.Add("pageSize", search.PageSize.ToString());
        queryString = queryString.Add("keywords", search.Keyword ?? "");
        return queryString.ToString();
    }
}