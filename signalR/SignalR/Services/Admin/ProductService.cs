namespace SignalR.Services.Admin;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using SignalR.ViewModels;
using System.Text;
using SignalR.Models;
using SignalR.Utility;
using AutoMapper;

public class ProductService : IDisposable
{
    private const string ProductHost = "https://apistore.cybersoft.edu.vn";
    public BaseSearchPaging searchModel = new BaseSearchPaging();
    public List<ProductVM> lstProduct = new List<ProductVM>();
    public ProductDetailVM prodDetail = new ProductDetailVM();
    public ProductEditVM productEdit = new ProductEditVM();
    public HttpClient _httpClient;
    public IMapper mapperObject { get; set; }

    public List<ProductDTO> GetProductListAdminDTO()
    {
        var list = new List<ProductDTO>();
        foreach (var product in lstProduct)
        {
            var dto = mapperObject.Map<ProductDTO>(product);
            list.Add(dto);
        }
        return list;
    }

    public ProductService(HttpClient http, IMapper mapping)
    {
        _httpClient = http;
        mapperObject = mapping;
    }

    public string searchKeyword
    {
        get
        {
            return searchModel.Keyword ?? "";
        }
        set
        {
            searchModel.Keyword = value;
        }
    }

    public int CountItems
    {
        get
        {
            return searchModel?.TotalItems ?? 0;
        }
        set
        {
            if (searchModel == null) return;
            searchModel.TotalItems = value;
        }
    }
    // public async Task GetAllProductApi()
    // {
    //     // URL gốc của API
    //     var url = $"{ProductHost}/api/Product";
    //     var res = await _httpClient.GetFromJsonAsync<HTTPResponse<List<ProductVM>>>(url);
    //     lstProduct = res.content;
    //     SetStateHasChange();
    // }
    // public async Task GetAllProductByKeywordApi(string keyword = "")
    // {
    //     // URL gốc của API
    //     var url = $"{ProductHost}/api/Product?keyword={keyword}";
    //     var res = await _httpClient.GetFromJsonAsync<HTTPResponse<List<ProductVM>>>(url);
    //     lstProductSearch = res?.content ?? new List<ProductVM>();
    //     SetStateHasChange();
    // }

    public async Task ResetDefaultPageData()
    {
        searchModel = new BaseSearchPaging();
        await GetAllProductByBaseSearchPaging();
    }

    public void ChangePage(int pageIndex)
    {
        searchModel.PageIndex = pageIndex;
        // await GetAllProductByBaseSearchPaging();
    }



    public async Task GetAllProductByBaseSearchPaging()
    {
        try
        {
            var queryString = QueryStringHelper.BuildQueryBaseSearchPaging(searchModel);
            var url = $"{ProductHost}/api/Product/getpaging{queryString}";
            var res = await _httpClient.GetFromJsonAsync<HTTPResponse<BaseResponsePaging<List<ProductVM>>>>(url);
            lstProduct = res?.content?.items ?? new List<ProductVM>();
            searchModel.TotalItems = res.content.totalRow;
            SetStateHasChange();
        }
        catch (Exception ex)
        {
            throw ex;
        } 
    }

    public async Task GetProductByIdApi(string id)
    {
        // URL gốc của API
        var url = $"{ProductHost}/api/Product/getid?id={id}";
        var res = await _httpClient.GetFromJsonAsync<HTTPResponse<ProductDetailVM>>(url);
        prodDetail = res.content;
        SetStateHasChange();
    }

    public async Task GetProductByIdEditApi(string idProduct)
    {
        if (!string.IsNullOrEmpty(idProduct))
        {
            // URL gốc của API
            var url = $"{ProductHost}/api/Product/getid?id={idProduct}";
            var res = await _httpClient.GetFromJsonAsync<HTTPResponse<ProductEditVM>>(url);
            productEdit = res.content;
        }
        SetStateHasChange();

    }
    public async Task<string> UpdateProductApi()
    {
        // URL gốc của API
        var url = $"{ProductHost}/api/Product/updateProduct";
        var res = await _httpClient.PutAsJsonAsync(url, productEdit);
        var response = await res.Content.ReadFromJsonAsync<HTTPResponse<string>>();
        SetStateHasChange();
        return response.content;
    }

    public async Task<string> AddNewProduct(ProductAddNew model)
    {
        // URL gốc của API
        var url = $"{ProductHost}/api/Product/addNew";
        var res = await _httpClient.PostAsJsonAsync(url, model);
        var response = await res.Content.ReadFromJsonAsync<HTTPResponse<string>>();
        SetStateHasChange();
        return response.content;
    }

    public async Task<string> DeleteProductByIdApi(string id)
    {
        List<string> lstId = new List<string>();
        lstId.Add(id);
        var jsonContent = new StringContent(
           JsonSerializer.Serialize(lstId),
           Encoding.UTF8,
           "application/json"
       );
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri("{ProductHost}/api/Product"),
            Content = jsonContent
        };
        var res = await _httpClient.SendAsync(request);
        // var response = await res.Result.Content.ReadFromJsonAsync<HTTPResponse<string>>();
        //Sau khi xoá dữ liệu thành công thì gọi lại api getAll để cập nhật lại prodServer.lstProduct
        GetAllProductByBaseSearchPaging();
        return "Thành công";
    }



    public event Action OnChange;

    public void SetStateHasChange() => OnChange?.Invoke();

    public void Dispose()
    {
    }
}