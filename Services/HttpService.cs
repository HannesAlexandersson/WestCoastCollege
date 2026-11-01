using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Interfaces;
using Microsoft.Extensions.Configuration;

namespace WestCoastCollege.Services;

public class HttpService<T> : IDisposable, IHttpService<T> where T : class
{

    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = string.Empty;
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };

    public HttpService()
    {
        var config = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
        _baseUrl = config.GetSection("Settings:BaseUrl").Value!;
        var key = config.GetSection("Settings:ApiKey").Value!;
        _httpClient = new();
        {
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Add("Cache-Control", "none");
            _httpClient.DefaultRequestHeaders.Add("x-apikey", key);
        }
    }

    public async Task Delete(string resource, string id)
    {
        try
        {
            var url = $"{resource}/{id}";

            await _httpClient.DeleteAsync(_baseUrl + url);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<List<T>> Get(string resource)
    {
        var response = await _httpClient.GetAsync(resource);
        if (!response.IsSuccessStatusCode)
            return [];

        var result = await response.Content.ReadAsStringAsync();

        var dataList = JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];

        return dataList;

    }

    public async Task<T> Get(string resource, string predicate)
    {
        var url = $"{resource}?q={predicate}";

        var response = await _httpClient.GetAsync(_baseUrl + url);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Something happened: " + response.StatusCode);

        var result = await response.Content.ReadAsStringAsync();

        var data = JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];

        if (data.Count == 0)
            throw new Exception("No matching item was found.");

        return data[0];
    }

    public async Task Post(string resourse, T data)
    {
        try
        {
            await _httpClient.PostAsJsonAsync<T>(resourse, data);
        }
        catch (Exception ex)
        { // throw ex  up in the stack
            throw new Exception(ex.Message);
        }
    }

    public async Task Put(string resource, T data, string objectId)
    {
        try
        {
            var url = $"{resource}/{objectId}";
            await _httpClient.PutAsJsonAsync<T>(_baseUrl + url, data);
        }
        catch (HttpRequestException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
