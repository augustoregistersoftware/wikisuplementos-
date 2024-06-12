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
    }
}
