using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokeDexWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokeApiController : ControllerBase
    {
        private readonly string dataPath = "Data/pokemon_clean_data.json";

        [HttpGet("pokemon")]
        public async Task<IActionResult> GetAllPokemon()
        {
            var json = await System.IO.File.ReadAllTextAsync(dataPath);
            var pokemons = JsonSerializer.Deserialize<List<Pokemon>>(json);
            return Ok(pokemons);
        }

        [HttpGet("pokemon/{name}")]
        public async Task<IActionResult> GetPokemonByName(string name)
        {
            var json = await System.IO.File.ReadAllTextAsync(dataPath);
            var pokemons = JsonSerializer.Deserialize<List<Pokemon>>(json);
            var result = pokemons.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (result != null)
                return Ok(result);
            return NotFound(new { error = "Pokémon no encontrado" });
        }

        [HttpGet("tipo/{tipo}")]
        public async Task<IActionResult> GetPokemonByType(string tipo)
        {
            var json = await System.IO.File.ReadAllTextAsync(dataPath);
            var pokemons = JsonSerializer.Deserialize<List<Pokemon>>(json);
            var result = pokemons.Where(p => p.Types.Any(t => t.Equals(tipo, StringComparison.OrdinalIgnoreCase))).ToList();
            if (result.Any())
                return Ok(result);
            return NotFound(new { error = "No se encontraron Pokémon de este tipo" });
        }

        [HttpGet("region/{region}")]
        public async Task<IActionResult> GetPokemonByRegion(string region)
        {
            var json = await System.IO.File.ReadAllTextAsync(dataPath);
            var pokemons = JsonSerializer.Deserialize<List<Pokemon>>(json);
            var result = pokemons.Where(p => p.Region.Equals(region, StringComparison.OrdinalIgnoreCase)).ToList();
            if (result.Any())
                return Ok(result);
            return NotFound(new { error = "No se encontraron Pokémon de esta región" });
        }
    }

    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("types")]
        public List<string> Types { get; set; }

        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        [JsonPropertyName("evolution_line")]
        public List<string> EvolutionLine { get; set; }

        [JsonPropertyName("sprite_url")]
        public string SpriteUrl { get; set; }
    }

    public class Stats
    {
        [JsonPropertyName("hp")]
        public int Hp { get; set; }

        [JsonPropertyName("attack")]
        public int Attack { get; set; }

        [JsonPropertyName("defense")]
        public int Defense { get; set; }

        [JsonPropertyName("special-attack")]
        public int SpecialAttack { get; set; }

        [JsonPropertyName("special-defense")]
        public int SpecialDefense { get; set; }

        [JsonPropertyName("speed")]
        public int Speed { get; set; }
    }
}
