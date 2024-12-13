using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
using BibliotecaDonarVidaApp.Services.Interfaces;
using BibliotecaDonarVidaApp.Models;

namespace BibliotecaDonarVidaApp.Services
{
    public class DonanteService : IDonanteSercice
    {
        private readonly HttpClient _httpClient;
        protected readonly JsonSerializerOptions _jsonSerializerOptions;
        private const string BaseUrl = "https://donarvida.azurewebsites.net/api/donantes";

        public DonanteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<Donante>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(content);
            }
            return JsonSerializer.Deserialize<List<Donante>>(content, _jsonSerializerOptions)
                   ?? new List<Donante>();
        }

        public async Task<Donante> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Donante>($"{BaseUrl}/{id}")
                   ?? throw new InvalidOperationException("Donante no encontrado.");
        }

        public async Task<bool> CreateAsync(Donante donante)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, donante);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Donante donante)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{donante.Id}", donante);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
