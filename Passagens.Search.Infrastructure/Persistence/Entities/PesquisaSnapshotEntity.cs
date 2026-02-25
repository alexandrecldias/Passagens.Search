using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passagens.Search.Infrastructure.Persistence.Entities;

public class PesquisaSnapshotEntity
{
    public Guid Id { get; set; }

    public Guid PesquisaId { get; set; }
    public PesquisaEntity Pesquisa { get; set; } = default!;

    public DateTime PesquisadoEmUtc { get; set; }

    // opcional, mas MUITO útil (auditoria / reprocessar depois)
    public string? RawJson { get; set; }

    // útil pra detectar mudança sem comparar tudo
    public string? ResultHash { get; set; }

    public List<VooEntity> Voos { get; set; } = new();
}
