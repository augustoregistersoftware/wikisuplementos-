

using Microsoft.EntityFrameworkCore;
using wikisuplementos.Models;

namespace wikisuplementos.Data;

public class BancoContext : DbContext{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }

    public DbSet<SuplementosModel> Suplementos {get; set;}
}