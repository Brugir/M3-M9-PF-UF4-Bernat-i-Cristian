using System.Collections.Generic;

namespace PokeDexWeb.Models
{
    // Model per deserialitzar la resposta de la PokéAPI per tipus
    public class PokemonTypeApiModel
{
    public PokemonTypeApiModel() { Pokemon = new List<PokemonTypeSlot>(); }
    [System.Text.Json.Serialization.JsonPropertyName("pokemon")]
    public List<PokemonTypeSlot> Pokemon { get; set; }
}

public class PokemonTypeSlot
{
    public PokemonTypeSlot() { Pokemon = new PokemonTypeEntry(); }
    [System.Text.Json.Serialization.JsonPropertyName("pokemon")]
    public PokemonTypeEntry Pokemon { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("slot")]
    public int Slot { get; set; }
}

public class PokemonTypeEntry
{
    public PokemonTypeEntry() { Name = string.Empty; Url = string.Empty; }
    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("url")]
    public string Url { get; set; }
}
}
