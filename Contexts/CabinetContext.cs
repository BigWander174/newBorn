using Microsoft.EntityFrameworkCore;
using newBorn.Model;

namespace newBorn.Contexts
{
    internal class CabinetContext : DbContext
    {
        public DbSet<Cabinet>? Cabinets { get; set; }
        public DbSet<Registry>? Registries { get; set; }
        public DbSet<ResourceLocation>? ResourceLocations { get; set; }

        public CabinetContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Main;Username=postgres;Password=BigGuardian");
        }
    }
}
