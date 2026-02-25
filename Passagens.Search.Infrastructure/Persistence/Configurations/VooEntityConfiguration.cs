using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Passagens.Search.Infrastructure.Persistence.Entities;

namespace Passagens.Search.Infrastructure.Persistence.Configurations;

public class VooEntityConfiguration : IEntityTypeConfiguration<VooEntity>
{
    public void Configure(EntityTypeBuilder<VooEntity> builder)
    {
        builder.ToTable("voos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Companhia).HasMaxLength(80).IsRequired();
        builder.Property(x => x.NumeroVoo).HasMaxLength(20).IsRequired();

        builder.Property(x => x.Valor).HasPrecision(18, 2).IsRequired();
        builder.Property(x => x.DuracaoMinutos).IsRequired();

        // índice útil pra consultas por preço
        builder.HasIndex(x => x.Valor);
    }
}