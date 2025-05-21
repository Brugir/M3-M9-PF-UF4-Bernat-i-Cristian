using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PokeDexWeb.Models;

namespace PokeDexWeb.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        // Obtener todos los pokémon de una región desde la API local
        public async Task<List<PokemonApiModel>> GetPokemonsByRegion(string region)
        {
            var endpoint = $"http://localhost:5064/api/pokeapi/region/{region.ToLower()}";
            var response = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al consultar la API local: {response.StatusCode}");
            }
            var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var pokemons = await response.Content.ReadFromJsonAsync<List<PokemonApiModel>>(options);
            return pokemons ?? new List<PokemonApiModel>();
        }

        // Ya no se usa species ni evolution chain, la info viene en el JSON local
        public Task<object?> GetPokemonSpecies(string name) => Task.FromResult<object?>(null);
        public Task<object?> GetEvolutionChain(string url) => Task.FromResult<object?>(null);

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener datos de un Pokémon por nombre desde la API local
        public async Task<PokemonApiModel> GetPokemonByName(string name)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5064/api/pokeapi/pokemon/{name.ToLower()}");
            if (response.IsSuccessStatusCode)
            {
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = await response.Content.ReadFromJsonAsync<PokemonApiModel>(options);
                return result;
            }
            return null;
        }
        // Obtener todos los pokémon de un tipo desde la API local
        public async Task<List<PokemonApiModel>> GetPokemonsByType(string type)
        {
            var endpoint = $"http://localhost:5064/api/pokeapi/tipo/{type.ToLower()}";
            var response = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al consultar la API local: {response.StatusCode}");
            }
            var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var pokemons = await response.Content.ReadFromJsonAsync<List<PokemonApiModel>>(options);
            return pokemons ?? new List<PokemonApiModel>();
        }
    }
}
