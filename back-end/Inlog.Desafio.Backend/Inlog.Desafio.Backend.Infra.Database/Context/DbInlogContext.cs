using Inlog.Desafio.Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlog.Desafio.Backend.Infra.Database.Context
{
    public class DbInlogContext : DbContext
    {
        public DbInlogContext(DbContextOptions<DbInlogContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Veiculo>? Veiculos { get; set; }
        public DbSet<Rastreamento>? Rastreamentos { get; set; }
    }
}
