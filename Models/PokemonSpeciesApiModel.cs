using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokeDexWeb.Models
{
    public class PokemonSpeciesApiModel
    {
        public PokemonSpeciesApiModel() {
            EvolutionChain = new EvolutionChainLink();
            FlavorTextEntries = new List<FlavorTextEntry>();
            Varieties = new List<Variety>();
        }
        [JsonPropertyName("evolution_chain")]
        public EvolutionChainLink EvolutionChain { get; set; }

        [JsonPropertyName("flavor_text_entries")]
        public List<FlavorTextEntry> FlavorTextEntries { get; set; }

        [JsonPropertyName("varieties")]
        public List<Variety> Varieties { get; set; }
    }

    public class Variety
    {
        public Variety() { Pokemon = new SpeciesRef(); }
        [JsonPropertyName("pokemon")]
        public SpeciesRef Pokemon { get; set; }
        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }
    }

    public class FlavorTextEntry
    {
        public FlavorTextEntry() { FlavorText = string.Empty; Language = new Language(); }
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }
        [JsonPropertyName("language")]
        public Language Language { get; set; }
    }

    public class Language
    {
        public Language() { Name = string.Empty; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class EvolutionChainLink
    {
        public EvolutionChainLink() { Url = string.Empty; }
        public string Url { get; set; }
    }

    public class EvolutionChainApiModel
    {
        public EvolutionChainApiModel() { Chain = new ChainLink(); }
        public ChainLink Chain { get; set; }
    }

    public class ChainLink
{
    public ChainLink() { Species = new Species(); EvolvesTo = new List<ChainLink>(); }
    public Species Species { get; set; }
    public List<ChainLink> EvolvesTo { get; set; }


}

    public class Species
    {
        public Species() { Name = string.Empty; Url = string.Empty; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
