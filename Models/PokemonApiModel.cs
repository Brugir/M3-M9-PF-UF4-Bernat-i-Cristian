namespace PokeDexWeb.Models
{
    public class PokemonApiModel
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public int Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("region")]
        public string Region { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("types")]
        public List<string> Types { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("evolution_line")]
        public List<string> EvolutionLine { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sprite_url")]
        public string SpriteUrl { get; set; }
    }

    public class Stats
    {
        [System.Text.Json.Serialization.JsonPropertyName("hp")]
        public int Hp { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("attack")]
        public int Attack { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("defense")]
        public int Defense { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("special-attack")]
        public int SpecialAttack { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("special-defense")]
        public int SpecialDefense { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("speed")]
        public int Speed { get; set; }
    }


    public class SpeciesRef
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Sprite
{
    [System.Text.Json.Serialization.JsonPropertyName("front_default")]
    public string? FrontDefault { get; set; }
}

    public class TypeWrapper
    {
        public Type Type { get; set; }
    }

    public class Type
    {
        public string Name { get; set; }
    }
}
