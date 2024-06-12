using Microsoft.EntityFrameworkCore;
using wikisuplementos.Models;

namespace wikisuplementos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SuplementosModel> Suplementos { get; set; }
        public DbSet<TreinadorModel> Treinadores { get; set; }
        public DbSet<AtletaModel> Atletas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração do relacionamento
            modelBuilder.Entity<TreinadorModel>()
                .HasMany(t => t.Atletas)
                .WithOne(a => a.Treinador)
                .HasForeignKey(a => a.TreinadorId);
        }
    }
}
