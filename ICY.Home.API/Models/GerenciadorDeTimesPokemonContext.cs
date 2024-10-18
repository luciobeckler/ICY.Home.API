using Microsoft.EntityFrameworkCore;

namespace ICY.Home.API.Models
{
    public class GerenciadorDeTimesPokemonContext : DbContext
    {
        public GerenciadorDeTimesPokemonContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Pokemons> Pokemons { get; set; }
    }
}
