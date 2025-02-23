namespace SignalR.Services;
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
using SignalR.ViewModels.Category;
public class ProductCategoryService : IDisposable
{
    private const string ProductHost = "https://apistore.cybersoft.edu.vn";
    public string searchKeyword { get; set; }
    public List<ProductVM> lstProduct = new List<ProductVM>();

    public string categorySelected { get; set; }

    public List<CategoryViewItem> lstCategory = new List<CategoryViewItem>();
    public ProductDetailVM prodDetail = new ProductDetailVM();
    public ProductEditVM productEdit = new ProductEditVM();
    public HttpClient _httpClient;
    public IMapper mapperObject { get; set; }



    public ProductCategoryService(HttpClient http, IMapper mapping)
    {
        _httpClient = http;
        mapperObject = mapping;
    }

    public List<CategoryOption> GetCategoryOptions()
    {
        return lstCategory.Select(c => mapperObject.Map<CategoryOption>(c)).ToList();
    }

    public List<ProductDTO> GetProductOnCategory()
    {
        var list = new List<ProductDTO>();
        foreach (var product in lstProduct)
        {
            if (string.IsNullOrEmpty(product.Categories) || product.Categories.Contains(categorySelected)) continue;
            var dto = mapperObject.Map<ProductDTO>(product);
            list.Add(dto);
        }
        return list;
    }



    public async Task GetAllCategory()
    {
        var url = $"{ProductHost}/api/Product/getAllCategory";
        var res = await _httpClient.GetFromJsonAsync<HTTPResponse<List<CategoryViewItem>>>(url);
        lstCategory = res.content;
        await GetAllProductApi();
        SetStateHasChange();
    }

    public async Task GetAllProductApi()
    {
        // URL gốc của API
        var url = $"{ProductHost}/api/Product";
        var res = await _httpClient.GetFromJsonAsync<HTTPResponse<List<ProductVM>>>(url);
        lstProduct = res.content;
    }



    public async Task InitPageData()
    {
        await GetAllCategory();
        var firstCategory = lstCategory.FirstOrDefault();
        if (firstCategory != null)
        {
            ChangeCategory(firstCategory.id);
            return;
        }
    }

    public async Task ChangeCategory(string categoryId)
    {
        categorySelected = categoryId;
        await GetAllProduct();
    }

    public async Task GetAllProduct()
    {
        // URL gốc của API
        var url = $"{ProductHost}/api/Product/api/Product?categoryId={categorySelected ?? ""}";
        var res = await _httpClient.GetFromJsonAsync<HTTPResponse<List<ProductVM>>>(url);
        lstProduct = res.content;
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
    public event Action OnChange;

    public void SetStateHasChange() => OnChange?.Invoke();

    public void Dispose()
    {
    }
}