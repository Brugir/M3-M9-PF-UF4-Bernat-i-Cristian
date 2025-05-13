using Microsoft.EntityFrameworkCore;

namespace PokeDexWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PokeDexWeb.Models.PokemonFavorite> PokemonFavorites { get; set; }
    }
}
