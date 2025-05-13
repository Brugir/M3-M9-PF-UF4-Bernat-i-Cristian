using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokeDexWeb.Models
{
    public class PokemonRegionApiModel
{
    public PokemonRegionApiModel() { PokemonEntries = new List<PokemonEntry>(); }
    [JsonPropertyName("pokemon_entries")]
    public List<PokemonEntry> PokemonEntries { get; set; }
}

public class PokemonEntry
{
    public PokemonEntry() { PokemonSpecies = new SpeciesRef(); }
    [JsonPropertyName("pokemon_species")]
    public SpeciesRef PokemonSpecies { get; set; }
}
}
