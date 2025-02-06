namespace RestFull.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using RestFull.Models;
using RestFull.ViewModels;
using System.Text;

public class StoreService
{
    public List<StoreVM> lstStore = new List<StoreVM>();
    public SearchStoreModel searchStoreModel { get; set; } = new SearchStoreModel();

    public StoreEditVM storeEdit = new StoreEditVM();
    public HttpClient _httpClient;
    public StoreService(HttpClient http)
    {
        _httpClient = http;
    }

    public async Task GetPagingStore()
    {
        string keyword = searchStoreModel.Keyword;
        var url = $"https://apistore.cybersoft.edu.vn/api/Store/getAll?keyword={keyword}";
        var res = await _httpClient.GetFromJsonAsync<HTTPResponse<List<StoreVM>>>(url);
        lstStore = res.content;
        SetStateHasChange();
    }

    public async Task GetStoreByIdEditApi(int idStore)
    {
        var url = $"https://apistore.cybersoft.edu.vn/api/Store/getid?id={idStore}";
        var res = await _httpClient.GetFromJsonAsync<HTTPResponse<StoreEditVM>>(url);
        storeEdit = res.content;
        SetStateHasChange();

    }
    public async Task<string> UpdateStoreApi()
    {
        // URL gốc của API
        var url = $"https://apistore.cybersoft.edu.vn/api/Store";
        var res = await _httpClient.PutAsJsonAsync(url, storeEdit);
        var response = await res.Content.ReadFromJsonAsync<HTTPResponse<string>>();
        SetStateHasChange();
        return response.content;
    }

    public async Task<string> AddNewStore(StoreAddNew model)
    {
        var url = $"https://apistore.cybersoft.edu.vn/api/Store";
        var res = await _httpClient.PostAsJsonAsync(url, model);
        var response = await res.Content.ReadFromJsonAsync<HTTPResponse<string>>();
        return response.content;
    }

    public async Task<string> DeleteStoreByIdApi(int id)
    {
        List<int> lstId = new List<int>();
        lstId.Add(id);
        var jsonContent = new StringContent(
           JsonSerializer.Serialize(lstId),
           Encoding.UTF8,
           "application/json"
       );
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri($"https://apistore.cybersoft.edu.vn/api/Store/"),
            Content = jsonContent
        };
        var res = await _httpClient.SendAsync(request);
        GetPagingStore();
        return "Thành công";
    }



    public event Action OnChange;

    public void SetStateHasChange() => OnChange?.Invoke();


}