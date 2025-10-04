using System.Net.Http.Json;
using LM.Shared.DtoModels;

namespace LM.Shared.ApiServices;

public class BookApiService
{
    private readonly HttpClient _httpClient;
    private const string baseUrl = "https://localhost:7243/Api/Books/";
    public BookApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseViewModel?> CreateNewBook(BookDto bookDto)
    {
        var response = await _httpClient.PostAsJsonAsync($"{baseUrl}NewBook", bookDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ResponseViewModel>();
    }
}
