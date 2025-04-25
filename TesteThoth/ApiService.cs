using Microsoft.IdentityModel.JsonWebTokens;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TesteThoth.Models;

public static class ApiService
{
    private static readonly HttpClient _client = new HttpClient();

    public static string JwtToken { get; private set; }
    public static int UserId { get; private set; }

    public static async Task<bool> RegisterAsync(string nome, string senha)
    {
        var dto = new { NomeDeUsuario = nome, Senha = senha };
        var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
        var resp = await _client.PostAsync("http://localhost:5082/Usuario/auth/register", jsonContent);
        return resp.IsSuccessStatusCode;
    }

    public static async Task<bool> LoginAsync(string nome, string senha)
    {
        var dto = new { NomeDeUsuario = nome, Senha = senha };
        var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
        var resp = await _client.PostAsync("http://localhost:5082/Usuario/auth/login", jsonContent);
        if (!resp.IsSuccessStatusCode) return false;

        var responseBody = await resp.Content.ReadAsStringAsync();
        using (var doc = JsonDocument.Parse(responseBody))
        {
            JwtToken = doc.RootElement.GetProperty("token").GetString();
        }

        var handler = new JsonWebTokenHandler();
        var token = handler.ReadJsonWebToken(JwtToken);
        UserId = int.Parse(token.Claims.First(c => c.Type == "unique_name").Value);

        _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", JwtToken);
        return true;
    }

    public static async Task<List<Compromisso>> GetCompromissosAsync()
        => await _client.GetFromJsonAsync<List<Compromisso>>($"https://localhost:7160/api/Compromissos")
           ?? new List<Compromisso>();

    public static async Task<Compromisso> CreateCompromissoAsync(Compromisso c)
    {
        var resp = await _client.PostAsJsonAsync("https://localhost:7160/api/Compromissos", c);
        return resp.IsSuccessStatusCode
            ? await resp.Content.ReadFromJsonAsync<Compromisso>()
            : null;
    }

    public static async Task<bool> UpdateCompromissoAsync(int id, Compromisso c)
        => (await _client.PutAsJsonAsync($"https://localhost:7160/api/Compromissos/{id}", c))
            .IsSuccessStatusCode;

    public static async Task<bool> DeleteCompromissoAsync(int id)
        => (await _client.DeleteAsync($"https://localhost:7160/api/Compromissos/{id}"))
            .IsSuccessStatusCode;
}
