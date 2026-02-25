using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Passagens.Search.Infrastructure.Persistence.Entities;

namespace Passagens.Search.Infrastructure.Persistence.Configurations;

public class PesquisaSnapshotEntityConfiguration : IEntityTypeConfiguration<PesquisaSnapshotEntity>
{
    public void Configure(EntityTypeBuilder<PesquisaSnapshotEntity> builder)
    {
        builder.ToTable("pesquisa_snapshots");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.PesquisadoEmUtc).IsRequired();
        builder.Property(x => x.RawJson).HasColumnType("jsonb"); // Postgres: bom pra JSON
        builder.Property(x => x.ResultHash).HasMaxLength(64);

        builder.HasMany(x => x.Voos)
               .WithOne(x => x.Snapshot)
               .HasForeignKey(x => x.SnapshotId);
    }
}