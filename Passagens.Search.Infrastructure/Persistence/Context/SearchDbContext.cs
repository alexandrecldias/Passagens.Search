using Microsoft.EntityFrameworkCore;
using Passagens.Search.Infrastructure.Persistence.Entities;

namespace Passagens.Search.Infrastructure.Persistence.Context;

public class SearchDbContext : DbContext
{
    public SearchDbContext(DbContextOptions<SearchDbContext> options) : base(options) { }

    public DbSet<PesquisaEntity> Pesquisas => Set<PesquisaEntity>();
    public DbSet<PesquisaSnapshotEntity> PesquisaSnapshots => Set<PesquisaSnapshotEntity>();
    public DbSet<VooEntity> Voos => Set<VooEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SearchDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
