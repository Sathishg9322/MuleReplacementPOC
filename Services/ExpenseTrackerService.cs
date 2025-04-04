using MuleReplacementPOC.Model;
using System.Text.Json;

namespace MuleReplacementPOC.Services
{
    public class ExpenseTrackerService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ExpenseTrackerService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {
            var apiUrl = _configuration["ExpenseAPI:BaseUrl"];
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException("Failed to fetch data");

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Expense>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }


        public async Task<List<Expense>> GetExpensesByIdAsync(int id)
        {
            var apiUrl = _configuration["ExpenseAPI:BaseUrl"] +"/"+id;
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException("Failed to fetch data");

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Expense>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }


    }
}
