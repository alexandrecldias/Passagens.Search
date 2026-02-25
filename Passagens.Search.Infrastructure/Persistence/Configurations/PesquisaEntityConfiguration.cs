using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Passagens.Search.Infrastructure.Persistence.Entities;

namespace Passagens.Search.Infrastructure.Persistence.Configurations;

public class PesquisaEntityConfiguration : IEntityTypeConfiguration<PesquisaEntity>
{
    public void Configure(EntityTypeBuilder<PesquisaEntity> builder)
    {
        builder.ToTable("pesquisas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.AeroportoOrigem).HasMaxLength(3).IsRequired();
        builder.Property(x => x.AeroportoDestino).HasMaxLength(3).IsRequired();

        builder.Property(x => x.CreatedAtUtc).IsRequired();

        builder.HasMany(x => x.Snapshots)
               .WithOne(x => x.Pesquisa)
               .HasForeignKey(x => x.PesquisaId);
    }
}