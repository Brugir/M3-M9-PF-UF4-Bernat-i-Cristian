using System.Collections.Generic;

namespace PokeDexWeb.Models
{
    public class PokemonDetailsViewModel
    {
        public PokemonApiModel Pokemon { get; set; }
        public List<EvolutionStage> EvolutionStages { get; set; }
        public string Description { get; set; }
    }

    public class EvolutionStage
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
